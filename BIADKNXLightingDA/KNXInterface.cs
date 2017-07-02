﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;

using System.Data;
using MySql.Data.MySqlClient;

using Agilor.Interface;
using Agilor.Interface.Val;

namespace BIADKNXLightingDA {
    public partial class Form1 : Form {

        public static bool needReloadConfig = false;

        private ACI aci = null;
        //private RTDB rtdb = null;

        public static Dictionary<string, RTDB> rtdbs = new Dictionary<string, RTDB>();
        public static Dictionary<string, bool> less7bitsFlag = new Dictionary<string, bool>();

        //FalconInterfacesLib._GUID m_guidEdi; GUID for Falcon
        System.Guid m_guidEdi;
        String _sConnectionParameter;

        private EIBA.Interop.Falcon.GroupDataClass _ptrGroupData;
        private EIBA.Interop.Falcon.ConfirmedGroupDataClass _ptrConfirmedGroupData;
        private EIBA.Interop.Falcon.IGroupDataTransfer _ptrGroupDataTransfer;

        //variables to save the last inserted values in the GroupDataRead dialog
        public int _nGroupDataReadPriority;
        public int _nGroupDataReadRoutingCount;
        public string _sGroupDataReadGroupAddress;

        //variables to save the last inserted values in the GroupDataWrite dialog
        public int _nGroupDataWritePriority;
        public int _nGroupDataWriteRoutingCount;
        public string _sGroupDataWriteData;
        public string _sGroupDataWriteGroupAddress;
        public bool _bGroupDataWriteLessthan7bits;

        //variables to save the config values in the GroupDataWrite dialog
        public static int _nGroupDataWritePriority_config;
        public static int _nGroupDataWriteRoutingCount_config;
        public static bool _bGroupDataWriteLessthan7bits_config;


        private FalconDemoHelper objFalconDemoHelper = new FalconDemoHelper();

        public Form1() {
            InitializeComponent();

            _nGroupDataReadPriority = 3;
            _nGroupDataReadRoutingCount = 6;
            _sGroupDataReadGroupAddress = "";

            _nGroupDataWritePriority = 3;
            _nGroupDataWriteRoutingCount = 6;
            _sGroupDataWriteData = "";
            _sGroupDataWriteGroupAddress = "";
            _bGroupDataWriteLessthan7bits = false;


            connectAgilorDBACI.Tag = false;
            selectKNXInterface.Tag = false;
        }

        private void connectAgilorDB_Click(object sender, EventArgs e) {
            try {

                if (!rtdbs.ContainsKey(agilorConnectDeviceName.Text))
                {
                    // 准备连接 Agilor
                    RTDB rtdb = RTDB.Instance(agilorConnectDeviceName.Text, agilorConnectIP.Text);
                    rtdb.ValueReceived += Rtdb_ValueReceived;

                    rtdbs[agilorConnectDeviceName.Text] = rtdb;
                    less7bitsFlag[agilorConnectDeviceName.Text] = checkBox_less7bitflag.Checked;

                    loggingBox.AppendText("Connect device '" + agilorConnectDeviceName.Text + "' finished!\r\n");
                } else
                {
                    //MessageBox.Show("设备：'" + agilorConnectDeviceName.Text + "' 已经连接，重复的连接！");
                    loggingBox.AppendText("Device '" + agilorConnectDeviceName.Text + "' is been connected!\r\n");
                    return;
                }

                //if ((bool)connectAgilorDB.Tag) {
                //    // 已经连接 Agilor
                //    if (rtdb != null) rtdb.Close();
                //    rtdb = null;

                //    connectAgilorDB.Text = "Connect";
                //    loggingBox.AppendText("Agilor Disconnect Success." + "\r\n");
                //    connectAgilorDB.Tag = false;
                //} else {
                //    // 未连接 Agilor
                //    rtdb = RTDB.Instance(agilorConnectDeviceName.Text, agilorConnectIP.Text);
                //    rtdb.ValueReceived += Rtdb_ValueReceived;

                //    connectAgilorDB.Text = "Disconnect";
                //    loggingBox.AppendText("Agilor Connect Success." + "\r\n");
                //    connectAgilorDB.Tag = true;
                //}
            } catch (Exception ex) {
                loggingBox.AppendText("ERROR:" + ex.ToString() + "\r\n");
            }
        }

        private void Rtdb_ValueReceived(Agilor.Interface.Val.Value value) {

            if (needReloadConfig) {
                ReloadConfigFile();
            }

            // 输出到控制台
            var msg = "RECEIVED:\r\n"
                    + "Name:" + value.Name + "\r\n"
                    + "Type:" + value.Type + "\r\n"
                    + " Val:" + value.Val + "\r\n"
                    + "State:" + value.State + "\r\n"
                    + "Time:" + value.Time + "\r\n"
                    + "\r\n";
            loggingBox.Invoke(new Action<string>(loggingBox.AppendText), new object[] { msg });

            // 写入到数据库
            string deviceName = null;
            try
            {
                foreach (var device in rtdbs)
                {
                    if (device.Value.WriteValue(value))
                    {
                        deviceName = device.Key;
                        break;
                    }
                }

                if(deviceName == null)
                {
                    loggingBox.Invoke(new Action<string>(loggingBox.AppendText), new object[] { "Write To Agilor DB Error: No device can write this point:' " + value.Name + " '!\r\n" });
                    //MessageBox.Show("Rtdb_ValueReceived: write to agilor error!");
                    return;
                }
                //rtdb.WriteValue(value);
            }
            catch (Exception ex)
            {
                loggingBox.Invoke(new Action<string>(loggingBox.AppendText), new object[] { "Write To Agilor DB Error: No device can write this point:' " + value.Name + " '!\r\n" + ex.ToString() + "\r\n" });
                //MessageBox.Show("Rtdb_ValueReceived: write to agilor error!");
                return;
            }

            // 写入到设备
            try {
                EIBA.Interop.Falcon.DeviceWriteError eError;
                eError = _ptrGroupDataTransfer.Write((object)AgilorSourceNameAndKNXGroupAddressConvert.getGroupAddressBySourceName(value.Name),
                  (EIBA.Interop.Falcon.Priority)_nGroupDataWritePriority_config,
                  _nGroupDataWriteRoutingCount_config,
                  //_bGroupDataWriteLessthan7bits_config ? true : false,
                  less7bitsFlag[deviceName],
                  (object)(value.Val.ToString()));
                // extended error information
                if (eError != EIBA.Interop.Falcon.DeviceWriteError.DeviceWriteErrorNoError) {
                    // error message
                    loggingBox.Invoke(new Action<string>(loggingBox.AppendText), new object[] { "Error: group data write - 1 error\r\n" });
                    //MessageBox.Show("Rtdb_ValueReceived: error, group data write error");
                }
            } catch (Exception ex){
                loggingBox.Invoke(new Action<string>(loggingBox.AppendText), new object[] { "Write To KNX Error:\r\n" + ex.ToString() + "\r\n" });
                //MessageBox.Show("Rtdb_ValueReceived: write to knx device error, " + ex.ToString());
                return;
            }
        }

        private void agilorReadTarget_Click(object sender, EventArgs e) {
            try {
                var names = agilorRWTargetName.Text.Split(';');
                var values = aci.QuerySnapshots(names);
                loggingBox.AppendText("READ TARGETS("+values.Count.ToString()+"):\r\n");
                int index = 1;
                foreach (var val in values) {
                    loggingBox.AppendText("Target-" + index++.ToString() + ":\r\n"
                    + "Name:" + val.Name + "\r\n"
                    + "Type:" + val.Type + "\r\n"
                    + " Val:" + val.Val + "\r\n"
                    + "State:" + val.State + "\r\n"
                    + "Time:" + val.Time + "\r\n"
                    + "\r\n");
                }
            } catch (Exception ex) {
                loggingBox.AppendText("ERROR:" + ex.ToString() + "\r\n");
            }
        }

        
        private void agilorWriteTarget_Click(object sender, EventArgs e) {
            try {
                //if (!(bool)connectAgilorDB.Tag) {
                //    loggingBox.AppendText("ERROR: Agilor is disconnected! \r\n");
                //    MessageBox.Show("Agilor is disconnected! \r\n", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}
                object val;
                switch (agilorWTargetValyeType.SelectedItem.ToString()) {
                    case "LONG":
                        val = int.Parse(agilorWTargetValue.Text);
                        break;
                    case "BOOL":
                        val = bool.Parse(agilorWTargetValue.Text);
                        break;
                    case "FLOAT":
                        val = float.Parse(agilorWTargetValue.Text);
                        break;
                    case "STRING":
                        val = agilorWTargetValue.Text;
                        break;
                    default:
                        val = "";
                        break;
                }
                bool isSuccess = false;
                foreach (var device in rtdbs)
                {
                    if (device.Value.WriteValue(new Agilor.Interface.Val.Value(agilorRWTargetName.Text, val)))
                    {
                        isSuccess = true;
                        break;
                    }
                }
                if (isSuccess)
                {
                    loggingBox.AppendText("WRITE:\r\n"
                    + "Name:" + agilorRWTargetName.Text + "\r\n"
                    + "Value:" + val.ToString() + "\r\n"
                    + "Type:" + agilorWTargetValyeType.SelectedItem.ToString() + "\r\n"
                    + "\r\n");
                } else
                {
                    //MessageBox.Show("No device can write this point: '" + agilorRWTargetName.Text + "'!\r\n");
                    loggingBox.AppendText("No device can write this point: '" + agilorRWTargetName.Text + "'!\r\n");
                }
                //rtdb.WriteValue(new Agilor.Interface.Val.Value(agilorRWTargetName.Text, val));
            } catch (Exception ex) {
                loggingBox.AppendText("ERROR:" + ex.ToString() + "\r\n");
            }
        }

        private void agilorACIWriteTarget_Click(object sender, EventArgs e) {

            GC.Collect();

            try {
                object val;
                switch (agilorWTargetValyeType.SelectedItem.ToString()) {
                    case "LONG":
                        val = int.Parse(agilorWTargetValue.Text);
                        break;
                    case "BOOL":
                        val = bool.Parse(agilorWTargetValue.Text);
                        break;
                    case "FLOAT":
                        val = float.Parse(agilorWTargetValue.Text);
                        break;
                    case "STRING":
                        val = agilorWTargetValue.Text;
                        break;
                    default:
                        val = "";
                        break;
                }
                aci.SetValue(new Agilor.Interface.Val.Value(agilorRWTargetName.Text, val));
                loggingBox.AppendText("ACI WRITE TARGET:\r\n"
                    + "Name:" + agilorRWTargetName.Text + "\r\n"
                    + "Value:" + val.ToString() + "\r\n"
                    + "Type:" + agilorWTargetValyeType.SelectedItem.ToString() + "\r\n"
                    + "\r\n");
            } catch (Exception ex) {
                loggingBox.AppendText("ERROR:" + ex.ToString() + "\r\n");
            }
        }



        private void selectKNXInterface_Click(object sender, EventArgs e) {
            try {
                if ((bool)selectKNXInterface.Tag) {
                    // 已连接，执行断开连接操作
                    if (_ptrConfirmedGroupData != null) {
                        _ptrConfirmedGroupData.GroupDataIndicationRead -= new EIBA.Interop.Falcon.IClientGroupDataEvent_GroupDataIndicationReadEventHandler(OnGroupDataIndicationRead);
                        _ptrConfirmedGroupData.GroupDataConfirmationRead -= new EIBA.Interop.Falcon.IClientGroupDataEvent_GroupDataConfirmationReadEventHandler(OnGroupDataConfirmationRead);
                        _ptrConfirmedGroupData.GroupDataIndicationWrite -= new EIBA.Interop.Falcon.IClientGroupDataEvent_GroupDataIndicationWriteEventHandler(OnGroupDataIndicationWrite);
                        _ptrConfirmedGroupData.GroupDataConfirmationWrite -= new EIBA.Interop.Falcon.IClientGroupDataEvent_GroupDataConfirmationWriteEventHandler(OnGroupDataConfirmationWrite);
                        _ptrConfirmedGroupData.GroupDataIndicationResponse -= new EIBA.Interop.Falcon.IClientGroupDataEvent_GroupDataIndicationResponseEventHandler(OnGroupDataIndicationResponse);
                        _ptrConfirmedGroupData.GroupDataConfirmationResponse -= new EIBA.Interop.Falcon.IClientGroupDataEvent_GroupDataConfirmationResponseEventHandler(OnGroupDataConfirmationResponse);
                        _ptrConfirmedGroupData.Status -= new EIBA.Interop.Falcon.IClientGroupDataEvent_StatusEventHandler(OnStatus);
                    }
                    if (_ptrGroupData != null) {
                        _ptrGroupData.GroupDataIndicationRead -= new EIBA.Interop.Falcon.IClientGroupDataEvent_GroupDataIndicationReadEventHandler(OnGroupDataIndicationRead);
                        _ptrGroupData.GroupDataConfirmationRead -= new EIBA.Interop.Falcon.IClientGroupDataEvent_GroupDataConfirmationReadEventHandler(OnGroupDataConfirmationRead);
                        _ptrGroupData.GroupDataIndicationWrite -= new EIBA.Interop.Falcon.IClientGroupDataEvent_GroupDataIndicationWriteEventHandler(OnGroupDataIndicationWrite);
                        _ptrGroupData.GroupDataConfirmationWrite -= new EIBA.Interop.Falcon.IClientGroupDataEvent_GroupDataConfirmationWriteEventHandler(OnGroupDataConfirmationWrite);
                        _ptrGroupData.GroupDataIndicationResponse -= new EIBA.Interop.Falcon.IClientGroupDataEvent_GroupDataIndicationResponseEventHandler(OnGroupDataIndicationResponse);
                        _ptrGroupData.GroupDataConfirmationResponse -= new EIBA.Interop.Falcon.IClientGroupDataEvent_GroupDataConfirmationResponseEventHandler(OnGroupDataConfirmationResponse);
                        _ptrGroupData.Status -= new EIBA.Interop.Falcon.IClientGroupDataEvent_StatusEventHandler(OnStatus);
                    }
                    // close connection
                    _ptrConfirmedGroupData = null;
                    _ptrGroupData = null;
                    _ptrGroupDataTransfer = null;

                    loggingBox.AppendText("Group data connect closed!\r\n");

                    selectKNXInterface.Text = "Connect Interface";
                    selectKNXInterface.Tag = false;
                } else {
                    // 未连接，执行连接操作
                    EIBA.Interop.Falcon.IConnectionCustom ptrConnection;
                    EIBA.Interop.Falcon.DeviceOpenError eDevOpenError;

                    //create a connection & a groupdata object
                    ptrConnection = CreateConnection();

                    // show connection manager to get parameter
                    if (!OpenFalconConnectionManager()) return;

                    // confirmed group data or not
                    if (MessageBox.Show("Confirmed group data?", Text, MessageBoxButtons.YesNo) == DialogResult.Yes) {
                        // create instance of ConfirmedGroupData coclass
                        _ptrConfirmedGroupData = new EIBA.Interop.Falcon.ConfirmedGroupDataClass();
                        _ptrGroupDataTransfer = (EIBA.Interop.Falcon.IGroupDataTransfer)_ptrConfirmedGroupData;

                        _ptrConfirmedGroupData.GroupDataIndicationRead += new EIBA.Interop.Falcon.IClientGroupDataEvent_GroupDataIndicationReadEventHandler(OnGroupDataIndicationRead);
                        _ptrConfirmedGroupData.GroupDataIndicationResponse += new EIBA.Interop.Falcon.IClientGroupDataEvent_GroupDataIndicationResponseEventHandler(OnGroupDataIndicationResponse);
                        _ptrConfirmedGroupData.GroupDataIndicationWrite += new EIBA.Interop.Falcon.IClientGroupDataEvent_GroupDataIndicationWriteEventHandler(OnGroupDataIndicationWrite);
                        _ptrConfirmedGroupData.GroupDataConfirmationRead += new EIBA.Interop.Falcon.IClientGroupDataEvent_GroupDataConfirmationReadEventHandler(OnGroupDataConfirmationRead);
                        _ptrConfirmedGroupData.GroupDataConfirmationResponse += new EIBA.Interop.Falcon.IClientGroupDataEvent_GroupDataConfirmationResponseEventHandler(OnGroupDataConfirmationResponse);
                        _ptrConfirmedGroupData.GroupDataConfirmationWrite += new EIBA.Interop.Falcon.IClientGroupDataEvent_GroupDataConfirmationWriteEventHandler(OnGroupDataConfirmationWrite);
                        _ptrConfirmedGroupData.Status += new EIBA.Interop.Falcon.IClientGroupDataEvent_StatusEventHandler(OnStatus);

                    } else {
                        // create instance of GroupData coclass
                        _ptrGroupData = new EIBA.Interop.Falcon.GroupDataClass();
                        _ptrGroupDataTransfer = (EIBA.Interop.Falcon.IGroupDataTransfer)_ptrGroupData;

                        _ptrGroupData.GroupDataIndicationRead += new EIBA.Interop.Falcon.IClientGroupDataEvent_GroupDataIndicationReadEventHandler(OnGroupDataIndicationRead);
                        _ptrGroupData.GroupDataIndicationResponse += new EIBA.Interop.Falcon.IClientGroupDataEvent_GroupDataIndicationResponseEventHandler(OnGroupDataIndicationResponse);
                        _ptrGroupData.GroupDataIndicationWrite += new EIBA.Interop.Falcon.IClientGroupDataEvent_GroupDataIndicationWriteEventHandler(OnGroupDataIndicationWrite);
                        _ptrGroupData.GroupDataConfirmationRead += new EIBA.Interop.Falcon.IClientGroupDataEvent_GroupDataConfirmationReadEventHandler(OnGroupDataConfirmationRead);
                        _ptrGroupData.GroupDataConfirmationResponse += new EIBA.Interop.Falcon.IClientGroupDataEvent_GroupDataConfirmationResponseEventHandler(OnGroupDataConfirmationResponse);
                        _ptrGroupData.GroupDataConfirmationWrite += new EIBA.Interop.Falcon.IClientGroupDataEvent_GroupDataConfirmationWriteEventHandler(OnGroupDataConfirmationWrite);
                        _ptrGroupData.Status += new EIBA.Interop.Falcon.IClientGroupDataEvent_StatusEventHandler(OnStatus);
                    }

                    //set the connection mode
                    ptrConnection.Mode = EIBA.Interop.Falcon.ConnectionMode.ConnectionModeRemoteConnectionless;

                    // open connection to bus
                    object objPara = _sConnectionParameter;

                    eDevOpenError = ptrConnection.Open2(m_guidEdi, objPara);
                    if (eDevOpenError != EIBA.Interop.Falcon.DeviceOpenError.DeviceOpenErrorNoError) {
                        loggingBox.AppendText("error opening group data connection!\r\n");
                        //MessageBox.Show("error opening group data connection");
                        _ptrGroupDataTransfer = null;
                        return;
                    }
                    //set the connection for the groupdata object 
                    _ptrGroupDataTransfer.Connection = (EIBA.Interop.Falcon.IConnection)ptrConnection;

                    loggingBox.AppendText("Group data connect opened!\r\n");

                    selectKNXInterface.Text = "Disconnect Interface";
                    selectKNXInterface.Tag = true;
                }
            } catch (Exception ex) {
                loggingBox.AppendText("ERROR:" + ex.ToString() + "\r\n");
                _ptrGroupDataTransfer = null;
            }
        }

        EIBA.Interop.Falcon.IConnectionCustom CreateConnection() {
            EIBA.Interop.Falcon.IConnectionCustom ptrConnection;
            try {
                string sLicKey = "Demo" + DateTime.Now.Ticks;
                // get the class factory object
                EIBA.Interop.Falcon.ClassCreatorClass cc = new EIBA.Interop.Falcon.ClassCreatorClass();
                ptrConnection = (EIBA.Interop.Falcon.IConnectionCustom)cc.CreateInstanceLic("Falcon.ConnectionObject",
                  EIBA.Interop.Falcon.tagCLSCTX.CLSCTX_LOCAL_SERVER, "", sLicKey);
            } catch (Exception ex) {
                //MessageBox.Show("CreateConnection: " + ex.Message);
                loggingBox.AppendText("CreateConnection: " + ex.Message + "\r\n");
                return null;
            }
            return ptrConnection;
        }

        public bool OpenFalconConnectionManager() {
            EIBA.Interop.Falcon.IConnectionManager ptrConnectionManager = null;
            try {
                ptrConnectionManager = new EIBA.Interop.Falcon.ConnectionManagerClass();
                bool bSuccess = false;
                //show connection manager
                EIBA.Interop.Falcon.FalconConnection pfcConnection;
                pfcConnection = ptrConnectionManager.GetConnection("", 1);

                // get connection parameter
                if ((pfcConnection.Parameters != null) && (pfcConnection.Parameters != "")) {
                    _sConnectionParameter = pfcConnection.Parameters;
                    m_guidEdi = pfcConnection.guidEdi;

                    bSuccess = true;
                }
                return bSuccess;
            } catch (Exception ex) {
                //MessageBox.Show("OpenFalconConnectionManager: " + ex.Message);
                loggingBox.AppendText("OpenFalconConnectionManager: " + ex.Message + "\r\n");
                if (ptrConnectionManager != null) {
                    ptrConnectionManager = null;
                }
                return false;
            }
        }

        private void knxGroupDataWrite_Click(object sender, EventArgs e) {
            try {
                if (_ptrGroupDataTransfer != null) {
                    GroupDataWriteDlg dlgWrite;
                    dlgWrite = new GroupDataWriteDlg();

                    //set last inserted values
                    dlgWrite._nPriority = _nGroupDataWritePriority;
                    dlgWrite._nRoutingCount = _nGroupDataWriteRoutingCount;
                    dlgWrite._sData = _sGroupDataWriteData;
                    dlgWrite._sGroupAddress = _sGroupDataWriteGroupAddress;
                    dlgWrite._bLessthan7bits = _bGroupDataWriteLessthan7bits;

                    if (dlgWrite.ShowDialog() == DialogResult.OK) {
                        //get inserted values
                        _nGroupDataWritePriority = dlgWrite._nPriority;
                        _nGroupDataWriteRoutingCount = dlgWrite._nRoutingCount;
                        _sGroupDataWriteData = dlgWrite._sData;
                        _sGroupDataWriteGroupAddress = dlgWrite._sGroupAddress;
                        _bGroupDataWriteLessthan7bits = dlgWrite._bLessthan7bits;

                        EIBA.Interop.Falcon.DeviceWriteError eError;
                        eError = _ptrGroupDataTransfer.Write((object)dlgWrite._sGroupAddress,
                          (EIBA.Interop.Falcon.Priority)dlgWrite._nPriority,
                          dlgWrite._nRoutingCount,
                          dlgWrite._bLessthan7bits ? true : false,
                          (object)dlgWrite._sData);

                        // extended error information
                        if (eError != EIBA.Interop.Falcon.DeviceWriteError.DeviceWriteErrorNoError) {
                            // error message
                            loggingBox.AppendText("knxGroupDataWrite_Click: error, group data write error\r\n");
                            //MessageBox.Show("knxGroupDataWrite_Click: error, group data write error");
                        }
                    }
                } else {
                    loggingBox.AppendText("knxGroupDataWrite_Click: error, No Interface Selected!\r\n");
                    //MessageBox.Show("knxGroupDataWrite_Click: error, No Interface Selected!\r\n");
                }
            } catch (Exception ex) {
                loggingBox.AppendText("knxGroupDataWrite_Click: error, Error write group address!" + ex.Message + "\r\n");
                //MessageBox.Show("knxGroupDataWrite_Click: error, Error write group address!" + ex.Message);
            }
        }

        private void knxGroupDataRead_Click(object sender, EventArgs e) {
            try {
                if (_ptrGroupDataTransfer != null) {
                    GroupDataReadDlg dlgRead;
                    dlgRead = new GroupDataReadDlg();

                    //set last inserted values
                    dlgRead._nPriority = _nGroupDataReadPriority;
                    dlgRead._nRoutingCount = _nGroupDataReadRoutingCount;
                    dlgRead._sGroupAddress = _sGroupDataReadGroupAddress;

                    if (dlgRead.ShowDialog() == DialogResult.OK) {
                        //get values
                        _nGroupDataReadPriority = dlgRead._nPriority;
                        _nGroupDataReadRoutingCount = dlgRead._nRoutingCount;
                        _sGroupDataReadGroupAddress = dlgRead._sGroupAddress;

                        EIBA.Interop.Falcon.DeviceWriteError Error;
                        Error = _ptrGroupDataTransfer.Read((object)dlgRead._sGroupAddress,
                          (EIBA.Interop.Falcon.Priority)dlgRead._nPriority,
                          dlgRead._nRoutingCount);

                        // extended error information
                        if (Error != EIBA.Interop.Falcon.DeviceWriteError.DeviceWriteErrorNoError) {
                            loggingBox.AppendText("knxGroupDataRead_Click: error: Group data read failed!\r\n");
                            //MessageBox.Show("knxGroupDataRead_Click: error: Group data read failed!");
                        }
                    }
                } else {
                    loggingBox.AppendText("knxGroupDataRead_Click: error: No Interface Selected!\r\n");
                    //MessageBox.Show("knxGroupDataRead_Click: error: No Interface Selected!\r\n");
                }
            } catch (Exception ex) {
                loggingBox.AppendText("knxGroupDataRead_Click: error: Group data read failed!" + ex.Message + "\r\n");
                //MessageBox.Show("knxGroupDataRead_Click: error: Group data read failed!" + ex.Message);
            }
        }

        private void clearLoggingBox_Click(object sender, EventArgs e) {
            loggingBox.Clear();
        }


        /// <summary>
        /// KNX Interface Event Handler: GroupData Indication Read
        /// </summary>
        /// <param name="GroupAddress"></param>
        /// <param name="RoutingCnt"></param>
        /// <param name="Prio"></param>
        /// <param name="Data"></param>
        protected virtual void OnGroupDataIndicationRead(int GroupAddress, int RoutingCnt, EIBA.Interop.Falcon.Priority Prio, object Data) {
            try {
                string sText;
                sText = "GroupDataIndicationRead:\r\nGroupAddress = 0x";
                sText += GroupAddress.ToString("X");
                sText += ", RoutingCnt = ";
                sText += RoutingCnt;
                sText += ", Priority = ";
                sText += objFalconDemoHelper.GetBusPriorityText(Prio);
                loggingBox.Invoke(new Action<string>(loggingBox.AppendText), new object[] { sText + "\r\n" });
            } catch (Exception ex) {
                loggingBox.Invoke(new Action<string>(loggingBox.AppendText), new object[] { ex.Message + "\r\n" });
            }
        }

        /// <summary>
        /// KNX Interface Event Handler: GroupData Indication Response
        /// </summary>
        /// <param name="GroupAddress"></param>
        /// <param name="RoutingCnt"></param>
        /// <param name="Prio"></param>
        /// <param name="Data"></param>
        protected virtual void OnGroupDataIndicationResponse(int GroupAddress,
                                                          int RoutingCnt,
                                                          EIBA.Interop.Falcon.Priority Prio,
                                                          object Data) {
            try {
                string sText;
                sText = "GroupDataIndicationResponse:\r\nGroupAddress = 0x";
                sText += GroupAddress.ToString("X");
                sText += ", RoutingCnt = ";
                sText += RoutingCnt;
                sText += ", Priority = ";
                sText += objFalconDemoHelper.GetBusPriorityText(Prio);
                // output data
                sText += ", Data = ";
                System.Array arrData;
                arrData = (System.Array)Data;
                for (int i = 0; i < arrData.GetLength(0); i++) {
                    int nVal = Convert.ToInt32(arrData.GetValue(i));
                    sText += "0x";
                    sText += nVal.ToString("X");
                    //sText += arrData.GetValue(i).ToString();
                    sText += " ";
                }
                loggingBox.Invoke(new Action<string>(loggingBox.AppendText), new object[] { sText + "\r\n" });
            } catch (Exception ex) {
                loggingBox.Invoke(new Action<string>(loggingBox.AppendText), new object[] { ex.Message + "\r\n" });
            }
        }
        /// <summary>
        /// KNX Interface Event Handler: GroupData Indication Write
        /// </summary>
        /// <param name="GroupAddress"></param>
        /// <param name="RoutingCnt"></param>
        /// <param name="Prio"></param>
        /// <param name="Data"></param>
        protected virtual void OnGroupDataIndicationWrite(int GroupAddress,
                                                       int RoutingCnt,
                                                       EIBA.Interop.Falcon.Priority Prio,
                                                       object Data) {
            try {
                string sText;
                sText = "GroupDataIndicationWrite:\r\nGroupAddress = 0x";
                sText += GroupAddress.ToString("X");
                sText += ", RoutingCnt = ";
                sText += RoutingCnt;
                sText += ", Priority = ";
                sText += objFalconDemoHelper.GetBusPriorityText(Prio);
                // output data
                sText += ", Data = ";
                System.Array arrData;
                arrData = (System.Array)Data;
                for (int i = 0; i < arrData.GetLength(0); i++) {
                    int nVal = Convert.ToInt32(arrData.GetValue(i));
                    sText += "0x";
                    sText += nVal.ToString("X");
                    sText += " ";

                    try {
                        string sn = AgilorSourceNameAndKNXGroupAddressConvert.getSourceNameByGroupAddress("0x"+GroupAddress.ToString("X"), agilorConnectDeviceName.Text);

                        foreach (var device in rtdbs)
                        {
                            if (device.Value.WriteValue(new Agilor.Interface.Val.Value(sn, nVal)))
                            {
                                break;
                            }
                        }

                        //rtdb.WriteValue(new Agilor.Interface.Val.Value(sn, nVal));
                    } catch (Exception ex) {
                        loggingBox.Invoke(new Action<string>(loggingBox.AppendText), new object[] { ex.Message + "\r\n" });
                    }
                }
                loggingBox.Invoke(new Action<string>(loggingBox.AppendText), new object[] { sText + "\r\n" });
            } catch (Exception ex) {
                loggingBox.Invoke(new Action<string>(loggingBox.AppendText), new object[] { ex.Message + "\r\n" });
            }
        }
        /// <summary>
        /// KNX Interface Event Handler: GroupData Confirmation Write
        /// </summary>
        /// <param name="GroupAddress"></param>
        /// <param name="RoutingCnt"></param>
        /// <param name="Prio"></param>
        /// <param name="bError"></param>
        /// <param name="Data"></param>
        protected virtual void OnGroupDataConfirmationWrite(int GroupAddress,
                                                         int RoutingCnt,
                                                         EIBA.Interop.Falcon.Priority Prio,
                                                         bool bError, object Data) {
            try {
                string sText;
                sText = "GroupDataConfirmationWrite:\r\nGroupAddress = 0x";
                sText += GroupAddress.ToString("X");
                sText += ", RoutingCnt = ";
                sText += RoutingCnt;
                sText += ", Priority = ";
                sText += objFalconDemoHelper.GetBusPriorityText(Prio);
                // output data
                sText += ", Data = ";
                System.Array arrData;
                arrData = (System.Array)Data;
                for (int i = 0; i < arrData.GetLength(0); i++) {
                    int nVal = Convert.ToInt32(arrData.GetValue(i));
                    sText += "0x";
                    sText += nVal.ToString("X");
                    sText += " ";

                    try {
                        string sn = AgilorSourceNameAndKNXGroupAddressConvert.getSourceNameByGroupAddress("0x" + GroupAddress.ToString("X"), agilorConnectDeviceName.Text);

                        foreach (var device in rtdbs)
                        {
                            if (device.Value.WriteValue(new Agilor.Interface.Val.Value(sn, nVal)))
                            {
                                break;
                            }
                        }

                        //rtdb.WriteValue(new Agilor.Interface.Val.Value(sn, nVal));
                    } catch (Exception ex) {
                        loggingBox.Invoke(new Action<string>(loggingBox.AppendText), new object[] { ex.Message + "\r\n" });
                    }
                }
                loggingBox.Invoke(new Action<string>(loggingBox.AppendText), new object[] { sText + "\r\n" });
            } catch (Exception ex) {
                loggingBox.Invoke(new Action<string>(loggingBox.AppendText), new object[] { ex.Message + "\r\n" });
            }
        }
        /// <summary>
        /// KNX Interface Event Handler: GroupData Confirmation Read
        /// </summary>
        /// <param name="GroupAddress"></param>
        /// <param name="RoutingCnt"></param>
        /// <param name="Prio"></param>
        /// <param name="bError"></param>
        /// <param name="Data"></param>
        protected virtual void OnGroupDataConfirmationRead(int GroupAddress,
                                                        int RoutingCnt,
                                                        EIBA.Interop.Falcon.Priority Prio,
                                                        bool bError,
                                                        object Data) {
            try {
                string sText;
                sText = "GroupDataConfirmationRead:\r\nGroupAddress = 0x";
                sText += GroupAddress.ToString("X");
                sText += ", RoutingCnt = ";
                sText += RoutingCnt;
                sText += ", Priority = ";
                sText += objFalconDemoHelper.GetBusPriorityText(Prio);
                sText += ", Error = ";
                sText += bError;
                loggingBox.Invoke(new Action<string>(loggingBox.AppendText), new object[] { sText + "\r\n" });
            } catch (Exception ex) {
                // show error
                loggingBox.Invoke(new Action<string>(loggingBox.AppendText), new object[] { ex.Message + "\r\n" });
            }
        }
        /// <summary>
        /// KNX Interface Event Handler: GroupData Confirmation Response
        /// </summary>
        /// <param name="GroupAddress"></param>
        /// <param name="RoutingCnt"></param>
        /// <param name="Prio"></param>
        /// <param name="bError"></param>
        /// <param name="Data"></param>
        protected virtual void OnGroupDataConfirmationResponse(int GroupAddress,
                                                            int RoutingCnt,
                                                            EIBA.Interop.Falcon.Priority Prio,
                                                            bool bError,
                                                            object Data) {
            try {
                string sText;
                sText = "GroupDataConfirmationResponse:\r\nGroupAddress = 0x";
                sText += GroupAddress.ToString("X");        // format to hex
                sText += ", RoutingCnt = ";
                sText += RoutingCnt;
                sText += ", Priority = ";
                sText += objFalconDemoHelper.GetBusPriorityText(Prio);
                // output data
                sText += ", Data = ";
                System.Array arrData;
                arrData = (System.Array)Data;         // get array from object
                for (int i = 0; i < arrData.GetLength(0); i++) {
                    sText += arrData.GetValue(i).ToString();
                    sText += " ";
                }
                loggingBox.Invoke(new Action<string>(loggingBox.AppendText), new object[] { sText + "\r\n" });
            } catch (Exception ex) {
                loggingBox.Invoke(new Action<string>(loggingBox.AppendText), new object[] { ex.Message + "\r\n" });
            }
        }
        /// <summary>
        /// KNX Interface Event Handler: Status Changes
        /// </summary>
        /// <param name="MsgType"></param>
        /// <param name="Data"></param>
        protected virtual void OnStatus(EIBA.Interop.Falcon.InternalMessageType MsgType, int Data) {
            string sText;
            sText = "Status:\r\n";
            try {
                switch (MsgType) {
                    case EIBA.Interop.Falcon.InternalMessageType.InternalMessageTypeBcuResetReceived:
                        sText += "BcuResetReceived";
                        break;
                    case EIBA.Interop.Falcon.InternalMessageType.InternalMessageTypeReinitializeBcu:
                        sText += "ReinitializeBcu";
                        break;
                    case EIBA.Interop.Falcon.InternalMessageType.InternalMessageTypeLifeTimeInfo:
                        sText += "LifeTimeInfo";
                        break;
                    case EIBA.Interop.Falcon.InternalMessageType.InternalMessageQueueOverflow:
                        sText += "QueueOverflow";
                        break;
                }
                // output data
                sText += ", Data = ";
                sText += Data.ToString("X");

                loggingBox.Invoke(new Action<string>(loggingBox.AppendText), new object[] { sText + "\r\n" });
            } catch (Exception ex) {
                loggingBox.Invoke(new Action<string>(loggingBox.AppendText), new object[] { "OnStatus: Error getting status from Falcon" + ex.Message + "\r\n" });
                //MessageBox.Show("OnStatus: Error getting status from Falcon" + ex.Message);
            }
        }

        private void linkLabel_writeConfig_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            try {
                KNXWriteConfig knxWrite = new KNXWriteConfig();
                if (knxWrite.ShowDialog() == DialogResult.OK) {
                    //get inserted values
                    _nGroupDataWritePriority_config = knxWrite._nPriority;
                    _nGroupDataWriteRoutingCount_config = knxWrite._nRoutingCount;
                    _bGroupDataWriteLessthan7bits_config = knxWrite._bLessthan7bits;
                }
            } catch (Exception ex) {
                loggingBox.AppendText("linkLabel_writeConfig_LinkClicked: Error write config!" + ex.Message);
                //MessageBox.Show("linkLabel_writeConfig_LinkClicked: Error write config!" + ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e) {
            ReloadConfigFile();
        }

        public static void ReloadConfigFile() {
            if (!File.Exists("KNXWriteConfig.config")) {
                FileStream fs = null;
                StreamWriter sw = null;
                try {
                    fs = new FileStream("KNXWriteConfig.config", FileMode.OpenOrCreate);
                    sw = new StreamWriter(fs);

                    sw.WriteLine("_nPriority:3");
                    sw.WriteLine("_nRoutingCount:6");
                    sw.WriteLine("_bLessthan7bits:false");

                } catch (Exception ex) {
                    MessageBox.Show("ReloadConfigFile: 初始化配置文件失败:" + ex.ToString());
                }
                finally {
                    if (sw != null) sw.Close();
                    if (fs != null) fs.Close();
                }
            } else {
                FileStream fs = null;
                StreamReader sr = null;
                try {
                    fs = new FileStream("KNXWriteConfig.config", FileMode.Open);
                    sr = new StreamReader(fs);

                    _nGroupDataWritePriority_config = int.Parse(sr.ReadLine().Split(':')[1]);
                    _nGroupDataWriteRoutingCount_config = int.Parse(sr.ReadLine().Split(':')[1]);
                    _bGroupDataWriteLessthan7bits_config = bool.Parse(sr.ReadLine().Split(':')[1]);

                } catch (Exception ex) {
                    MessageBox.Show("ReloadConfigFile :读取配置失败:" + ex.ToString());
                } finally {
                    if (sr != null) sr.Close();
                    if (fs != null) fs.Close();
                }
            }
        }

        private void kNXWriteConfigurationToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                KNXWriteConfig knxWrite = new KNXWriteConfig();
                if (knxWrite.ShowDialog() == DialogResult.OK) {
                    //get inserted values
                    _nGroupDataWritePriority_config = knxWrite._nPriority;
                    _nGroupDataWriteRoutingCount_config = knxWrite._nRoutingCount;
                    _bGroupDataWriteLessthan7bits_config = knxWrite._bLessthan7bits;
                }
            } catch (Exception ex) {
                loggingBox.AppendText("kNXWriteConfigurationToolStripMenuItem_Click: Error write config!" + ex.Message + "\r\n");
                //MessageBox.Show("kNXWriteConfigurationToolStripMenuItem_Click: Error write config!" + ex.Message);
            }
        }

        private void sourcenameGroupAddressToolStripMenuItem_Click(object sender, EventArgs e) {
            new SourcenameToGroupAddress().Show();
        }

        private void connectAgilorDBACI_Click(object sender, EventArgs e)
        {
            try
            {
                if ((bool)connectAgilorDBACI.Tag)
                {
                    // 已经连接 Agilor
                    if (aci != null) aci.Close();
                    aci = null;

                    connectAgilorDBACI.Text = "ACI-Connect";
                    loggingBox.AppendText("Agilor ACI Disconnect Success." + "\r\n");
                    connectAgilorDBACI.Tag = false;
                }
                else
                {
                    // 未连接 Agilor
                    aci = ACI.Instance("READWRITETARGET", agilorConnectIP.Text);

                    connectAgilorDBACI.Text = "ACI-Disconnect";
                    loggingBox.AppendText("Agilor ACI Connect Success." + "\r\n");
                    connectAgilorDBACI.Tag = true;
                }
            }
            catch (Exception ex)
            {
                loggingBox.AppendText("ERROR:" + ex.ToString() + "\r\n");
            }
        }

        private void loggingBox_TextChanged(object sender, EventArgs e)
        {
            if (loggingBox.TextLength > 1000) loggingBox.Clear();
        }

        private void disconnectAgilorDB_Click(object sender, EventArgs e)
        {
            if (rtdbs.ContainsKey(agilorConnectDeviceName.Text))
            {
                rtdbs[agilorConnectDeviceName.Text].ValueReceived -= Rtdb_ValueReceived;
                rtdbs[agilorConnectDeviceName.Text].Close();
                rtdbs.Remove(agilorConnectDeviceName.Text);

                less7bitsFlag.Remove(agilorConnectDeviceName.Text);

                loggingBox.AppendText("Disconnet Device: '" + agilorConnectDeviceName.Text + "' finished.\r\n");
            } else
            {
                //MessageBox.Show("Device: '" + agilorConnectDeviceName.Text + "' not connected!\r\n");
                loggingBox.AppendText("Device: '" + agilorConnectDeviceName.Text + "' not connected!\r\n");
                return;
            }
        }

        private void disconnectAgilorDBALL_Click(object sender, EventArgs e)
        {
            foreach (var device in rtdbs)
            {
                device.Value.ValueReceived -= Rtdb_ValueReceived;
                device.Value.Close();
                loggingBox.AppendText("Disconnet device '" + device.Key +  "' finished.\r\n");
            }
            rtdbs.Clear();

            less7bitsFlag.Clear();

            loggingBox.AppendText("Disconnet all device finished.\r\n");
        }
    }
}
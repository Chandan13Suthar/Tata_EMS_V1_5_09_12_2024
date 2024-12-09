#region Using directives
using System;
using UAManagedCore;
using OpcUa = UAManagedCore.OpcUa;
using FTOptix.UI;
using FTOptix.NativeUI;
using FTOptix.HMIProject;
using FTOptix.CoreBase;
using FTOptix.NetLogic;
using FTOptix.WebUI;
using FTOptix.EventLogger;
using FTOptix.DataLogger;
using FTOptix.SQLiteStore;
using FTOptix.Store;
using FTOptix.ODBCStore;
using FTOptix.Report;
using FTOptix.MicroController;
using FTOptix.Retentivity;
using FTOptix.Alarm;
using FTOptix.CommunicationDriver;
using FTOptix.AuditSigning;
using FTOptix.Core;
using Store = FTOptix.Store;
#endregion

public class compressor : BaseNetLogic
{
    public override void Start()
    {
        // Insert code to be executed when the user-defined logic is started
    }

    public override void Stop()
    {
        // Insert code to be executed when the user-defined logic is stopped
    }



    [ExportMethod]
    public void compressorcalculation()
    {
        DateTime Time = Project.Current.GetVariable("Model/Compressor/Date").Value;
        int shift = Project.Current.GetVariable("Model/Compressor/Shift").Value;
        // string meter = Project.Current.GetVariable("Model/Compressor/Compressor_Name").Value;
        Int32 value1 = 0;
        Int32 value2 = 0;
        Int32 value3 = 0;
        Int32 value4 = 0;
        Int32 value5 = 0;
        Int32 value6 = 0;
        Int32 value7 = 0;
        Int32 value8 = 0;
        Int32 value9 = 0;
        Int32 value10 = 0;
        Int32 value11 = 0;
        Int32 value12 = 0;


        string new123 = Time.ToString("yyyy-MM-dd");
        string new321 = Time.AddDays(1).ToString("yyyy-MM-dd");


        var project = FTOptix.HMIProject.Project.Current;
        var myStore = project.GetObject("DataStores").Get<Store.Store>("ODBCDatabase");

        if (shift == 0)
        {
            myStore.Query("SELECT MAX(Active_Energy_Total) FROM MeterDataView WHERE LocalTimestamp  BETWEEN '" + new123 + " 04:45:00' AND '" + new123 + " 06:45:00' AND Meter = 'J2_MCB_MVS_02_O/G_F6' ", out string[] header2, out object[,] resultSet2);
            myStore.Query("SELECT MIN(Active_Energy_Total) FROM MeterDataView WHERE LocalTimestamp  BETWEEN '" + new123 + " 04:45:00' AND '" + new123 + " 06:45:00' AND Meter = 'J2_MCB_MVS_02_O/G_F6' ", out string[] header3, out object[,] resultSet3);
            myStore.Query("SELECT MAX(Active_Energy_Total) FROM MeterDataView WHERE LocalTimestamp  BETWEEN '" + new123 + " 04:45:00' AND '" + new123 + " 06:45:00' AND Meter = 'J2_MCB_SWB_02_O/G_2F2' ", out string[] header4, out object[,] resultSet4);
            myStore.Query("SELECT MIN(Active_Energy_Total) FROM MeterDataView WHERE LocalTimestamp  BETWEEN '" + new123 + " 04:45:00' AND '" + new123 + " 06:45:00' AND Meter = 'J2_MCB_SWB_02_O/G_2F2' ", out string[] header5, out object[,] resultSet5);
            myStore.Query("SELECT MAX(Active_Energy_Total) FROM MeterDataView WHERE LocalTimestamp  BETWEEN '" + new123 + " 04:45:00' AND '" + new123 + " 06:45:00' AND Meter = 'J2_MCB_SWB_02_O/G_5F1' ", out string[] header6, out object[,] resultSet6);
            myStore.Query("SELECT MIN(Active_Energy_Total) FROM MeterDataView WHERE LocalTimestamp  BETWEEN '" + new123 + " 04:45:00' AND '" + new123 + " 06:45:00' AND Meter = 'J2_MCB_SWB_02_O/G_5F1' ", out string[] header7, out object[,] resultSet7);
            myStore.Query("SELECT MAX(Active_Energy_Total) FROM MeterDataView WHERE LocalTimestamp  BETWEEN '" + new123 + " 04:45:00' AND '" + new123 + " 06:45:00' AND Meter = 'J2_MCB_SWB_02_O/G_2F1' ", out string[] header8, out object[,] resultSet8);
            myStore.Query("SELECT MIN(Active_Energy_Total) FROM MeterDataView WHERE LocalTimestamp  BETWEEN '" + new123 + " 04:45:00' AND '" + new123 + " 06:45:00' AND Meter = 'J2_MCB_SWB_02_O/G_2F1' ", out string[] header9, out object[,] resultSet9);
            myStore.Query("SELECT MAX(Active_Energy_Total) FROM MeterDataView WHERE LocalTimestamp  BETWEEN '" + new123 + " 04:45:00' AND '" + new123 + " 06:45:00' AND Meter = 'J2_MCB_MVS_03_O/G_F4' ", out string[] header10, out object[,] resultSet10);
            myStore.Query("SELECT MIN(Active_Energy_Total) FROM MeterDataView WHERE LocalTimestamp  BETWEEN '" + new123 + " 04:45:00' AND '" + new123 + " 06:45:00' AND Meter = 'J2_MCB_MVS_03_O/G_F4' ", out string[] header11, out object[,] resultSet11);
            myStore.Query("SELECT MAX(Active_Energy_Total) FROM MeterDataView WHERE LocalTimestamp  BETWEEN '" + new123 + " 04:45:00' AND '" + new123 + " 06:45:00' AND Meter = 'J2_MCB_MVS_03_O/G_F5' ", out string[] header12, out object[,] resultSet12);
            myStore.Query("SELECT MIN(Active_Energy_Total) FROM MeterDataView WHERE LocalTimestamp  BETWEEN '" + new123 + " 04:45:00' AND '" + new123 + " 06:45:00' AND Meter = 'J2_MCB_MVS_03_O/G_F5' ", out string[] header13, out object[,] resultSet13);





            if (resultSet2?.GetLength(0) > 0 && header2?.Length > 0)
            {
                value1 = Convert.ToInt32(resultSet2[0, 0]);
            }
            if (resultSet3?.GetLength(0) > 0 && header3?.Length > 0)
            {
                value2 = Convert.ToInt32(resultSet3[0, 0]);
            }
            if (resultSet4?.GetLength(0) > 0 && header4?.Length > 0)
            {
                value3 = Convert.ToInt32(resultSet4[0, 0]);
            }
            if (resultSet5?.GetLength(0) > 0 && header5?.Length > 0)
            {
                value4 = Convert.ToInt32(resultSet5[0, 0]);
            }
            if (resultSet6?.GetLength(0) > 0 && header6?.Length > 0)
            {
                value5 = Convert.ToInt32(resultSet6[0, 0]);
            }
            if (resultSet7?.GetLength(0) > 0 && header7?.Length > 0)
            {
                value6 = Convert.ToInt32(resultSet7[0, 0]);
            }

            if (resultSet8?.GetLength(0) > 0 && header8?.Length > 0)
            {
                value7 = Convert.ToInt32(resultSet8[0, 0]);
            }
            if (resultSet9?.GetLength(0) > 0 && header9?.Length > 0)
            {
                value8 = Convert.ToInt32(resultSet9[0, 0]);
            }

            if (resultSet10?.GetLength(0) > 0 && header10?.Length > 0)
            {
                value9 = Convert.ToInt32(resultSet10[0, 0]);
            }
            if (resultSet11?.GetLength(0) > 0 && header11?.Length > 0)
            {
                value10 = Convert.ToInt32(resultSet11[0, 0]);
            }

            if (resultSet12?.GetLength(0) > 0 && header12?.Length > 0)
            {
                value11 = Convert.ToInt32(resultSet12[0, 0]);
            }
            if (resultSet13?.GetLength(0) > 0 && header13?.Length > 0)
            {
                value12 = Convert.ToInt32(resultSet13[0, 0]);
            }


        }
        else if (shift == 1)


        {

            myStore.Query("SELECT MAX(Active_Energy_Total) FROM MeterDataView WHERE LocalTimestamp  BETWEEN '" + new123 + " 12:45:00' AND '" + new123 + " 14:00:00' AND Meter = 'J2_MCB_MVS_02_O/G_F6' ", out string[] header2, out object[,] resultSet2);
            myStore.Query("SELECT MIN(Active_Energy_Total) FROM MeterDataView WHERE LocalTimestamp  BETWEEN '" + new123 + " 12:45:00' AND '" + new123 + " 14:00:00' AND Meter = 'J2_MCB_MVS_02_O/G_F6' ", out string[] header3, out object[,] resultSet3);
            myStore.Query("SELECT MAX(Active_Energy_Total) FROM MeterDataView WHERE LocalTimestamp  BETWEEN '" + new123 + " 12:45:00' AND '" + new123 + " 14:00:00' AND Meter = 'J2_MCB_SWB_02_O/G_2F2' ", out string[] header4, out object[,] resultSet4);
            myStore.Query("SELECT MIN(Active_Energy_Total) FROM MeterDataView WHERE LocalTimestamp  BETWEEN '" + new123 + " 12:45:00' AND '" + new123 + " 14:00:00' AND Meter = 'J2_MCB_SWB_02_O/G_2F2' ", out string[] header5, out object[,] resultSet5);
            myStore.Query("SELECT MAX(Active_Energy_Total) FROM MeterDataView WHERE LocalTimestamp  BETWEEN '" + new123 + " 12:45:00' AND '" + new123 + " 14:00:00' AND Meter = 'J2_MCB_SWB_02_O/G_5F1' ", out string[] header6, out object[,] resultSet6);
            myStore.Query("SELECT MIN(Active_Energy_Total) FROM MeterDataView WHERE LocalTimestamp  BETWEEN '" + new123 + " 12:45:00' AND '" + new123 + " 14:00:00' AND Meter = 'J2_MCB_SWB_02_O/G_5F1' ", out string[] header7, out object[,] resultSet7);
            myStore.Query("SELECT MAX(Active_Energy_Total) FROM MeterDataView WHERE LocalTimestamp  BETWEEN '" + new123 + " 12:45:00' AND '" + new123 + " 14:00:00' AND Meter = 'J2_MCB_SWB_02_O/G_2F1' ", out string[] header8, out object[,] resultSet8);
            myStore.Query("SELECT MIN(Active_Energy_Total) FROM MeterDataView WHERE LocalTimestamp  BETWEEN '" + new123 + " 12:45:00' AND '" + new123 + " 14:00:00' AND Meter = 'J2_MCB_SWB_02_O/G_2F1' ", out string[] header9, out object[,] resultSet9);
            myStore.Query("SELECT MAX(Active_Energy_Total) FROM MeterDataView WHERE LocalTimestamp  BETWEEN '" + new123 + " 12:45:00' AND '" + new123 + " 14:00:00' AND Meter = 'J2_MCB_MVS_03_O/G_F4' ", out string[] header10, out object[,] resultSet10);
            myStore.Query("SELECT MIN(Active_Energy_Total) FROM MeterDataView WHERE LocalTimestamp  BETWEEN '" + new123 + " 12:45:00' AND '" + new123 + " 14:00:00' AND Meter = 'J2_MCB_MVS_03_O/G_F4' ", out string[] header11, out object[,] resultSet11);
            myStore.Query("SELECT MAX(Active_Energy_Total) FROM MeterDataView WHERE LocalTimestamp  BETWEEN '" + new123 + " 12:45:00' AND '" + new123 + " 14:00:00' AND Meter = 'J2_MCB_MVS_03_O/G_F5' ", out string[] header12, out object[,] resultSet12);
            myStore.Query("SELECT MIN(Active_Energy_Total) FROM MeterDataView WHERE LocalTimestamp  BETWEEN '" + new123 + " 12:45:00' AND '" + new123 + " 14:00:00' AND Meter = 'J2_MCB_MVS_03_O/G_F5' ", out string[] header13, out object[,] resultSet13);





            if (resultSet2?.GetLength(0) > 0 && header2?.Length > 0)
            {
                value1 = Convert.ToInt32(resultSet2[0, 0]);
            }
            if (resultSet3?.GetLength(0) > 0 && header3?.Length > 0)
            {
                value2 = Convert.ToInt32(resultSet3[0, 0]);
            }
            if (resultSet4?.GetLength(0) > 0 && header4?.Length > 0)
            {
                value3 = Convert.ToInt32(resultSet4[0, 0]);
            }
            if (resultSet5?.GetLength(0) > 0 && header5?.Length > 0)
            {
                value4 = Convert.ToInt32(resultSet5[0, 0]);
            }
            if (resultSet6?.GetLength(0) > 0 && header6?.Length > 0)
            {
                value5 = Convert.ToInt32(resultSet6[0, 0]);
            }
            if (resultSet7?.GetLength(0) > 0 && header7?.Length > 0)
            {
                value6 = Convert.ToInt32(resultSet7[0, 0]);
            }

            if (resultSet8?.GetLength(0) > 0 && header8?.Length > 0)
            {
                value7 = Convert.ToInt32(resultSet8[0, 0]);
            }
            if (resultSet9?.GetLength(0) > 0 && header9?.Length > 0)
            {
                value8 = Convert.ToInt32(resultSet9[0, 0]);
            }

            if (resultSet10?.GetLength(0) > 0 && header10?.Length > 0)
            {
                value9 = Convert.ToInt32(resultSet10[0, 0]);
            }
            if (resultSet11?.GetLength(0) > 0 && header11?.Length > 0)
            {
                value10 = Convert.ToInt32(resultSet11[0, 0]);
            }

            if (resultSet12?.GetLength(0) > 0 && header12?.Length > 0)
            {
                value11 = Convert.ToInt32(resultSet12[0, 0]);
            }
            if (resultSet13?.GetLength(0) > 0 && header13?.Length > 0)
            {
                value12 = Convert.ToInt32(resultSet13[0, 0]);
            }






        }


        else if (shift == 2)


        {

            myStore.Query("SELECT MAX(Active_Energy_Total) FROM MeterDataView WHERE LocalTimestamp  BETWEEN '" + new123 + " 15:30:00' AND '" + new321 + " 00:15:00' AND Meter = 'J2_MCB_MVS_02_O/G_F6' ", out string[] header2, out object[,] resultSet2);
            myStore.Query("SELECT MIN(Active_Energy_Total) FROM MeterDataView WHERE LocalTimestamp  BETWEEN '" + new123 + " 15:30:00' AND '" + new321 + " 00:15:00' AND Meter = 'J2_MCB_MVS_02_O/G_F6' ", out string[] header3, out object[,] resultSet3);
            myStore.Query("SELECT MAX(Active_Energy_Total) FROM MeterDataView WHERE LocalTimestamp  BETWEEN '" + new123 + " 15:30:00' AND '" + new321 + " 00:15:00' AND Meter = 'J2_MCB_SWB_02_O/G_2F2' ", out string[] header4, out object[,] resultSet4);
            myStore.Query("SELECT MIN(Active_Energy_Total) FROM MeterDataView WHERE LocalTimestamp  BETWEEN '" + new123 + " 15:30:00' AND '" + new321 + " 00:15:00' AND Meter = 'J2_MCB_SWB_02_O/G_2F2' ", out string[] header5, out object[,] resultSet5);
            myStore.Query("SELECT MAX(Active_Energy_Total) FROM MeterDataView WHERE LocalTimestamp  BETWEEN '" + new123 + " 15:30:00' AND '" + new321 + " 00:15:00' AND Meter = 'J2_MCB_SWB_02_O/G_5F1' ", out string[] header6, out object[,] resultSet6);
            myStore.Query("SELECT MIN(Active_Energy_Total) FROM MeterDataView WHERE LocalTimestamp  BETWEEN '" + new123 + " 15:30:00' AND '" + new321 + " 00:15:00' AND Meter = 'J2_MCB_SWB_02_O/G_5F1' ", out string[] header7, out object[,] resultSet7);
            myStore.Query("SELECT MAX(Active_Energy_Total) FROM MeterDataView WHERE LocalTimestamp  BETWEEN '" + new123 + " 15:30:00' AND '" + new321 + " 00:15:00' AND Meter = 'J2_MCB_SWB_02_O/G_2F1' ", out string[] header8, out object[,] resultSet8);
            myStore.Query("SELECT MIN(Active_Energy_Total) FROM MeterDataView WHERE LocalTimestamp  BETWEEN '" + new123 + " 15:30:00' AND '" + new321 + " 00:15:00' AND Meter = 'J2_MCB_SWB_02_O/G_2F1' ", out string[] header9, out object[,] resultSet9);
            myStore.Query("SELECT MAX(Active_Energy_Total) FROM MeterDataView WHERE LocalTimestamp  BETWEEN '" + new123 + " 15:30:00' AND '" + new321 + " 00:15:00' AND Meter = 'J2_MCB_MVS_03_O/G_F4' ", out string[] header10, out object[,] resultSet10);
            myStore.Query("SELECT MIN(Active_Energy_Total) FROM MeterDataView WHERE LocalTimestamp  BETWEEN '" + new123 + " 15:30:00' AND '" + new321 + " 00:15:00' AND Meter = 'J2_MCB_MVS_03_O/G_F4' ", out string[] header11, out object[,] resultSet11);
            myStore.Query("SELECT MAX(Active_Energy_Total) FROM MeterDataView WHERE LocalTimestamp  BETWEEN '" + new123 + " 15:30:00' AND '" + new321 + " 00:15:00' AND Meter = 'J2_MCB_MVS_03_O/G_F5' ", out string[] header12, out object[,] resultSet12);
            myStore.Query("SELECT MIN(Active_Energy_Total) FROM MeterDataView WHERE LocalTimestamp  BETWEEN '" + new123 + " 15:30:00' AND '" + new321 + " 00:15:00' AND Meter = 'J2_MCB_MVS_03_O/G_F5' ", out string[] header13, out object[,] resultSet13);





            if (resultSet2?.GetLength(0) > 0 && header2?.Length > 0)
            {
                value1 = Convert.ToInt32(resultSet2[0, 0]);
            }
            if (resultSet3?.GetLength(0) > 0 && header3?.Length > 0)
            {
                value2 = Convert.ToInt32(resultSet3[0, 0]);
            }
            if (resultSet4?.GetLength(0) > 0 && header4?.Length > 0)
            {
                value3 = Convert.ToInt32(resultSet4[0, 0]);
            }
            if (resultSet5?.GetLength(0) > 0 && header5?.Length > 0)
            {
                value4 = Convert.ToInt32(resultSet5[0, 0]);
            }
            if (resultSet6?.GetLength(0) > 0 && header6?.Length > 0)
            {
                value5 = Convert.ToInt32(resultSet6[0, 0]);
            }
            if (resultSet7?.GetLength(0) > 0 && header7?.Length > 0)
            {
                value6 = Convert.ToInt32(resultSet7[0, 0]);
            }

            if (resultSet8?.GetLength(0) > 0 && header8?.Length > 0)
            {
                value7 = Convert.ToInt32(resultSet8[0, 0]);
            }
            if (resultSet9?.GetLength(0) > 0 && header9?.Length > 0)
            {
                value8 = Convert.ToInt32(resultSet9[0, 0]);
            }

            if (resultSet10?.GetLength(0) > 0 && header10?.Length > 0)
            {
                value9 = Convert.ToInt32(resultSet10[0, 0]);
            }
            if (resultSet11?.GetLength(0) > 0 && header11?.Length > 0)
            {
                value10 = Convert.ToInt32(resultSet11[0, 0]);
            }

            if (resultSet12?.GetLength(0) > 0 && header12?.Length > 0)
            {
                value11 = Convert.ToInt32(resultSet12[0, 0]);
            }
            if (resultSet13?.GetLength(0) > 0 && header13?.Length > 0)
            {
                value12 = Convert.ToInt32(resultSet13[0, 0]);
            }






        }

        else if (shift == 3)


        {

            myStore.Query("SELECT MAX(Active_Energy_Total) FROM MeterDataView WHERE LocalTimestamp  BETWEEN '" + new321 + " 00:15:00' AND '" + new321 + " 04:45:00' AND Meter = 'J2_MCB_MVS_02_O/G_F6' ", out string[] header2, out object[,] resultSet2);
            myStore.Query("SELECT MIN(Active_Energy_Total) FROM MeterDataView WHERE LocalTimestamp  BETWEEN '" + new321 + " 00:15:00' AND '" + new321 + " 04:45:00' AND Meter = 'J2_MCB_MVS_02_O/G_F6' ", out string[] header3, out object[,] resultSet3);
            myStore.Query("SELECT MAX(Active_Energy_Total) FROM MeterDataView WHERE LocalTimestamp  BETWEEN '" + new321 + " 00:15:00' AND '" + new321 + " 04:45:00' AND Meter = 'J2_MCB_SWB_02_O/G_2F2' ", out string[] header4, out object[,] resultSet4);
            myStore.Query("SELECT MIN(Active_Energy_Total) FROM MeterDataView WHERE LocalTimestamp  BETWEEN '" + new321 + " 00:15:00' AND '" + new321 + " 04:45:00' AND Meter = 'J2_MCB_SWB_02_O/G_2F2' ", out string[] header5, out object[,] resultSet5);
            myStore.Query("SELECT MAX(Active_Energy_Total) FROM MeterDataView WHERE LocalTimestamp  BETWEEN '" + new321 + " 00:15:00' AND '" + new321 + " 04:45:00' AND Meter = 'J2_MCB_SWB_02_O/G_5F1' ", out string[] header6, out object[,] resultSet6);
            myStore.Query("SELECT MIN(Active_Energy_Total) FROM MeterDataView WHERE LocalTimestamp  BETWEEN '" + new321 + " 00:15:00' AND '" + new321 + " 04:45:00' AND Meter = 'J2_MCB_SWB_02_O/G_5F1' ", out string[] header7, out object[,] resultSet7);
            myStore.Query("SELECT MAX(Active_Energy_Total) FROM MeterDataView WHERE LocalTimestamp  BETWEEN '" + new321 + " 00:15:00' AND '" + new321 + " 04:45:00' AND Meter = 'J2_MCB_SWB_02_O/G_2F1' ", out string[] header8, out object[,] resultSet8);
            myStore.Query("SELECT MIN(Active_Energy_Total) FROM MeterDataView WHERE LocalTimestamp  BETWEEN '" + new321 + " 00:15:00' AND '" + new321 + " 04:45:00' AND Meter = 'J2_MCB_SWB_02_O/G_2F1' ", out string[] header9, out object[,] resultSet9);
            myStore.Query("SELECT MAX(Active_Energy_Total) FROM MeterDataView WHERE LocalTimestamp  BETWEEN '" + new321 + " 00:15:00' AND '" + new321 + " 04:45:00' AND Meter = 'J2_MCB_MVS_03_O/G_F4' ", out string[] header10, out object[,] resultSet10);
            myStore.Query("SELECT MIN(Active_Energy_Total) FROM MeterDataView WHERE LocalTimestamp  BETWEEN '" + new321 + " 00:15:00' AND '" + new321 + " 04:45:00' AND Meter = 'J2_MCB_MVS_03_O/G_F4' ", out string[] header11, out object[,] resultSet11);
            myStore.Query("SELECT MAX(Active_Energy_Total) FROM MeterDataView WHERE LocalTimestamp  BETWEEN '" + new321 + " 00:15:00' AND '" + new321 + " 04:45:00' AND Meter = 'J2_MCB_MVS_03_O/G_F5' ", out string[] header12, out object[,] resultSet12);
            myStore.Query("SELECT MIN(Active_Energy_Total) FROM MeterDataView WHERE LocalTimestamp  BETWEEN '" + new321 + " 00:15:00' AND '" + new321 + " 04:45:00' AND Meter = 'J2_MCB_MVS_03_O/G_F5' ", out string[] header13, out object[,] resultSet13);





            if (resultSet2?.GetLength(0) > 0 && header2?.Length > 0)
            {
                value1 = Convert.ToInt32(resultSet2[0, 0]);
            }
            if (resultSet3?.GetLength(0) > 0 && header3?.Length > 0)
            {
                value2 = Convert.ToInt32(resultSet3[0, 0]);
            }
            if (resultSet4?.GetLength(0) > 0 && header4?.Length > 0)
            {
                value3 = Convert.ToInt32(resultSet4[0, 0]);
            }
            if (resultSet5?.GetLength(0) > 0 && header5?.Length > 0)
            {
                value4 = Convert.ToInt32(resultSet5[0, 0]);
            }
            if (resultSet6?.GetLength(0) > 0 && header6?.Length > 0)
            {
                value5 = Convert.ToInt32(resultSet6[0, 0]);
            }
            if (resultSet7?.GetLength(0) > 0 && header7?.Length > 0)
            {
                value6 = Convert.ToInt32(resultSet7[0, 0]);
            }

            if (resultSet8?.GetLength(0) > 0 && header8?.Length > 0)
            {
                value7 = Convert.ToInt32(resultSet8[0, 0]);
            }
            if (resultSet9?.GetLength(0) > 0 && header9?.Length > 0)
            {
                value8 = Convert.ToInt32(resultSet9[0, 0]);
            }

            if (resultSet10?.GetLength(0) > 0 && header10?.Length > 0)
            {
                value9 = Convert.ToInt32(resultSet10[0, 0]);
            }
            if (resultSet11?.GetLength(0) > 0 && header11?.Length > 0)
            {
                value10 = Convert.ToInt32(resultSet11[0, 0]);
            }

            if (resultSet12?.GetLength(0) > 0 && header12?.Length > 0)
            {
                value11 = Convert.ToInt32(resultSet12[0, 0]);
            }
            if (resultSet13?.GetLength(0) > 0 && header13?.Length > 0)
            {
                value12 = Convert.ToInt32(resultSet13[0, 0]);
            }






        }

        Project.Current.GetVariable("Model/Compressor/Comp_1_Max").Value = value1;
        Project.Current.GetVariable("Model/Compressor/Comp_1_MIn").Value = value2;
        Project.Current.GetVariable("Model/Compressor/Comp_2_Max").Value = value3;
        Project.Current.GetVariable("Model/Compressor/Comp_2_MIn").Value = value4;
        Project.Current.GetVariable("Model/Compressor/Comp_3_Max").Value = value5;
        Project.Current.GetVariable("Model/Compressor/Comp_3_MIn").Value = value6;
        Project.Current.GetVariable("Model/Compressor/Comp_4_Max").Value = value7;
        Project.Current.GetVariable("Model/Compressor/Comp_4_MIn").Value = value8;
        Project.Current.GetVariable("Model/Compressor/Comp_5_Max").Value = value9;
        Project.Current.GetVariable("Model/Compressor/Comp_5_Min").Value = value10;
        Project.Current.GetVariable("Model/Compressor/Comp_6_Max").Value = value11;
        Project.Current.GetVariable("Model/Compressor/Comp_6_Min").Value = value12;


    }


}

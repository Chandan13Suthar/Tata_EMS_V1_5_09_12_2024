using FTOptix.HMIProject;
using FTOptix.NetLogic;
using System;
using UAManagedCore;

public class DateAddUpdateLogic : BaseNetLogic
{
    public override void Start()
    {
        // Code to execute when the user-defined logic is started
    }

    public override void Stop()
    {
        // Code to execute when the user-defined logic is stopped
    }

    [ExportMethod]
    public void DateUpdateTask()
    {
        // Safely get and update DailyReportDateTO
        var dailyReportDateVar = Project.Current.GetVariable("Model/DailyReportDateTO");
        if (dailyReportDateVar != null)
        {
            DateTime time1date = dailyReportDateVar.Value;
            Project.Current.GetVariable("Model/Reports/DailyDateTo").Value = time1date.Add(new TimeSpan(23, 59, 59));
        }

        // Safely get and update AlarmReportDateTO
        var alarmReportDateVar = Project.Current.GetVariable("Model/AlarmReportDateTO");
        if (alarmReportDateVar != null)
        {
            DateTime time2date = alarmReportDateVar.Value;
            Project.Current.GetVariable("Model/Reports/Forth Report/Dateto").Value = time2date.Add(new TimeSpan(23, 59, 59));
        }

        var compareHistoDateVar = Project.Current.GetVariable("Model/Comparision_Dashboard/DateSample");
        if (compareHistoDateVar != null)
        {
            DateTime time3date = compareHistoDateVar.Value;
            Project.Current.GetVariable("Model/Comparision_Dashboard/Dateto").Value = time3date.Add(new TimeSpan(23, 59, 59));
        }

        var HistoDateVar = Project.Current.GetVariable("Model/Histo Dashboard/DateToUpdate");
        if (HistoDateVar != null)
        {
            DateTime time3date = HistoDateVar.Value;
            Project.Current.GetVariable("Model/Histo Dashboard/Dateto").Value = time3date.Add(new TimeSpan(23, 59, 59));
        }

        var compareHarmoDateVar = Project.Current.GetVariable("Model/Reports/HarmonicsReport/DateTest");
        if (compareHarmoDateVar != null)
        {
            DateTime time4date = compareHarmoDateVar.Value;
            Project.Current.GetVariable("Model/Reports/HarmonicsReport/DateTo").Value = time4date.Add(new TimeSpan(23, 59, 59));
        }


    }
}

using FTOptix.HMIProject;
using FTOptix.NetLogic;
using System;
using UAManagedCore;



public class Shiftwisedateselection : BaseNetLogic
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

    public void DateUpdateTask()
    {
        // Safely get and update DailyReportDateTO
        var dailyReportDateVar = Project.Current.GetVariable("Model/Reports/ShiftReportTags/Date");
        var shiftselection = Project.Current.GetVariable("Model/Reports/ShiftReportTags/ShiftNumber");
        int shiftselection1 = (int)shiftselection.Value;

        // Ensure dailyReportDateVar is not null before proceeding
        if (dailyReportDateVar != null)
        {
            DateTime time1date = dailyReportDateVar.Value;  // Get the date value but do not modify it

            // Depending on shift selection, assign appropriate time ranges
            if (shiftselection1 == 1)
            {
                Project.Current.GetVariable("Model/Reports/ShiftReportTags/Startupfrom").Value = time1date.Date.Add(new TimeSpan(03, 59, 59));
                Project.Current.GetVariable("Model/Reports/ShiftReportTags/StartupTo").Value = time1date.Date.Add(new TimeSpan(05, 59, 59));
            }
            else if (shiftselection1 == 2)
            {
                Project.Current.GetVariable("Model/Reports/ShiftReportTags/ShiftAFrom").Value = time1date.Date.Add(new TimeSpan(05, 59, 59));
                Project.Current.GetVariable("Model/Reports/ShiftReportTags/ShiftATo").Value = time1date.Date.Add(new TimeSpan(14, 59, 59));
            }
            else if (shiftselection1 == 3)
            {
                Project.Current.GetVariable("Model/Reports/ShiftReportTags/ShiftBFrom").Value = time1date.Date.Add(new TimeSpan(14, 59, 59));
                Project.Current.GetVariable("Model/Reports/ShiftReportTags/ShiftBTo").Value = time1date.Date.Add(new TimeSpan(23, 59, 59));
            }
            else if (shiftselection1 == 4)
            {
                Project.Current.GetVariable("Model/Reports/ShiftReportTags/ShiftCFrom").Value = time1date.Date.Add(new TimeSpan(23, 59, 59));
                Project.Current.GetVariable("Model/Reports/ShiftReportTags/ShiftCTo").Value = time1date.Date.AddDays(1).Add(new TimeSpan(03, 59, 59));
            }
        }
    }

}

#region Using directives
using System;
using UAManagedCore;
using FTOptix.NetLogic;
using FTOptix.WebUI;
using Store = FTOptix.Store;
using FTOptix.HMIProject;
#endregion

public class RuntimeNetLogic9 : BaseNetLogic
{
    
   // private PeriodicTask periodicTask;
    private IUAVariable productioncountVariable;
    public IUAVariable ButtonVariable;
    public override void Start()
    {

        var owner = (ProductionCount1)LogicObject.Owner;

        productioncountVariable = owner.ProductionCountVariable;
    }
    ////////////////////////////////*********************************************///////////////////////////////////////////////////////////////////////////
    public override void Stop()
    {    
    }
    [ExportMethod]
    public void IncrementDecrementTask()
    {
        int production = productioncountVariable.Value;
        var project = FTOptix.HMIProject.Project.Current;
        var myStore = project.GetObject("DataStores").Get<Store.Store>("ODBCDatabase");
        var dateselectionVariable = Project.Current.GetVariable("Model/HomePageJaceWisePanel/DateForProductionCount");
        DateTime dateselection = (DateTime)dateselectionVariable.Value;
        string new321 = dateselection.ToString("dd-MM-yyyy");

       // myStore.Query(" UPDATE HomePage SET Production = '" + production + "' WHERE LocalTimestamp BETWEEN '" + new321 + " 0:00:00' AND '" + new321 + " 23:59:59'", out _, out _);
        myStore.Query(" UPDATE HomePage SET Production = '" + production + "' WHERE Date1 = '" + new321 + "'", out _, out _);
    }
}

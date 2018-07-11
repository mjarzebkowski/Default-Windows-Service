using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace DefaultWindowsService
{
    public partial class Service1 : ServiceBase
    {
        private static string logSource = "MyEventLog";
        private static string logName = "MyNewLog";
        private static string logMachineName = "MyMachine";
        private static string erroSource = "MyNaeLog";

        public Service1()
        {

            InitializeComponent();
            eventLog1 = new System.Diagnostics.EventLog();
            if (!System.Diagnostics.EventLog.Exists("MyEventLog") && !System.Diagnostics.EventLog.SourceExists(logSource) )
            {
                System.Diagnostics.EventLog.DeleteEventSource(erroSource, logMachineName);
                System.Diagnostics.EventLog.Delete(logName, logMachineName);
                System.Diagnostics.EventLog.CreateEventSource(logSource, logName);

            }

            eventLog1.Source = logSource;
            eventLog1.Log = logName;
        }

        protected override void OnStart(string[] args)
        {
            System.Diagnostics.Debugger.Launch();
            Debugger.Break();
            //System.Diagnostics.EventLog.DeleteEventSource(logSource, logMachineName);
            System.Diagnostics.EventLog.Delete(logName, logMachineName);
            System.Diagnostics.EventLog.CreateEventSource(logSource, logName);
            //eventLog1.WriteEntry("Monit on Start :)");
            //System.IO.File.Create(AppDomain.CurrentDomain.BaseDirectory + "Create logbook on start.log");
        }

        protected override void OnStop()
        {
            //eventLog1.WriteEntry("Monit on Stop :(");
            //System.IO.File.Create(AppDomain.CurrentDomain.BaseDirectory + "Create logbook on stop.log");

        }

        public void OnDebug()
        {
            System.Diagnostics.EventLog.DeleteEventSource(erroSource, logMachineName);
            System.Diagnostics.EventLog.Delete(logName, logMachineName);
            System.Diagnostics.EventLog.CreateEventSource(logSource, logName);


            eventLog1.WriteEntry(" ~ Monit on Debug ~ ");
            System.IO.File.Create(AppDomain.CurrentDomain.BaseDirectory + "Create logbook on debug.log");

            OnStart(null);
        }

        private void eventLog1_EntryWritten(object sender, EntryWrittenEventArgs e)
        {

        }
    }
}

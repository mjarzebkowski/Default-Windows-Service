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
        public Service1()
        {
            InitializeComponent();
            eventLog1 = new System.Diagnostics.EventLog();
            if (!System.Diagnostics.EventLog.SourceExists("MyEventLog"))
            {
                System.Diagnostics.EventLog.CreateEventSource("MyEventLog","MyNaeLog");
            }

            eventLog1.Source = "MyEventLog";
            eventLog1.Log = "MyNewLog";
        }

        protected override void OnStart(string[] args)
        {
            eventLog1.WriteEntry("Monit on Start :)");
        }

        protected override void OnStop()
        {
            eventLog1.WriteEntry("Monit on Stop :(");
        }

        public void OnDebug()
        {
            eventLog1.WriteEntry(" ~ Monit on Debug ~ ");
            OnStart(null);
        }


    }
}

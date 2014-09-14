using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace BSBTAC.CreateSearch
{
    public partial class CreateSearch : ServiceBase
    {
        public CreateSearch()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            for (int i = 1; i <= 10000; i++)
            {
                string text = i + ",Title" + i + ",Forename" + i + ",Surname" + i + ",Othername" + i + "," + DateTime.Now + ",buildingno" + i + ",buildingname" + i + ",locality" + i + ",sublocality" + i + ",Posttown" + i + ",Postcode" + i;
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\_Workspace\Data_10000.txt", true))
                {
                    file.WriteLine(text);
                }
            }
        }

        protected override void OnStop()
        {
        }

        public void DebugOnStart()
        {
            OnStart(null);
        }
    }
}

using BSBTAC.Domain;
using BSBTAC.Domain.Models;
using Common.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Entity.Core;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

[assembly:log4net.Config.XmlConfigurator]

namespace BSBTAC.LoadSearch
{
    public partial class LoadSearch : ServiceBase
    {
        private BSBTACContext bsbtacContext;
        private UnitOfWork _uow;
        private log4net.ILog _log;
        public LoadSearch()
        {
            InitializeComponent();
            bsbtacContext = new BSBTACContext();
            _log = log4net.LogManager.GetLogger(typeof(LoadSearch));
        }

        protected override void OnStart(string[] args)
        {
            _log.Info("Load Search Service Started...");
            Task loadUpload = new Task(() => LoadNewUploadsUsingBulk());
            loadUpload.Start();
            Thread.Sleep(60 * 1000);
            /*
            while (true)
            {
                Task loadUpload = new Task(() => LoadNewUploads());
                loadUpload.Start();
                Thread.Sleep(60 * 1000);
            }
            */ 
        }

        protected override void OnStop()
        {
            _log.Info("Load Search Service Stopped...");
        }

        public void ManualOnStart()
        {
            OnStart(null);
        }

        private void LoadNewUploads()
        {
            _uow = new UnitOfWork(bsbtacContext);
            try
            {
                UploadDetail upload;
                lock (this)
                {
                    upload = _uow.Repository<UploadDetail>().SqlQuery("spGetNextUploadedFile").First();
                    /*
                    upload = _uow.Repository<UploadDetail>().Query()
                        .Get()
                        .Where(u => u.Status == 1)
                        .First();

                    upload.Status = 2;
                    upload.ObjectState = ObjectState.Modified;
                    _uow.Repository<UploadDetail>().Update(upload);
                    _uow.Save();
                    */
                }

                var filename = upload.Filename;

                var path = @"C:\_Workspace\Projects\2012\BSBTAC\_Uploads\BSB\" + filename;

                var file = new StreamReader(path);
                
                string line = "";
                while((line = file.ReadLine()) != null)
                {
                    try
                    {
                        SearchDefinition searchDefinition = new SearchDefinition();
                        string[] data = line.Split(',');

                        if(data[0].Equals("DebtCode"))
                        {
                            continue;
                        }
                        else
                        {
                            searchDefinition.UploadDetailId = upload.UploadDetailId;
                            searchDefinition.DebtCode = Convert.ToInt32(data[0]);
                            searchDefinition.Title = data[1];
                            searchDefinition.Forename = data[2];
                            searchDefinition.Surname = data[3];
                            searchDefinition.Othername = data[4];
                            searchDefinition.DOB = Convert.ToDateTime(data[5]);
                            searchDefinition.BuildingNo = data[6];
                            searchDefinition.BuildingName = data[7];
                            searchDefinition.Locality = data[8];
                            searchDefinition.Sublocality = data[9];
                            searchDefinition.Posttown = data[10];
                            searchDefinition.Postcode = data[11];
                            searchDefinition.Type = Convert.ToByte(upload.Type);
                            searchDefinition.Status = Convert.ToByte(1);
                            searchDefinition.LastUpdatedDatetime = DateTime.Now;

                            searchDefinition.ObjectState = ObjectState.Added;
                            _uow.Repository<SearchDefinition>().Insert(searchDefinition);
                            _uow.Save();
                        }
                    }
                    catch (Exception ex)
                    {
                        _log.Error(line + "-" + ex.Message);
                        continue;
                    }
                }

                file.Close();

            }
            catch (EntityCommandExecutionException)
            {
                _log.Info("No new uploads found");
            }
            catch(Exception ex)
            {
                _log.Error(ex.Message);
            }
        }

        private void LoadNewUploadsUsingBulk()
        {
            _uow = new UnitOfWork(bsbtacContext);
            try
            {
                UploadDetail upload;
                lock (this)
                {
                    upload = _uow.Repository<UploadDetail>().SqlQuery("spGetNextUploadedFile").First();
                }

                var filename = upload.Filename;

                var path = @"C:\_Workspace\Projects\2012\BSBTAC\_Uploads\BSB";

                /*
                string strSql = "SELECT * FROM [" + filename + "]";
                string strCSVConnString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";" + "Extended Properties='text;HDR=YES;FMT=Delimited(,)';";
                
                OleDbDataAdapter oleda = new OleDbDataAdapter(strSql, strCSVConnString); 
                */

                string connString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='text;HDR=Yes;FMT=Delimited(,)';", path);
                using (OleDbConnection con = 
                        new OleDbConnection(connString))
                {
                    using (OleDbCommand cmd = new OleDbCommand(string.Format
                                              ("SELECT * FROM [{0}]", filename), con))
                    {
                        con.Open();
                        /* 
                        // Using a DataReader to process the data
                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Process the current reader entry...
                            }
                        }
                        */
                        using (OleDbDataAdapter adp = new OleDbDataAdapter(cmd))
                        {
                            DataTable tbl = new DataTable();
                            adp.Fill(tbl);

                            SqlBulkCopy bulkCopy = new SqlBulkCopy(ConfigurationManager.ConnectionStrings["BSBTACNonEF"].ConnectionString);
                            bulkCopy.BatchSize = 1000;

                            bulkCopy.ColumnMappings.Add(0, 2);
                            bulkCopy.ColumnMappings.Add(1, 3);
                            bulkCopy.ColumnMappings.Add(2, 4);
                            bulkCopy.ColumnMappings.Add(3, 5);
                            bulkCopy.ColumnMappings.Add(4, 6);
                            bulkCopy.ColumnMappings.Add(5, 7);
                            bulkCopy.ColumnMappings.Add(6, 8);
                            bulkCopy.ColumnMappings.Add(7, 9);
                            bulkCopy.ColumnMappings.Add(8, 10);
                            bulkCopy.ColumnMappings.Add(9, 11);
                            bulkCopy.ColumnMappings.Add(10, 12);
                            bulkCopy.ColumnMappings.Add(11, 13);

                            bulkCopy.DestinationTableName = "SearchDefinition";
                            bulkCopy.WriteToServer(tbl);
                            /*
                            foreach (DataRow row in tbl.Rows)
                            {
                            }
                            */
                        }
                    }
                }


            }
            catch (EntityCommandExecutionException)
            {
                _log.Info("No new uploads found");
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
            }
        }
    
    }
}

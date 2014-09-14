using BSBTAC.Domain;
using BSBTAC.Domain.Models;
using Common.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core;
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
            while (true)
            {
                Task loadUpload = new Task(() => LoadNewUploads());
                loadUpload.Start();
                Thread.Sleep(60 * 1000);
            }
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
    }
}

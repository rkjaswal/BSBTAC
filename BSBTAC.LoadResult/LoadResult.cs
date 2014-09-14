using BSBTAC.Domain;
using BSBTAC.Domain.Models;
using Common.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

[assembly: log4net.Config.XmlConfigurator]

namespace BSBTAC.LoadResult
{
    public partial class LoadResult : ServiceBase
    {
        private BSBTACContext bsbtacContext;
        private UnitOfWork _uow;
        private log4net.ILog _log;

        public LoadResult()
        {
            InitializeComponent();
            bsbtacContext = new BSBTACContext();
            _log = log4net.LogManager.GetLogger(typeof(LoadResult));
        }

        protected override void OnStart(string[] args)
        {
            _log.Info("Load Search Service Started...");
            while (true)
            {
                Parallel.For(1, 1000, i => GetBSBReport());
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

        public bool GetBSBReport()
        {
            _uow = new UnitOfWork(bsbtacContext);
            Random rnd = new Random();
            SearchDefinition searchDefinition = new SearchDefinition();
            ApplSummary applSummary = new ApplSummary();
            Cameo2006 cameo2006 = new Cameo2006();
            try
            {
                lock (this)
                {
                    var lastUpdatedDatetime = new SqlParameter("@LastUpdatedDatetime", DateTime.Now);
                    searchDefinition = _uow.Repository<SearchDefinition>().SqlQuery("spGetNextBSBSearch @LastUpdatedDatetime", lastUpdatedDatetime).First();
                }

                Thread.Sleep(rnd.Next(3000, 10000));

                applSummary.SearchDefinitionId = searchDefinition.SearchDefinitionId;
                applSummary.AccountInformation = "AccountInformation" + searchDefinition.DebtCode;
                applSummary.NumberOfDisputes = searchDefinition.DebtCode;

                cameo2006.SearchDefinitionId = searchDefinition.SearchDefinitionId;
                cameo2006.LocalityInformation = "LocalityInformation" + searchDefinition.DebtCode;
                cameo2006.CouncilTaxBand = searchDefinition.DebtCode;

                lock (this)
                {
                    applSummary.ObjectState = ObjectState.Added;
                    cameo2006.ObjectState = ObjectState.Added;
                    _uow.Repository<ApplSummary>().Insert(applSummary);
                    _uow.Repository<Cameo2006>().Insert(cameo2006);
                    _uow.Save();

                    searchDefinition.Status = 3;
                    searchDefinition.LastUpdatedDatetime = DateTime.Now;
                    _uow.Repository<SearchDefinition>().Update(searchDefinition);
                    _uow.Save();
                }

                return true;
            }
            catch (EntityCommandExecutionException)
            {
                _log.Info("No new search found");
                return false;
            }
            catch (Exception ex)
            {
                lock(this)
                {
                    searchDefinition.Status = 4;
                    searchDefinition.LastUpdatedDatetime = DateTime.Now;
                    _uow.Repository<SearchDefinition>().Update(searchDefinition);
                    _uow.Save();
                }
                _log.Error(ex.Message);
                return false;
            }
        }
    }
}

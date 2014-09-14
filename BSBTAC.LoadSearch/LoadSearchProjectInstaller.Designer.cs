namespace BSBTAC.LoadSearch
{
    partial class LoadSearchProjectInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.serviceLoadSearchProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.serviceLoadSearchInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // serviceLoadSearchProcessInstaller
            // 
            this.serviceLoadSearchProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.serviceLoadSearchProcessInstaller.Password = null;
            this.serviceLoadSearchProcessInstaller.Username = null;
            // 
            // serviceLoadSearchInstaller
            // 
            this.serviceLoadSearchInstaller.Description = "Loads data into search definition table";
            this.serviceLoadSearchInstaller.DisplayName = "BSBTAC.LoadSearch";
            this.serviceLoadSearchInstaller.ServiceName = "BSBTAC.LoadSearch";
            // 
            // LoadSearchProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.serviceLoadSearchProcessInstaller,
            this.serviceLoadSearchInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller serviceLoadSearchProcessInstaller;
        private System.ServiceProcess.ServiceInstaller serviceLoadSearchInstaller;
    }
}
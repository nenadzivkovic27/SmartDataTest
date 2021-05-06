
namespace SmartDemoApp
{
    partial class FrmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.txtSearchTerm = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.cboMarket = new System.Windows.Forms.ComboBox();
            this.lblMarket = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.bsMarkets = new System.Windows.Forms.BindingSource(this.components);
            this.dgvMgmt = new System.Windows.Forms.DataGridView();
            this.errSmart = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblLimit = new System.Windows.Forms.Label();
            this.txtLimit = new System.Windows.Forms.TextBox();
            this.grpMgmt = new System.Windows.Forms.GroupBox();
            this.grpProperty = new System.Windows.Forms.GroupBox();
            this.dgvProperty = new System.Windows.Forms.DataGridView();
            this.bsMgmr = new System.Windows.Forms.BindingSource(this.components);
            this.bsProperty = new System.Windows.Forms.BindingSource(this.components);
            this.lblInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bsMarkets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMgmt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errSmart)).BeginInit();
            this.grpMgmt.SuspendLayout();
            this.grpProperty.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProperty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsMgmr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsProperty)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearchTerm
            // 
            this.txtSearchTerm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchTerm.Location = new System.Drawing.Point(12, 39);
            this.txtSearchTerm.Name = "txtSearchTerm";
            this.txtSearchTerm.Size = new System.Drawing.Size(528, 23);
            this.txtSearchTerm.TabIndex = 1;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(12, 18);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(73, 15);
            this.lblSearch.TabIndex = 2;
            this.lblSearch.Text = "Search term:";
            // 
            // cboMarket
            // 
            this.cboMarket.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboMarket.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMarket.FormattingEnabled = true;
            this.cboMarket.Location = new System.Drawing.Point(560, 39);
            this.cboMarket.Name = "cboMarket";
            this.cboMarket.Size = new System.Drawing.Size(177, 23);
            this.cboMarket.TabIndex = 3;
            // 
            // lblMarket
            // 
            this.lblMarket.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMarket.AutoSize = true;
            this.lblMarket.Location = new System.Drawing.Point(560, 18);
            this.lblMarket.Name = "lblMarket";
            this.lblMarket.Size = new System.Drawing.Size(44, 15);
            this.lblMarket.TabIndex = 4;
            this.lblMarket.Text = "Market";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSearch.Location = new System.Drawing.Point(755, 39);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dgvMgmt
            // 
            this.dgvMgmt.AllowUserToAddRows = false;
            this.dgvMgmt.AllowUserToDeleteRows = false;
            this.dgvMgmt.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvMgmt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMgmt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMgmt.Location = new System.Drawing.Point(3, 19);
            this.dgvMgmt.Name = "dgvMgmt";
            this.dgvMgmt.ReadOnly = true;
            this.dgvMgmt.RowTemplate.Height = 25;
            this.dgvMgmt.Size = new System.Drawing.Size(812, 127);
            this.dgvMgmt.TabIndex = 6;
            // 
            // errSmart
            // 
            this.errSmart.ContainerControl = this;
            // 
            // lblLimit
            // 
            this.lblLimit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLimit.AutoSize = true;
            this.lblLimit.Location = new System.Drawing.Point(12, 471);
            this.lblLimit.Name = "lblLimit";
            this.lblLimit.Size = new System.Drawing.Size(37, 15);
            this.lblLimit.TabIndex = 7;
            this.lblLimit.Text = "Limit:";
            // 
            // txtLimit
            // 
            this.txtLimit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtLimit.Location = new System.Drawing.Point(55, 470);
            this.txtLimit.Name = "txtLimit";
            this.txtLimit.Size = new System.Drawing.Size(59, 23);
            this.txtLimit.TabIndex = 8;
            this.txtLimit.Text = "10";
            // 
            // grpMgmt
            // 
            this.grpMgmt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpMgmt.Controls.Add(this.dgvMgmt);
            this.grpMgmt.Location = new System.Drawing.Point(12, 68);
            this.grpMgmt.Name = "grpMgmt";
            this.grpMgmt.Size = new System.Drawing.Size(818, 149);
            this.grpMgmt.TabIndex = 9;
            this.grpMgmt.TabStop = false;
            this.grpMgmt.Text = "Mgmts";
            // 
            // grpProperty
            // 
            this.grpProperty.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpProperty.Controls.Add(this.dgvProperty);
            this.grpProperty.Location = new System.Drawing.Point(12, 221);
            this.grpProperty.Name = "grpProperty";
            this.grpProperty.Size = new System.Drawing.Size(818, 247);
            this.grpProperty.TabIndex = 10;
            this.grpProperty.TabStop = false;
            this.grpProperty.Text = "Properties";
            // 
            // dgvProperty
            // 
            this.dgvProperty.AllowUserToAddRows = false;
            this.dgvProperty.AllowUserToDeleteRows = false;
            this.dgvProperty.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvProperty.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProperty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProperty.Location = new System.Drawing.Point(3, 19);
            this.dgvProperty.Name = "dgvProperty";
            this.dgvProperty.ReadOnly = true;
            this.dgvProperty.RowTemplate.Height = 25;
            this.dgvProperty.Size = new System.Drawing.Size(812, 225);
            this.dgvProperty.TabIndex = 0;
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(154, 473);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(28, 15);
            this.lblInfo.TabIndex = 11;
            this.lblInfo.Text = "Info";
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 506);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.grpProperty);
            this.Controls.Add(this.grpMgmt);
            this.Controls.Add(this.txtLimit);
            this.Controls.Add(this.lblLimit);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblMarket);
            this.Controls.Add(this.cboMarket);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearchTerm);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(627, 450);
            this.Name = "FrmMain";
            this.Text = "Smart Demo App";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsMarkets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMgmt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errSmart)).EndInit();
            this.grpMgmt.ResumeLayout(false);
            this.grpProperty.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProperty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsMgmr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsProperty)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearchTerm;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.ComboBox cboMarket;
        private System.Windows.Forms.Label lblMarket;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.BindingSource bsMarkets;
        private System.Windows.Forms.DataGridView dgvMgmt;
        private System.Windows.Forms.ErrorProvider errSmart;
        private System.Windows.Forms.TextBox txtLimit;
        private System.Windows.Forms.Label lblLimit;
        private System.Windows.Forms.GroupBox grpMgmt;
        private System.Windows.Forms.GroupBox grpProperty;
        private System.Windows.Forms.DataGridView dgvProperty;
        private System.Windows.Forms.BindingSource bsMgmr;
        private System.Windows.Forms.BindingSource bsProperty;
        private System.Windows.Forms.Label lblInfo;
    }
}


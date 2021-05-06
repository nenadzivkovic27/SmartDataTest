using SmartDemoApp.DemoAppDataTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartDemoApp
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();

            bsMarkets.DataSource = typeof(MarketResult);
            bsMgmr.DataSource = typeof(MgmtResult);
            bsProperty.DataSource = typeof(PropertyResult);

            cboMarket.DataSource = bsMarkets;
            dgvMgmt.DataSource = bsMgmr;
            dgvProperty.DataSource = bsProperty;

            lblInfo.Text = "";
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            try
            {
                List<MarketResult> marketResults = SmartAPIManager.Instance.GetMarkets();
                bsMarkets.DataSource = marketResults;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error loading application", MessageBoxButtons.OK);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateInput())
                {
                    MarketResult market = bsMarkets.Current as MarketResult;
                    String searchTerm = txtSearchTerm.Text;
                    int limit = int.Parse(txtLimit.Text);

                    SearchResult sr = SmartAPIManager.Instance.Search(searchTerm, market, limit);

                    bsMgmr.DataSource = sr.Mgmts;
                    bsProperty.DataSource = sr.Properties;

                    String info = String.Format("Mgmts: showing {0} out of {1}; Properties: showing {2} out of {3}",
                        sr.MgmtShown, sr.MgmtCount, sr.PropertyShown, sr.PropertyCount);

                    lblInfo.Text = info;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error searching", MessageBoxButtons.OK);
            }
        }

        private bool ValidateInput()
        {
            bool toRet = true;
            errSmart.Clear();

            if (String.IsNullOrWhiteSpace(txtSearchTerm.Text))
            {
                toRet = false;
                errSmart.SetError(txtSearchTerm, "Search term can't be empty");
            }

            int limit = -1;
            if (!int.TryParse(txtLimit.Text, out limit) || limit < 0)
            {
                toRet = false;
                errSmart.SetError(txtLimit, "Limit must be non-negative number");
            }

            return toRet;
        }
    }
}

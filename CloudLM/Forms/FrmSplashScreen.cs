using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CloudLM.Forms
{
    public partial class FrmSplashScreen : Form
    {
        public FrmSplashScreen()
        {
            InitializeComponent();
            InitializeAuthentication();
        }
        private async void InitializeAuthentication()
        {
            try
            {
                await Classes.FireActions.AuthFromSession();
                if (Classes.FireObjects.AuthLink == null)
                {
                    FrmLogin frmLogin = new FrmLogin();
                    frmLogin.ShowDialog();
                }
                if (Classes.FireObjects.AuthLink != null)
                {
                    await Classes.FireActions.Validate();
                    this.Hide();
                    (new Forms.FrmApp()).ShowDialog();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            Environment.Exit(0);
        }

        private void FrmSplashScreen_Load(object sender, EventArgs e)
        {

        }
    }
}

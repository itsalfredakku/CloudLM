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
    public partial class FrmApp : Form
    {
        public FrmApp()
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
                    if(!String.IsNullOrWhiteSpace(frmLogin.Email) && !String.IsNullOrWhiteSpace(frmLogin.Password))
                        await Classes.FireActions.AuthFromEmailAndPassword(frmLogin.Email, frmLogin.Password);
                }
                if (Classes.FireObjects.AuthLink != null)
                {
                    await Classes.FireActions.Validate();
                    FrmApp_LoadAuthInfo();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            Environment.Exit(0);
        }
        private async void FrmApp_LoadAuthInfo()
        {
            this.valMachineId.Text = await Classes.FireActions.MachineId();
            this.valValidFrom.Text = await Classes.FireActions.ValidFrom();
            this.valValidTill.Text = await Classes.FireActions.ValidTill();
        }

        private void FrmApp_Load(object sender, EventArgs e)
        {

        }
    }
}

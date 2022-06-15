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
    public partial class FrmLogin : Form
    {
        private string Email
        {
            get
            {
                string _Email = this.tBoxEmail.Text; // Update value (only if control variable name changed)
                if (String.IsNullOrEmpty(_Email))
                    throw new Exception("Email field empty");
                if (!Classes.Utility.IsValidEmail(_Email))
                    throw new Exception("Email is not valid");
                return _Email;
            }
        }
        private string Password
        {
            get
            {
                string _Password = this.tBoxPassword.Text; // Update value (only if control variable name changed)
                if (String.IsNullOrEmpty(_Password))
                    throw new Exception("Password field empty");

                return _Password;
            }
        }
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {

            try
            {
                await Classes.FireActions.Authenticate(Email, Password);
                this.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void lnkLblForgotPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Forms.FrmResetPassword frmResetPassword = new FrmResetPassword();
            this.Hide();
            frmResetPassword.ShowDialog();
            this.Show();
        }
    }
}

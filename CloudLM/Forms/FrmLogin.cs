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
        private string _Email;
        public string Email
        {
            get
            {
                if (_Email == null) return null;
                if (String.IsNullOrEmpty(_Email))
                    throw new Exception("Email field empty");
                if (!Classes.Utility.IsValidEmail(_Email))
                    throw new Exception("Email is not valid");
                return _Email;
            }
        }
        private string _Password;
        public string Password
        {
            get
            {
                if (_Password == null) return null;
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
            this._Email = null;
            this._Password = null;
            this.Close();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            this.btnLogin.Enabled = false;
            this.btnCancel.Enabled = false;
            this.lnkLblForgotPass.Enabled = false;
            try
            {
                this._Email = this.tBoxEmail.Text;
                this._Password = this.tBoxPassword.Text;

                if (!String.IsNullOrWhiteSpace(Email) && !String.IsNullOrWhiteSpace(Password))
                {
                    await Classes.FireActions.AuthFromEmailAndPassword(Email, Password);
                    this.Close();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            this.btnLogin.Enabled = true;
            this.btnCancel.Enabled = true;
            this.lnkLblForgotPass.Enabled = true;
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

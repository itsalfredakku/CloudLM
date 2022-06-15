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
    public partial class FrmResetPassword : Form
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
        public FrmResetPassword()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                await Classes.FireActions.ResetPassword(Email);
                MessageBox.Show("Reset password link has been sent on registered email.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}

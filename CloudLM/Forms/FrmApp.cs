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
        }
        private async Task FrmApp_LoadAuthInfo()
        {
            this.valMachineId.Text = await Classes.FireActions.MachineId();
            this.valValidFrom.Text = await Classes.FireActions.ValidFrom();
            this.valValidTill.Text = await Classes.FireActions.ValidTill();
        }

        private async void FrmApp_Load(object sender, EventArgs e)
        {
            await FrmApp_LoadAuthInfo();
        }
    }
}

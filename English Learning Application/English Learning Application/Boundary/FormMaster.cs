using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using English_Learning_Application.Boundary;

namespace English_Learning_Application
{
    public partial class FormMaster : Form
    {
        private int temp_user_id;
        public FormMaster(int user_id)
        {
            InitializeComponent();
            this.temp_user_id = user_id;
        }

        string user;
        public void setToolStripUser(string text)
        {
            this.toolStripStatusLabel1.Text = text;
            user = text;
        }

        public void Set_Visible_Admin()
        {
            usersToolStripMenuItem1.Visible = true;
            questionBankToolStripMenuItem1.Visible = false;
        }

        public void Set_Visible_Teacher()
        {
            usersToolStripMenuItem1.Visible = false;
            questionBankToolStripMenuItem1.Visible = true;
        }

        private void usersToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormUser FU = new FormUser();
            FU.MdiParent = this;
            FU.Show();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you Log Out?", "Pernyataan", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            { Application.Restart(); }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void questionBankToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormBank FB = new FormBank(temp_user_id);
            FB.MdiParent = this;
            FB.Show();
        }

        private void reportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormReport FB = new FormReport(temp_user_id);
            FB.MdiParent = this;
            FB.Show();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormChangePassword FCP = new FormChangePassword(temp_user_id);
            FCP.MdiParent = this;
            FCP.Show();
        }
    }
}

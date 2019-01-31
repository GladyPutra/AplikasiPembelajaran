using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using English_Learning_Application.Controller;

namespace English_Learning_Application.Boundary
{
    public partial class FormChangePassword : Form
    {
        private int temp_user_id;
        public FormChangePassword(int user_Id)
        {
            InitializeComponent();
            this.temp_user_id = user_Id;
        }

        UserController UC = new UserController();
        KeyGenerator KG = new KeyGenerator();
        ShowException SE = new ShowException();

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string role_id = UC.Get_RoleID_User(temp_user_id);

            if (txtConfirm.Text == txtNew.Text)
            {
                string encrypt_password = KG.EncryptString(txtNew.Text);

                DialogResult dr = MessageBox.Show("Are You Sure to Change Your Password?", "QUESTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    UC.Reset_Password_User(encrypt_password, temp_user_id);
                    MessageBox.Show("Your Password Has Been Changed", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (role_id != "STD")
                    {
                        this.Hide();
                    }
                    else
                    {
                        FormQuis FQ = new FormQuis(temp_user_id);
                        FQ.ShowDialog();
                        this.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Password Confirm is Wrong...", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void bnCancel_Click(object sender, EventArgs e)
        {
            string role_id = UC.Get_RoleID_User(temp_user_id);
            if (role_id != "STD")
            {
                this.Hide();
            }
            else
            {
                FormQuis FQ = new FormQuis(temp_user_id);
                FQ.ShowDialog();
                this.Close();
            }
        }
    }
}

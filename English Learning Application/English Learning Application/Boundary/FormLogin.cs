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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        //======== Login Function ========//
        LoginControl LC = new LoginControl();

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (check_Field() == true)
            {
                errorProvider1.Clear();
                bool login = LC.Check_Login(txtUsername.Text, txtPassword.Text);

                if (login == true)
                {
                    string role = LC.Get_RoleID_User(txtUsername.Text, txtPassword.Text);
                    int user_id = int.Parse(LC.Get_UserID(txtUsername.Text, txtPassword.Text));

                    FormMaster FM = new FormMaster(user_id);
                    if (role == "ADM")
                    {
                        FM.Set_Visible_Admin();
                        FM.setToolStripUser("User : Admin - " + txtUsername.Text);
                    }
                    else if (role == "TCH")
                    {
                        FM.Set_Visible_Teacher();
                        FM.setToolStripUser("User : Teacher - " + txtUsername.Text);
                    }
                    else if (role == "STD")
                    {
                        FormQuis FQ = new FormQuis(user_id);
                        FQ.ShowDialog();
                        FM.setToolStripUser("User : Student - " + txtUsername.Text);
                    }
                    FM.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Sorry...! Username dan Passwodd Failed", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //resetForm();
                }
            }
        }

        private void bnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private bool check_Field()
        {
            bool temp = true;
            if (txtUsername.Text == "")
            {
                errorProvider1.SetError(txtUsername, "Please, Insert the Username...!");
                txtUsername.Focus();
                temp = false;
            }

            if (txtPassword.Text == "")
            {
                errorProvider1.SetError(txtPassword, "Please, Insert the Password...!");
                txtPassword.Focus();
                temp = false;
            }

            return temp;
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals(Convert.ToChar(13)))
            {
                btnLogin_Click(sender, e);
            }
            if (e.KeyChar.Equals(Convert.ToChar(27)))
            {
                bnCancel_Click(sender, e);
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals(Convert.ToChar(13)))
            {
                btnLogin_Click(sender, e);
            }
            if (e.KeyChar.Equals(Convert.ToChar(27)))
            {
                bnCancel_Click(sender, e);
            }
        }
    }
}

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
    public partial class FormUser : Form
    {
        public FormUser()
        {
            InitializeComponent();
        }

        UserController UC = new UserController();
        KeyGenerator KG = new KeyGenerator();
        ShowException SE = new ShowException();

        private void settingHeaderGrid(DataGridView DG)
        {
            //=== Make Center Header in Data Grid View
            foreach (DataGridViewColumn col in DG.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
            }
        }

        public void setDatagridview(DataGridView DG)
        {
            DG.DataSource = UC.Show_User();
            //Start Code Data Binding
            DataTable DT = UC.Show_User();
            BindingList<DataTable> listTbl = new BindingList<DataTable>();
            if (DT.Rows.Count > 0)
            {
                int counter = 0, subTblIndex = -1;
                foreach (DataRow dr in DT.Rows)
                {
                    if (counter == 0)
                    {
                        listTbl.Add(DT.Clone());
                        subTblIndex++;
                    }
                    listTbl[subTblIndex].Rows.Add(dr.ItemArray);
                    counter++;
                    if (counter == 10) counter = 0; //counter==10, one page 10 rows
                }
            }
            bindingSource1.DataSource = listTbl;
            bindingNavigator1.BindingSource = bindingSource1;
            DG.DataSource = (DT.Rows.Count > 0 ? listTbl[bindingSource1.Position] : DT);
            //Ending Code Data Binding

            DG.Columns[0].Visible = false;
            DG.Columns[1].HeaderText = "Full Name";
            DG.Columns[2].HeaderText = "Username";
            DG.Columns[3].Visible = false;
            DG.Columns[4].HeaderText = "Role";
            DG.Columns[5].HeaderText = "Create At";

            DG.Columns[1].Width = 170;
            DG.Columns[2].Width = 130;
            DG.Columns[4].Width = 80;
            DG.Columns[5].Width = 120;

            //DG.Columns[5].DefaultCellStyle.Format = "dd/mm/yyyy";

            settingHeaderGrid(DG);
           
        }

        public void searchDatagridview(DataGridView DG, string keyword)
        {
            DG.DataSource = UC.Search_User(keyword);
            //Start Code Data Binding
            DataTable DT = UC.Search_User(keyword);
            BindingList<DataTable> listTbl = new BindingList<DataTable>();
            if (DT.Rows.Count > 0)
            {
                int counter = 0, subTblIndex = -1;
                foreach (DataRow dr in DT.Rows)
                {
                    if (counter == 0)
                    {
                        listTbl.Add(DT.Clone());
                        subTblIndex++;
                    }
                    listTbl[subTblIndex].Rows.Add(dr.ItemArray);
                    counter++;
                    if (counter == 10) counter = 0; //counter==10, one page 10 rows
                }
            }
            bindingSource1.DataSource = listTbl;
            bindingNavigator1.BindingSource = bindingSource1;
            DG.DataSource = (DT.Rows.Count > 0 ? listTbl[bindingSource1.Position] : DT);
            //Ending Code Data Binding

            DG.Columns[0].Visible = false;
            DG.Columns[1].HeaderText = "Full Name";
            DG.Columns[2].HeaderText = "Username";
            DG.Columns[3].Visible = false;
            DG.Columns[4].HeaderText = "Role";
            DG.Columns[5].HeaderText = "Create At";

            DG.Columns[1].Width = 170;
            DG.Columns[2].Width = 130;
            DG.Columns[4].Width = 80;
            DG.Columns[5].Width = 120;

            //DG.Columns[5].DefaultCellStyle.Format = "dd/mm/yyyy";

            settingHeaderGrid(DG);

        }

        private string getColumn(DataGridView dg, int i)
        {
            string kolom = null;
            try
            {
                kolom = dg[dg.Columns[i].Index, dg.CurrentRow.Index].Value.ToString();
            }
            catch
            {
                SE.ShowMessage("", "Failed");
            }
            return kolom;
        }

        private string getRow(DataGridView dg)
        {
            return dg.CurrentRow.Index.ToString();
        }

        private void FormUser_Load(object sender, EventArgs e)
        {
            setDatagridview(this.dgUser);
            dTPicker.Value = DateTime.Now;
            cbRole.DataSource = UC.getRole();     //Display Role in ComboBox
            cbRole.DisplayMember = "role_name";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cekfield() == true)
            {
                errorProvider1.Clear();
                bool cekname = UC.Check_Username(txtUsername.Text);

                if (cekname == false)
                {
                    string IDKategori;
                    IDKategori = UC.getRoleId(cbRole.Text);

                    English_Learning_Application.Entity.User U = new Entity.User(txtName.Text, txtUsername.Text, txtUsername.Text, IDKategori);
                    UC.InsertUser(U);
                    MessageBox.Show("Add New User has Successfuly", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clearField();
                    setDatagridview(dgUser);
                    btnClose.Text = "Close";
                }
                else
                {
                    MessageBox.Show("Sorry...! that Username already exist", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private bool cekfield()
        {
            bool temp = true;
            if (txtName.Text == "")
            {
                errorProvider1.SetError(txtName, "Please, Insert the Full Name...!");
                txtName.Focus();
                temp = false;
            }

            if (txtUsername.Text == "")
            {
                errorProvider1.SetError(txtUsername, "Please, Insert the Username...!");
                txtUsername.Focus();
                temp = false;
            }

            if (cbRole.Text == "")
            {
                errorProvider1.SetError(cbRole, "Please, Choose the Role...!");
                cbRole.Focus();
                temp = false;
            }

            return temp;
        }

        public void clearField()
        {
            txtName.Clear();
            txtUsername.Clear();
            cbRole.SelectedIndex = 0;
            txtID.Clear();
            VisibleButton(false);
            btnDelete.Visible = false;
            btnEdit.Visible = false;
            btnReset.Visible = false;
        }

        private void bindingSource1_PositionChanged(object sender, EventArgs e)
        {
            this.setDatagridview(dgUser);
        }

        private void dgUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = getColumn(dgUser, 0);
            VisibleButton(true);
        }

        private void VisibleButton(bool value)
        {
            btnEdit.Visible = value;
            btnDelete.Visible = value;
            btnReset.Visible = value;
        }

        private void EnableButton(bool value)
        {
            btnSave.Enabled = value;
            btnDelete.Enabled = value;
            btnReset.Enabled = value;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "")
            {
                if (btnEdit.Text == "Edit")
                {
                    txtName.Text = getColumn(dgUser, 1);
                    txtUsername.Text = getColumn(dgUser, 2);
                    cbRole.Text = getColumn(dgUser, 4);
                    btnSave.Enabled = false;
                    btnEdit.Text = "Update";
                    EnableButton(false);
                }
                else if (btnEdit.Text == "Update")
                {
                    if (cekfield() == true)
                    {
                        errorProvider1.Clear();
                        string IDKategori;
                        IDKategori = UC.getRoleId(cbRole.Text);

                        English_Learning_Application.Entity.User U = new Entity.User(txtName.Text, txtUsername.Text, txtName.Text, IDKategori);

                        DialogResult dr = MessageBox.Show("Are You Sure to Update This User?", "QUESTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr == DialogResult.Yes)
                        {
                            UC.UpdateUser(U, int.Parse(txtID.Text));
                            MessageBox.Show("Update User Has Been Successfuly", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        EnableButton(true);
                        clearField();
                        btnClose.Text = "Close";
                        VisibleButton(false);
                        setDatagridview(dgUser);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please, Choose the Users to Edit...!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dgUser.Focus();
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            btnClose.Text = "Cancel";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (btnClose.Text == "Cancel")
            {
                clearField();
                btnSave.Enabled = true;
                btnEdit.Text = "Edit";
                btnClose.Text = "Close";
                EnableButton(true);
            }
            else if (btnClose.Text == "Close")
            {
                this.Hide();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "")
            {
                DialogResult dr = MessageBox.Show("Are You Sure to Delete This User?", "QUESTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    UC.DeleteUser(int.Parse(txtID.Text));
                    MessageBox.Show(" User Has Been Deleted", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                clearField();
                VisibleButton(false);
                setDatagridview(dgUser);
            }
            else
            {
                MessageBox.Show("Please, Choose the Users to Edit...!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dgUser.Focus();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            searchDatagridview(dgUser, txtSearch.Text);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            string new_password = RandomString(7);
            if (txtID.Text != "")
            {
                string encrypt_password = KG.EncryptString(new_password);

                DialogResult dr = MessageBox.Show("Are You Sure to Reset Password this User?", "QUESTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    UC.Reset_Password_User(encrypt_password, Convert.ToInt32(txtID.Text));
                    MessageBox.Show("The New Password: " + new_password, "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                EnableButton(true);
                clearField();
                btnClose.Text = "Close";
                VisibleButton(false);
                setDatagridview(dgUser);
            }
            else
            {
                MessageBox.Show("Please, Choose the Users to Reset Password...!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}

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
using English_Learning_Application.Boundary;
using English_Learning_Application.Entity;

namespace English_Learning_Application.Boundary
{
    public partial class FormBank : Form
    {
        private int temp_user_Id;
        public FormBank(int user_id)
        {
            InitializeComponent();
            this.temp_user_Id = user_id;
        }

        QuestionBankControl QB = new QuestionBankControl();
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

        public void RefreshGridView()
        {
            setDatagridview(dgQuestion);
            setDatagridview2(dgQuestion2, int.Parse(txtTemp2.Text));

            int RowCount = dgQuestion2.Rows.Count;
            int count_question = QB.GetCount_of_Question(int.Parse(txtTemp2.Text));
            if (RowCount > count_question)
                btnAddQuestion.Enabled = false;
        }

        public void setDatagridview(DataGridView DG)
        {
            DG.DataSource = QB.Show_Question_Bank(temp_user_Id);
            //Start Code Data Binding
            DataTable DT = QB.Show_Question_Bank(temp_user_Id);
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
            DG.Columns[1].HeaderText = "Title";
            DG.Columns[2].HeaderText = "Count";
            DG.Columns[3].HeaderText = "Duration";
            DG.Columns[4].HeaderText = "Create";
            DG.Columns[5].HeaderText = "Status";
            DG.Columns[6].HeaderText = "Modified";
            DG.Columns[7].Visible = false;

            DG.Columns[1].Width = 200;
            DG.Columns[2].Width = 50;
            DG.Columns[3].Width = 70;
            DG.Columns[4].Width = 80;
            DG.Columns[5].Width = 50;
            DG.Columns[6].Width = 80;

            //DG.Columns[5].DefaultCellStyle.Format = "dd/mm/yyyy";

            settingHeaderGrid(DG);

        }

        public void searchDatagridview(DataGridView DG, string keyword)
        {
            DG.DataSource = QB.Search_Question_Bank(keyword, temp_user_Id);
            //Start Code Data Binding
            DataTable DT = QB.Search_Question_Bank(keyword, temp_user_Id);
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
            DG.Columns[1].HeaderText = "Title";
            DG.Columns[2].HeaderText = "Count";
            DG.Columns[3].HeaderText = "Duration";
            DG.Columns[4].HeaderText = "Create";
            DG.Columns[5].HeaderText = "Status";

            DG.Columns[1].Width = 200;
            DG.Columns[2].Width = 50;
            DG.Columns[3].Width = 70;
            DG.Columns[4].Width = 80;
            DG.Columns[5].Width = 50;

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

        private void FormBank_Load(object sender, EventArgs e)
        {
            dTPQ.Value = DateTime.Now;
            setDatagridview(this.dgQuestion);
            enableOrDisable(false);
            tabControl1.TabPages.Remove(tabDetail);
        }

        private void txtDuration_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || (int)e.KeyChar == 8)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (btnEdit.Text == "Update")
            {
                getField();
                enableOrDisable(false);
                btnEdit.Text = "Edit";
                btnCancel.Text = "Close";
                btnSave.Enabled = true;
                gbQB.Text = "Form Question Bank";
            }
            else if(btnSave.Text == "Save")
            {
                clearField();
                enableOrDisable(false);
                btnSave.Text = "Add";
                btnCancel.Text = "Close";
                gbQB.Text = "Form Question Bank";
            }
            else
            {
                this.Hide();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "Add")
            {
                btnSave.Text = "Save";
                btnCancel.Text = "Cancel";
                gbQB.Text = "New Question Bank";
                enableOrDisable(true);
            }
            else if (btnSave.Text == "Save")
            {
                string status = "";
                if (rbON.Checked)
                    status = "ON";
                else if (rbOFF.Checked)
                    status = "OFF";

                if (CheckField() == true)
                {
                    errorProvider1.Clear();
                    English_Learning_Application.Entity.QuestionBank Q = new Entity.QuestionBank(txtTitle.Text, int.Parse(CountQuestion.Text), int.Parse(txtDuration.Text), status, temp_user_Id);
                    QB.InsertQuestonBank(Q);
                    MessageBox.Show("Add New User has Successfuly", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clearField();
                    setDatagridview(dgQuestion);
                }

                btnSave.Text = "Add";
                gbQB.Text = "Form Question Bank";
                enableOrDisable(false);
            }
            
        }

        private bool CheckField()
        {
            bool temp = true;

            if (txtTitle.Text == "")
            {
                errorProvider1.SetError(txtTitle, "Please, Insert the Title...!");
                txtTitle.Focus();
                temp = false;
            }

            if (CountQuestion.Text == "")
            {
                errorProvider1.SetError(CountQuestion, "Please, Insert the Count of Question...!");
                CountQuestion.Focus();
                temp = false;
            }

            if (txtDuration.Text == "")
            {
                errorProvider1.SetError(txtDuration, "Please, Insert the Duration...!");
                txtDuration.Focus();
                temp = false;
            }

            return temp;
        }

        public void clearField()
        {
            txtTitle.Clear();
            CountQuestion.Value = 0;
            txtDuration.Clear();
            rbON.Checked = true;
            rbOFF.Checked = false;
            txtID.Clear();
            txtRow.Clear();
            txtTemp.Clear();
        }

        private void bindingSource1_PositionChanged(object sender, EventArgs e)
        {
            this.setDatagridview(dgQuestion);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            searchDatagridview(dgQuestion, txtSearch.Text);
        }

        private void dgQuestion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = getColumn(dgQuestion, 0);  // Get bank_id
            txtTemp2.Text = getColumn(dgQuestion, 0); // Get bank_id
            txtRow.Text = getColumn(dgQuestion, 1);
            //txtTemp.Text = getColumn(dgQuestion, 7);
            if (txtID.Text != "")
            {
                btnEdit.Visible = true;
                btnDelete.Visible = true;
                btnDetail.Visible = true;
                btnSet.Visible = true;
                btnRun.Visible = true;
            }
            else
            {
                btnEdit.Visible = false;
                btnDelete.Visible = false;
                btnDetail.Visible = false;
                btnSet.Visible = false;
                btnRun.Visible = false;
            }
            getField();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "")
            {
                if (btnEdit.Text == "Edit")
                {
                    enableOrDisable(true);
                    btnCancel.Text = "Cancel";
                    btnEdit.Text = "Update";
                    gbQB.Text = "Edit Question Bank";
                    btnSave.Enabled = false;
                }
                else
                {
                    string status = "";
                    if (rbON.Checked)
                        status = "ON";
                    else if (rbOFF.Checked)
                        status = "OFF";

                    if (CheckField() == true)
                    {
                        errorProvider1.Clear();
                        English_Learning_Application.Entity.QuestionBank Q = new Entity.QuestionBank(txtTitle.Text, int.Parse(CountQuestion.Text), int.Parse(txtDuration.Text), status, temp_user_Id);
                        QB.UpdateQuestonBank(Q, int.Parse(txtID.Text));
                        MessageBox.Show("Question Bank Has Been Updated", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clearField();
                        setDatagridview(dgQuestion);
                    }

                    getField();
                    enableOrDisable(false);
                    btnEdit.Text = "Edit";
                    btnCancel.Text = "Close";
                    gbQB.Text = "Form Question Bank";
                    btnSave.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("Please, Choose the Question Bank to Edit...!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dgQuestion.Focus();
            }
        }

        private void inputToField(string title, string count, string duration, string status)
        {
            txtTitle.Text = title;
            CountQuestion.Value = int.Parse(count);
            txtDuration.Text = duration;
            if (status == "ON")
                rbON.Checked = true;
            else
                rbOFF.Checked = true;
        }

        private void getField()
        {
            if (txtID.Text != "")
            {
                string title = getColumn(dgQuestion, 1);
                string count = getColumn(dgQuestion, 2);
                string duration = getColumn(dgQuestion, 3);
                string status = getColumn(dgQuestion, 5);

                // Input Column To Field
                txtTitle.Text = title;
                txtTitle2.Text = title;
                CountQuestion.Value = int.Parse(count);
                CountQuestion2.Value = int.Parse(count);
                txtDuration.Text = duration;
                txtDuration2.Text = duration;
                if (status == "ON")
                {
                    rbON.Checked = true;
                    rbON2.Checked = true;
                }
                else
                {
                    rbOFF.Checked = true;
                    rbOFF2.Checked = true;
                }

                enableOrDisable(false);

            }
        }

        private void enableOrDisable(bool value)
        {
            txtTitle.Enabled = value;
            CountQuestion.Enabled = value;
            txtDuration.Enabled = value;
            rbON.Enabled = value;
            rbOFF.Enabled = value;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "")
            {
                DialogResult dr = MessageBox.Show("Are You Sure to Delete This Question Bank?", "QUESTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    QB.DeleteQuestonBank(int.Parse(txtID.Text));
                    MessageBox.Show("Question Bank Has Been Deleted!", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                clearField();
                setDatagridview(dgQuestion);
                btnDelete.Visible = false;
                btnEdit.Visible = false;
                btnDetail.Visible = false;
            }
            else
            {
                MessageBox.Show("Please, Choose the Question Bank to Deleted...!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dgQuestion.Focus();
            }
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "")
            {
                int count_of_questions = int.Parse(getColumn(dgQuestion, 2));
                //int count_of_added = int.Parse(getColumn(dgQuestion, 7));
                int count_of_added = QB.GetCount_of_Question(int.Parse(txtTemp2.Text));

                getField();
                setDatagridview2(dgQuestion2, int.Parse(txtID.Text));

                tabControl1.TabPages.Add(tabDetail);
                TabPage t = tabControl1.TabPages[1];
                tabControl1.SelectedTab = t;

                tabControl1.TabPages.Remove(tabBank);

                if (count_of_questions > count_of_added)
                {
                    btnAddQuestion.Enabled = true;
                }
                else
                {
                    btnAddQuestion.Enabled = false;
                }
                clearField();
            }
            else
            {
                MessageBox.Show("Please, Choose the Question Bank...!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dgQuestion.Focus();
            }
        }

        private void btnClose2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnBack2_Click(object sender, EventArgs e)
        {
            getField();
            clearField();

            tabControl1.TabPages.Add(tabBank);
            TabPage t = tabControl1.TabPages[1];
            tabControl1.SelectedTab = t;

            tabControl1.TabPages.Remove(tabDetail);
        }

        private void btnAddQuestion_Click(object sender, EventArgs e)
        {
            ucAddQuestion1.setFlag(1);
            ucAddQuestion1.Visible = true;
            ucAddQuestion1.temp(int.Parse(CountQuestion2.Text), QB.GetCount_of_Question(int.Parse(txtTemp2.Text)), txtTemp2.Text);
        }

        public void setDatagridview2(DataGridView DG, int bank_id)
        {
            DG.DataSource = QB.Show_Question(bank_id);
            //Start Code Data Binding
            DataTable DT = QB.Show_Question(bank_id);
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
            bindingSource2.DataSource = listTbl;
            bindingNavigator2.BindingSource = bindingSource2;
            DG.DataSource = (DT.Rows.Count > 0 ? listTbl[bindingSource2.Position] : DT);
            //Ending Code Data Binding

            /*DG.Columns[0].Visible = false;
            DG.Columns[1].Visible = false;
            DG.Columns[2].HeaderText = "Number";
            DG.Columns[3].HeaderText = "Question";
            DG.Columns[4].HeaderText = "Type";*/

            settingHeaderGrid(DG);

        }

        public void searchDatagridview2(DataGridView DG, int bank_id, string keyword)
        {
            DG.DataSource = QB.Search_Question(bank_id, keyword);
            //Start Code Data Binding
            DataTable DT = QB.Search_Question(bank_id, keyword);
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
            bindingSource2.DataSource = listTbl;
            bindingNavigator2.BindingSource = bindingSource2;
            DG.DataSource = (DT.Rows.Count > 0 ? listTbl[bindingSource2.Position] : DT);
            //Ending Code Data Binding

            /*DG.Columns[0].Visible = false;
            DG.Columns[1].Visible = false;
            DG.Columns[2].HeaderText = "Number";
            DG.Columns[3].HeaderText = "Question";
            DG.Columns[4].HeaderText = "Type";           */

            settingHeaderGrid(DG);

        }

        private void bindingSource2_PositionChanged(object sender, EventArgs e)
        {
            //int RowCount = dgQuestion2.Rows.Count;
            //if (RowCount == 0)
                setDatagridview2(dgQuestion2, int.Parse(txtID.Text));
        }

        private void txtSearch2_TextChanged(object sender, EventArgs e)
        {
            searchDatagridview2(dgQuestion2, int.Parse(txtID.Text), txtSearch2.Text);
        }

        private void dgQuestion2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = getColumn(dgQuestion2, 2);
            txtRow.Text = getColumn(dgQuestion2, 0);
            txtTemp.Text = getColumn(dgQuestion2, 4);
            if (txtID.Text != "")
            {
                btnEdit2.Visible = true;
                btnDelete2.Visible = true;
                btnDetail2.Visible = true;
            }
            else
            {
                btnEdit2.Visible = false;
                btnDelete2.Visible = false;
                btnDetail2.Visible = false;
            }
            getField();
        }

        private void btnEdit2_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "")
            {
                string detail_id = getColumn(dgQuestion2, 0);
                string bank_id = getColumn(dgQuestion2, 1);
                string count = getColumn(dgQuestion2, 2);
                string question = getColumn(dgQuestion2, 3);
                string type = getColumn(dgQuestion2, 4);
                string choice1 = getColumn(dgQuestion2, 5);
                string choice2 = getColumn(dgQuestion2, 6);
                string choice3 = getColumn(dgQuestion2, 7);
                string choice4 = getColumn(dgQuestion2, 8);
                string choice5 = getColumn(dgQuestion2, 9);
                string choice6 = getColumn(dgQuestion2, 10);
                string choice7 = getColumn(dgQuestion2, 11);
                string answer = getColumn(dgQuestion2, 12);
                string count_of_choice = getColumn(dgQuestion2, 13);

                ucAddQuestion1.setFlag(2);
                ucAddQuestion1.Visible = true;
                ucAddQuestion1.Add_to_Field(detail_id, bank_id, count, question, type, choice1, choice2, choice3, choice4, choice5, choice6, choice7, answer, count_of_choice);
            }
            else
            {
                MessageBox.Show("Please, Choose the Question to Edit...!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dgQuestion.Focus();
            }
        }

        private void btnDelete2_Click(object sender, EventArgs e)
        {
            if (txtRow.Text != "")
            {
                DialogResult dr = MessageBox.Show("Are You Sure to Delete This Question?", "QUESTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    QB.DeleteQuestions(int.Parse(txtRow.Text));
                    MessageBox.Show("Question Has Been Deleted!", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                clearField();
                RefreshGridView();
                btnDelete2.Visible = false;
                btnEdit2.Visible = false;
                btnDetail2.Visible = false;

                int count_of_questions = QB.GetCount_of_Question_in_Bank(int.Parse(txtTemp2.Text));
                int count_of_added = QB.GetCount_of_Question(int.Parse(txtTemp2.Text));

                if (count_of_questions > count_of_added)
                {
                    btnAddQuestion.Enabled = true;
                }
                else
                {
                    btnAddQuestion.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Please, Choose the Question Bank to Deleted...!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dgQuestion.Focus();
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            if (txtTemp2.Text != "")
            {
                Form FR = new FormRun(int.Parse(txtTemp2.Text), 0);
                FR.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Please, Choose the Question Bank to Run...!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dgQuestion.Focus();
            }
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            uC_Set_Students1.Visible = true;
            uC_Set_Students1.temp(txtTemp2.Text, temp_user_Id);
            uC_Set_Students1.RefreshGridView();
        }

        
    }
}

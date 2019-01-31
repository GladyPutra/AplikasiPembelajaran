using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using English_Learning_Application.Controller;
using English_Learning_Application.Boundary;
using English_Learning_Application.Entity;

namespace English_Learning_Application.Boundary
{
    public partial class UCAddQuestion : UserControl
    {
        private int temp_total_questions = 0;

        public UCAddQuestion()
        {
            InitializeComponent();
        }

        QuestionBankControl QB = new QuestionBankControl();
        ShowException SE = new ShowException();

        public void temp(int total_question, int count_question, string bank_id)
        {
            countNumber.Value = count_question + 1;
            //countNumber.Maximum = total_question;
            lblTotalQuestion.Text = "of " + total_question + " Questions";
            txtTemp.Text = bank_id;
            this.temp_total_questions = total_question;
        }

        private void UCAddQuestion_Load(object sender, EventArgs e)
        {
            
        }

        int flag = 0;
        public void setFlag(int flag)
        {
            this.flag = flag;
        }

        private void cbChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbChoice.Text == "Multiple Choice")
            {
                lblChoice.Visible = true;
                lblCount.Visible = true;
                lblTrueAnswer.Visible = false;
                cbCountChoice.Visible = true;
                cbTrueFalse.Visible = false;
            }
            else if (cbChoice.Text == "True - False")
            {
                lblChoice.Visible = false;
                lblCount.Visible = false;
                lblTrueAnswer.Visible = true;
                cbCountChoice.Visible = false;
                cbTrueFalse.Visible = true;
                VisibleMultipleChoice(false, false, false, false, false, false, false);
                cbCountChoice.Text = "Choose";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            Clear_Field();
            //FormBank myParent = (FormBank)this.Parent;
            //myParent.Enabled();
        }

        private void cbCountChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCountChoice.Text == "3")
            {
                VisibleMultipleChoice(true, true, true, false, false, false, false);
            }
            else if (cbCountChoice.Text == "5")
            {
                VisibleMultipleChoice(true, true, true, true, true, false, false);
            }
            else if (cbCountChoice.Text == "7")
            {
                VisibleMultipleChoice(true, true, true, true, true, true, true);
            }
        }

        private void VisibleMultipleChoice(bool value1, bool value2, bool value3, bool value4, bool value5, bool value6, bool value7)
        {
            lblChoice1.Visible = value1;
            txtChoice1.Visible = value1;
            lblChoice2.Visible = value2;
            txtChoice2.Visible = value2;
            lblChoice3.Visible = value3;
            txtChoice3.Visible = value3;
            lblChoice4.Visible = value4;
            txtChoice4.Visible = value4;
            lblChoice5.Visible = value5;
            txtChoice5.Visible = value5;
            lblChoice6.Visible = value6;
            txtChoice6.Visible = value6;
            lblChoice7.Visible = value7;
            txtChoice7.Visible = value7;

            if (cbChoice.Text == "True - False")
            {
                lblAnswer.Visible = false;
                cbAnswer.Visible = false;
                lblMultiple.Visible = false;
            }
            else
            {
                lblAnswer.Visible = true;
                cbAnswer.Visible = true;
                lblMultiple.Visible = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string answer = "";
            int count_of_choice = 0;

            if (flag == 1)
            {
                if (Check_Field() == true)
                {
                    errorProvider1.Clear();
                    if (cbChoice.Text == "Multiple Choice")
                    {
                        answer = cbAnswer.Text;
                        count_of_choice = int.Parse(cbCountChoice.Text);
                    }
                    else if (cbChoice.Text == "True - False")
                    {
                        answer = cbTrueFalse.Text;
                        txtChoice1.Clear(); txtChoice2.Clear(); txtChoice3.Clear(); txtChoice4.Clear();
                        txtChoice5.Clear(); txtChoice6.Clear(); txtChoice7.Clear();
                    }

                    English_Learning_Application.Entity.Questions Q = new Entity.Questions(int.Parse(txtTemp.Text), int.Parse(countNumber.Text),
                             txtQuestion.Text, cbChoice.Text, txtChoice1.Text, txtChoice2.Text, txtChoice3.Text, txtChoice4.Text, txtChoice5.Text,
                             txtChoice6.Text, txtChoice7.Text, answer, count_of_choice);

                    QB.InsertQuestion(Q);
                    MessageBox.Show("Add New Question has Successfuly", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (flag == 2)
            {
                if (Check_Field() == true)
                {
                    errorProvider1.Clear();
                    if (cbChoice.Text == "Multiple Choice")
                    {
                        answer = cbAnswer.Text;
                        count_of_choice = int.Parse(cbCountChoice.Text);
                    }
                    else if (cbChoice.Text == "True - False")
                    {
                        answer = cbTrueFalse.Text;
                        txtChoice1.Clear(); txtChoice2.Clear(); txtChoice3.Clear(); txtChoice4.Clear(); 
                        txtChoice5.Clear(); txtChoice6.Clear(); txtChoice7.Clear();
                    }

                    English_Learning_Application.Entity.Questions Q = new Entity.Questions(int.Parse(countNumber.Text), txtQuestion.Text, 
                        cbChoice.Text, txtChoice1.Text, txtChoice2.Text, txtChoice3.Text, txtChoice4.Text, txtChoice5.Text, txtChoice6.Text,
                        txtChoice7.Text, answer, count_of_choice);

                    DialogResult dr = MessageBox.Show("Are You Sure to Update This Question?", "QUESTION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        QB.UpdateQuestion(Q, int.Parse(txtID.Text));
                        MessageBox.Show("Question Bank Has Been Updated!", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    } 
                }
            }
            Clear_Field();
            this.Hide();
            FormBank FB = (FormBank)this.Parent;
            FB.RefreshGridView();
            FB.clearField();
        }

        private bool Check_Field()
        {
            bool temp = true;

            if (txtQuestion.Text == "")
            {
                errorProvider1.SetError(txtQuestion, "Please, Insert the Questions...!");
                txtQuestion.Focus();
                temp = false;
            }

            if (cbChoice.Text == "Multiple Choice")
            {
                if (cbAnswer.Text == "" || cbAnswer.Text == "Choose")
                {
                    errorProvider1.SetError(cbAnswer, "Please, Choose the True Answer...!");
                    cbAnswer.Focus();
                    temp = false;
                }
            }
            else if (cbChoice.Text == "True - False")
            {
                if (cbTrueFalse.Text == "" || cbTrueFalse.Text == "Choose")
                {
                    errorProvider1.SetError(cbTrueFalse, "Please, Choose the True Answer...!");
                    cbTrueFalse.Focus();
                    temp = false;
                }
            }

            return temp;
        }

        private void Clear_Field()
        {
            txtQuestion.Clear();
            txtChoice1.Clear();
            txtChoice2.Clear();
            txtChoice3.Clear();
            txtChoice4.Clear();
            txtChoice5.Clear();
            txtChoice6.Clear();
            txtChoice7.Clear();
            cbAnswer.Text = "Choose";
            cbCountChoice.Text = "Choose";
            cbTrueFalse.Text = "Choose";
        }

        public void Add_to_Field(string detail_id, string bank_id, string countNumber, string question, string type, string choice1, string choice2, string choice3,
            string choice4, string choice5, string choice6, string choice7, string answer, string count)
        {
            this.txtID.Text = detail_id;
            this.txtTemp.Text = bank_id;
            this.countNumber.Value = int.Parse(countNumber);
            this.txtQuestion.Text = question;
            this.cbChoice.Text = type;
            this.cbCountChoice.Text = count;
            this.txtChoice1.Text = choice1;
            this.txtChoice2.Text = choice2;
            this.txtChoice3.Text = choice3;
            this.txtChoice4.Text = choice4;
            this.txtChoice5.Text = choice5;
            this.txtChoice6.Text = choice6;
            this.txtChoice7.Text = choice7;
            lblTotalQuestion.Text = "of " + QB.GetCount_of_Question(Convert.ToInt32(bank_id)) + " Questions";
            if (type == "Multiple Choice")
            {
                cbAnswer.Text = answer;
            }
            else if (type == "True - False")
            {
                cbTrueFalse.Text = answer;
            }
        }
    }
}

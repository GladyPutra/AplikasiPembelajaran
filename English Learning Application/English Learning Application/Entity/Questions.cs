using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace English_Learning_Application.Entity
{
    class Questions
    {
        int bank_id, question_number, count_of_choice;
        string question, type, answer1, answer2, answer3, answer4, answer5, answer6, answer7, true_answer;

        // For Insert
        public Questions(int bank_id, int question_number, string question, string type, string answer1, string answer2, 
            string answer3, string answer4, string answer5, string answer6, string answer7, string true_answer, int count_of_choice)
        {
            this.bank_id = bank_id;
            this.question_number = question_number;
            this.question = question;
            this.type = type;
            this.count_of_choice = count_of_choice;
            this.answer1 = answer1;
            this.answer2 = answer2;
            this.answer3 = answer3;
            this.answer4 = answer4;
            this.answer5 = answer5;
            this.answer6 = answer6;
            this.answer7 = answer7;
            this.true_answer = true_answer;
        }

        // For Update
        public Questions(int question_number, string question, string type, string answer1, string answer2, string answer3, string answer4,
            string answer5, string answer6, string answer7, string true_answer, int count_of_choice)
        {
            this.question_number = question_number;
            this.question = question;
            this.type = type;
            this.answer1 = answer1;
            this.answer2 = answer2;
            this.answer3 = answer3;
            this.answer4 = answer4;
            this.answer5 = answer5;
            this.answer6 = answer6;
            this.answer7 = answer7;
            this.true_answer = true_answer;
            this.count_of_choice = count_of_choice;
        }

        public int Bank_id
        {
            get { return bank_id; }
            set { bank_id = value; }
        }

        public int Question_number
        {
            get { return question_number; }
            set { question_number = value; }
        }

        public int Count_of_choice
        {
            get { return count_of_choice; }
            set { count_of_choice = value; }
        }

        public string Question
        {
            get { return question; }
            set { question = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public string Answer1
        {
            get { return answer1; }
            set { answer1 = value; }
        }

        public string Answer2
        {
            get { return answer2; }
            set { answer2 = value; }
        }

        public string Answer3
        {
            get { return answer3; }
            set { answer3 = value; }
        }

        public string Answer4
        {
            get { return answer4; }
            set { answer4 = value; }
        }

        public string Answer5
        {
            get { return answer5; }
            set { answer5 = value; }
        }

        public string Answer6
        {
            get { return answer6; }
            set { answer6 = value; }
        }

        public string Answer7
        {
            get { return answer7; }
            set { answer7 = value; }
        }

        public string True_answer
        {
            get { return true_answer; }
            set { true_answer = value; }
        }
    }
}

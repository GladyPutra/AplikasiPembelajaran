using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace English_Learning_Application.Entity
{
    class QuestionBank
    {
        private string title, status;
        private int count, duration, user_create;

        public QuestionBank(string title, int count, int duration, string status, int user_create)
        {
            this.title = title;
            this.count = count;
            this.duration = duration;
            this.status = status;
            this.user_create = user_create;
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        public int Duration
        {
            get { return duration; }
            set { duration = value; }
        }

        public int User_create
        {
            get { return user_create; }
            set { user_create = value; }
        }
    }
}

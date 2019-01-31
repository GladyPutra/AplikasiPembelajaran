using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace English_Learning_Application.Entity
{
    class Score
    {
        private int user_id, bank_id, duration, user_create;
        private float scoring;

        public Score(int user_id, int bank_id, float scoring, int duration, int user_create)
        {
            this.user_id = user_id;
            this.bank_id = bank_id;
            this.scoring = scoring;
            this.duration = duration;
            this.user_create = user_create;
        }

        public int User_id
        {
            get { return user_id; }
            set { user_id = value; }
        }

        public int User_create
        {
            get { return user_create; }
            set { user_create = value; }
        }

        public int Bank_id
        {
            get { return bank_id; }
            set { bank_id = value; }
        }

        public int Duration
        {
            get { return duration; }
            set { duration = value; }
        }

        public float Scoring
        {
            get { return scoring; }
            set { scoring = value; }
        }
    }
}

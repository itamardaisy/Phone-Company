using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class User
    {
        private int id;
        private string name;
        private string email;
        private string password;
        private int callAnswer;
        private DateTime signDate;
        private int type;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public int Type
        {
            get { return type; }
            set { type = value; }
        }

        public DateTime SignDate
        {
            get { return signDate; }
            set { signDate = value; }
        }

        public int CallAnswer
        {
            get { return callAnswer; }
            set { callAnswer = value; }
        }
    }
}

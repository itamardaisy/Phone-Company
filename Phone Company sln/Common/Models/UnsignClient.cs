﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class UnsignClient
    {
        private int id;
        private string name;
        private string lastName;
        private int clientTypeId;
        private string adress;
        private string contactNumber;
        private DateTime signDate;
        private DateTime unsignDate;
        private int callToCenter;
        private int userId;

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

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public int ClientTypeId
        {
            get { return clientTypeId; }
            set { clientTypeId = value; }
        }

        public string Adress
        {
            get { return adress; }
            set { adress = value; }
        }

        public string ContactNumber
        {
            get { return contactNumber; }
            set { contactNumber = value; }
        }

        public DateTime SignDate
        {
            get { return signDate; }
            set { signDate = value; }
        }

        public DateTime UnsignDate
        {
            get { return unsignDate; }
            set { unsignDate = value; }
        }

        public int CallToCenter
        {
            get { return callToCenter; }
            set { callToCenter = value; }
        }

        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }
    }
}

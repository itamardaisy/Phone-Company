using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Employee.Models
{
    internal class SelectedNumber
    {
        private int id;
        private string firstNumber;
        private string secondNumber;
        private string thirdNumber;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string FirstNumber
        {
            get { return firstNumber; }
            set { firstNumber = value; }
        }

        public string SecondNumber
        {
            get { return secondNumber; }
            set { secondNumber = value; }
        }

        public string ThirdNumber
        {
            get { return thirdNumber; }
            set { thirdNumber = value; }
        }
    }
}
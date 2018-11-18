using Common.Interfaces;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Repositories
{
    public class SelectedNumbersRepository : ISelectedNumbersRepository
    {
        public bool AddNewNumber(SelectedNumber selectedNumber)
        {
            throw new NotImplementedException();
        }

        public bool DeleteNumber(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateNumber(int id, string numberToReplace, string replacingNumber)
        {
            throw new NotImplementedException();
        }
    }
}

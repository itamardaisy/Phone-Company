using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface ISelectedNumbersRepository
    {
        void AddNewNumber(SelectedNumber selectedNumber);

        bool DeleteNumber(int id);

        bool UpdateNumber(int id, string numberToReplace, string replacingNumber);
    }
}

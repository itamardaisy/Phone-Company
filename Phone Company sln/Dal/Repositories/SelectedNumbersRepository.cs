using Common.Interfaces;
using Common.Models;
using Dal.DataInitializer;
using Dal.ModelConverters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Repositories
{
    public class SelectedNumbersRepository : ISelectedNumbersRepository
    {
        PhoneCompanyContext context;

        public SelectedNumbersRepository(PhoneCompanyContext context)
        {
            this.context = context;
        }

        public void AddNewNumber(SelectedNumber selectedNumber)
        {
            context.SelectedNumbers.Add(selectedNumber.CommonToDb());
            context.SaveChanges();
        }

        public bool DeleteNumber(int id)
        {
            return false;
        }

        public bool UpdateNumber(int id, string numberToReplace, string replacingNumber)
        {
            throw new NotImplementedException();
        }
    }
}

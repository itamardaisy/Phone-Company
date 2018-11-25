using Common.Interfaces;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.ModelConverters;
using Dal.DataInitializer;
using Dal.DataModels;

namespace Dal.Repositories
{
    public class LineRepository : ILineRepository
    {
        public void AddNewLine(Line line)
        {
            using(PhoneCompanyContext context = new PhoneCompanyContext())
            {
                context.Lines.Add(line.CommonToDb());
                context.SaveChanges();
            }
        }

        public Line GetLine(string lineNumber)
        {
            using(PhoneCompanyContext context = new PhoneCompanyContext())
            {
                return context.Lines.FirstOrDefault(x => x.Number == lineNumber).DbToCommon();
            }
        }

        public void UpdateLine(Line line)
        {
            using(PhoneCompanyContext context = new PhoneCompanyContext())
            {
                DbLine dbLine = context.Lines.FirstOrDefault(x => x.Id == line.Id);
                UpdateTheLineProperties(dbLine, line);
                context.SaveChanges();
            }
        }

        private void UpdateTheLineProperties(DbLine dbLine, Line line)
        {
            dbLine.ClientId = line.ClientId;
            dbLine.Id = line.Id;
            dbLine.Number = line.Number;
            dbLine.PackageId = line.PackageId;
            dbLine.Status = line.Status;
        }
    }
}

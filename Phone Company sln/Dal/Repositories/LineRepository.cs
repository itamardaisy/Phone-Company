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
using Common.EnvironmentService;
using Common.Exceptions;

namespace Dal.Repositories
{
    public class LineRepository : ILineRepository
    {
        public void AddNewLine(Line line)
        {
            using(PhoneCompanyContext context = new PhoneCompanyContext())
            {
                try{
                    context.Lines.Add(line.CommonToDb());
                    context.SaveChanges();
                }
                catch (ArgumentNullException ex){
                    Services.WriteExceptionsToLogger(ex);
                    throw new GetFromDatabaseException(ex.Message);
                }
                catch (Exception ex){
                    Services.WriteExceptionsToLogger(ex);
                    throw new DataProcedureException(ex.Message);
                }
            }
        }

        public Line GetLine(string lineNumber)
        {
            using(PhoneCompanyContext context = new PhoneCompanyContext())
            {
                try{
                    return context.Lines.FirstOrDefault(x => x.Number == lineNumber).DbToCommon();
                }
                catch (ArgumentNullException ex){
                    Services.WriteExceptionsToLogger(ex);
                    throw new GetFromDatabaseException(ex.Message);
                }
                catch (Exception ex){
                    Services.WriteExceptionsToLogger(ex);
                    throw new DataProcedureException(ex.Message);
                }
            }
        }

        public void UpdateLine(Line line)
        {
            using(PhoneCompanyContext context = new PhoneCompanyContext())
            {
                try{
                    DbLine dbLine = context.Lines.FirstOrDefault(x => x.Id == line.Id);
                    UpdateTheLineProperties(dbLine, line);
                    context.SaveChanges();
                }
                catch (ArgumentNullException ex){
                    Services.WriteExceptionsToLogger(ex);
                    throw new GetFromDatabaseException(ex.Message);
                }
                catch (Exception ex){
                    Services.WriteExceptionsToLogger(ex);
                    throw new DataProcedureException(ex.Message);
                }
            }
        }

        public void SetPackage(int ClientId, int newPackageId)
        {
            using (PhoneCompanyContext context = new PhoneCompanyContext())
            {
                try{
                    context.Lines.FirstOrDefault(x => x.ClientId == ClientId).PackageId = newPackageId;
                    context.SaveChanges();
                }
                catch (ArgumentNullException ex){
                    Services.WriteExceptionsToLogger(ex);
                    throw new GetFromDatabaseException(ex.Message);
                }
                catch (Exception ex){
                    Services.WriteExceptionsToLogger(ex);
                    throw new DataProcedureException(ex.Message);
                }
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
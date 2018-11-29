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
        /// <summary>
        /// This method gets a new line and add it to the context.
        /// </summary>
        /// <param name="line"> The new line </param>
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

        /// <summary>
        /// This method gets a linenumber and returns the line.
        /// </summary>
        /// <param name="lineNumber"> The lineNumber </param>
        /// <returns> A line object </returns>
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

        /// <summary>
        /// This method get an updated line and replace it with line that matchs with the lineId.
        /// </summary>
        /// <param name="line"> The updated line. </param>
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

        /// <summary>
        /// This method get a client id that indicate to the client that want to set his package,
        /// and a new package id that indicate to the new package.
        /// </summary>
        /// <param name="ClientId"> The client id </param>
        /// <param name="newPackageId"> The package id </param>
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

        /// <summary>
        /// Gets the updated line and the line that needs to update and merge with the properties.
        /// </summary>
        /// <param name="dbLine"> The database line </param>
        /// <param name="line"> The incoming line </param>
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
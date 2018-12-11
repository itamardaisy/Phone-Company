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
using Common.Helpers;

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
            try
            {
                using (PhoneCompanyContext context = new PhoneCompanyContext())
                {
                    context.Lines.Add(line.CommonToDb());
                    context.SaveChanges();
                }
            }
            catch (ArgumentNullException ex)
            {
                Services.WriteExceptionsToLogger(ex);
                throw new GetFromDatabaseException(ex.Message);
            }
            catch (Exception ex)
            {
                Services.WriteExceptionsToLogger(ex);
                throw new DataProcedureException(ex.Message);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="lineId"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public double GetActualMonthMinuteCalls(int lineId, DateTime date)
        {
            try
            {
                using (PhoneCompanyContext context = new PhoneCompanyContext())
                {
                    double minutSum = 0.0;
                    var calls = context.Calls.Where(x => x.LineId == lineId && x.CallDate.Month == date.Month).Select(x => x.DbToCommon()).ToList();
                    foreach (var call in calls)
                        minutSum += call.Duration;
                    return minutSum;
                }
            }
            catch (Exception ex)
            {
                Services.WriteExceptionsToLogger(ex);
                throw new Exception("Problem in the GetActualMonthMinuteCalls method");
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="lineId"></param>
        /// <param name="now"></param>
        /// <returns></returns>
        public double GetTotalMinutesTopNumber(int lineId, DateTime now)
        {
            var lineCalls = GetLineCalls(lineId, now);
            List<NumberShows> numberCounters = new List<NumberShows>();
            CountTheCallByDestinationNumbers(numberCounters, lineCalls);
            var topNumbers = GetTopFiveCalls(numberCounters);
            return CountTheTopFiveTotalMinuts(topNumbers, lineCalls);
        }

        private double CountTheTopFiveTotalMinuts(List<NumberShows> topNumbers, List<DbCall> lineCalls)
        {
            double MinutsCounter = 0.0;
            for (int i = 0; i < topNumbers.Count; i++)
                MinutsCounter += lineCalls.Where(x => x.DestinationNumber == topNumbers[i].LineNumber).FirstOrDefault().Duration;
            return MinutsCounter;
        }

        private List<NumberShows> GetTopFiveCalls(List<NumberShows> numberCounters)
        {
            return numberCounters.OrderByDescending(x => x.ShowsCounter).Reverse().Take(5).ToList();
        }

        private void CountTheCallByDestinationNumbers(List<NumberShows> numberCounters, List<DbCall> lineCalls)
        {
            for (int i = 0; i < lineCalls.Count; i++)
                if (!numberCounters.Any(x => x.LineNumber == lineCalls[i].DestinationNumber))
                    numberCounters.Add(new NumberShows { ShowsCounter = 1, LineNumber = lineCalls[i].DestinationNumber });
                else
                    numberCounters.Where(x => x.LineNumber == lineCalls[i].DestinationNumber).FirstOrDefault().ShowsCounter++;
        }

        private List<DbCall> GetLineCalls(int lineId, DateTime now)
        {
            using (PhoneCompanyContext context = new PhoneCompanyContext())
            {
                return context.Calls.Where(x => x.LineId == lineId && x.CallDate.Month == now.Month).ToList();
            }
        }

        public double GetTotalMinutesFamily(int lineId, DateTime now)
        {
            using (PhoneCompanyContext context = new PhoneCompanyContext())
            {
                double minutsCounter = 0.0;
                var familyCalls = context.Calls.Where(x => x.FamilyCall == true).ToList();
                foreach (var call in familyCalls)
                    minutsCounter += call.Duration;
                return minutsCounter;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="lineId"></param>
        /// <param name="now"></param>
        /// <returns></returns>
        public double GetTotalMinutesThreeTopNumber(int lineId, DateTime now)
        {
            using (PhoneCompanyContext context = new PhoneCompanyContext())
            {
                double MinutsCounter = 0.0;
                var lineCalls = GetLineCalls(lineId, now);
                var clientSelectedNumber = context.SelectedNumbers.FirstOrDefault(x => x.LineId == lineId);
                for (int i = 0; i < lineCalls.Count; i++)
                    if (lineCalls[i].DestinationNumber == clientSelectedNumber.FirstNumber ||
                        lineCalls[i].DestinationNumber == clientSelectedNumber.SecondNumber ||
                        lineCalls[i].DestinationNumber == clientSelectedNumber.ThirdNumber)
                        MinutsCounter += lineCalls[i].Duration;
                return MinutsCounter;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="lineId"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public int GetActualMonthSMSs(int lineId, DateTime date)
        {
            using (PhoneCompanyContext context = new PhoneCompanyContext())
            {
                var SMSs = context.SMSs.Where(x => x.LineId == lineId && x.SmsDate.Month == date.Month).Select(x => x.DbToCommon()).ToList();
                return SMSs.Count;
            }
        }

        /// <summary>
        /// This method gets a linenumber and returns the line.
        /// </summary>
        /// <param name="lineNumber"> The lineNumber </param>
        /// <returns> A line object </returns>
        public Line GetLine(string lineNumber)
        {
            try
            {
                using (PhoneCompanyContext context = new PhoneCompanyContext())
                {
                    return context.Lines.FirstOrDefault(x => x.Number == lineNumber).DbToCommon();
                }
            }
            catch (ArgumentNullException ex)
            {
                Services.WriteExceptionsToLogger(ex);
                throw new GetFromDatabaseException(ex.Message);
            }
            catch (Exception ex)
            {
                Services.WriteExceptionsToLogger(ex);
                throw new DataProcedureException(ex.Message);
            }
        }

        /// <summary>
        /// This method get an updated line and replace it with line that matchs with the lineId.
        /// </summary>
        /// <param name="line"> The updated line. </param>
        public void UpdateLine(Line line)
        {
            try
            {
                using (PhoneCompanyContext context = new PhoneCompanyContext())
                {
                    DbLine dbLine = context.Lines.FirstOrDefault(x => x.Id == line.Id);
                    UpdateTheLineProperties(dbLine, line);
                    context.SaveChanges();
                }
            }
            catch (ArgumentNullException ex)
            {
                Services.WriteExceptionsToLogger(ex);
                throw new GetFromDatabaseException(ex.Message);
            }
            catch (Exception ex)
            {
                Services.WriteExceptionsToLogger(ex);
                throw new DataProcedureException(ex.Message);
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
            try
            {
                using (PhoneCompanyContext context = new PhoneCompanyContext())
                {
                    context.Lines.FirstOrDefault(x => x.ClientId == ClientId).PackageId = newPackageId;
                    context.SaveChanges();
                }
            }
            catch (ArgumentNullException ex)
            {
                Services.WriteExceptionsToLogger(ex);
                throw new GetFromDatabaseException(ex.Message);
            }
            catch (Exception ex)
            {
                Services.WriteExceptionsToLogger(ex);
                throw new DataProcedureException(ex.Message);
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

        /// <summary>
        ///
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        public List<Line> GetClientLines(int clientId)
        {
            using (PhoneCompanyContext context = new PhoneCompanyContext())
            {
                List<Line> lines = new List<Line>();
                var dbLines = context.Lines.Where(x => x.ClientId == clientId).ToList();
                foreach (var item in dbLines)
                    lines.Add(item.DbToCommon());
                if (lines.Count != 0)
                    return lines;
                else
                    return null;
            }
        }
    }
}
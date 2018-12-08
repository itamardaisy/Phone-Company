using Common.Models;
using Dal.DataInitializer;
using Dal.Repositories;
using PackageOptimtzation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientBL.DetailServices
{
    public class DetailService
    {
        private readonly ClientRepository CLIENT_REPOSITORY;
        private readonly LineRepository LINE_REPOSITORY;
        private readonly OptimalPackage OPTIMAL_PACKAGE;

        public DetailService()
        {
            PhoneCompanyContext context = new PhoneCompanyContext();
            CLIENT_REPOSITORY = new ClientRepository(context);
            LINE_REPOSITORY = new LineRepository(context);
            OPTIMAL_PACKAGE = new OptimalPackage();
        }

        /// <summary>
        /// Gets the a sum of call minuts for the past month.
        /// </summary>
        /// <param name="client"> The client who requested </param>
        /// <param name="lineNumber"> The line number </param>
        /// <returns> Minuts </returns>
        public double GetTotalMinutes(Client client, string lineNumber)
        {
            var line = LINE_REPOSITORY.GetClientLines(client.Id).Where(x => x.Number == lineNumber).FirstOrDefault();
            return LINE_REPOSITORY.GetActualMonthMinuteCalls(line.Id, DateTime.Now);
        }

        public List<string> GetClientLines(int clientId)
        {
            List<string> lines = new List<string>();
            var theLines = LINE_REPOSITORY.GetClientLines(clientId);
            foreach (var item in theLines)
            {
                lines.Add(item.Number);
            }
            return lines;
        }

        /// <summary>
        /// Gets the Total smss that actualy has been in the past month.
        /// </summary>
        /// <param name="client"> The client that requested </param>
        /// <param name="lineNumber"> The line number </param>
        /// <returns> The number of smss </returns>
        public int GetTotalSMS(Client client, string lineNumber)
        {
            var line = LINE_REPOSITORY.GetClientLines(client.Id).Where(x => x.Number == lineNumber).FirstOrDefault();
            return LINE_REPOSITORY.GetActualMonthSMSs(line.Id, DateTime.Now);

        }

        /// <summary>
        /// Get the Total minuts calls that has been with the top 5 number.
        /// </summary>
        /// <param name="client"> The client that requested </param>
        /// <param name="lineNumber"> The line number </param>
        /// <returns> The call minuts </returns>
        public double GetTotalMinutesTopNumber(Client client, string lineNumber)
        {
            var line = LINE_REPOSITORY.GetClientLines(client.Id).Where(x => x.Number == lineNumber).FirstOrDefault();
            return LINE_REPOSITORY.GetTotalMinutesTopNumber(line.Id, DateTime.Now);
        }

        /// <summary>
        /// Gets the sum of minuts with the selected numbers.
        /// </summary>
        /// <param name="client"> The client that requested </param>
        /// <param name="lineNumber"> The line number </param>
        /// <returns> The minuts </returns>
        public double GetTotalMinutesThreeTopNumber(Client client, string lineNumber)
        {
            var line = LINE_REPOSITORY.GetClientLines(client.Id).Where(x => x.Number == lineNumber).FirstOrDefault();
            return LINE_REPOSITORY.GetTotalMinutesThreeTopNumber(line.Id, DateTime.Now);
        }

        /// <summary>
        /// Gets the total minuts inside the family.
        /// </summary>
        /// <param name="client"> The client that requested </param>
        /// <param name="lineNumber"> The line number </param>
        /// <returns> The minuts </returns>
        public double GetTotalMinutesFamily(Client client, string lineNumber)
        {
            var line = LINE_REPOSITORY.GetClientLines(client.Id).Where(x => x.Number == lineNumber).FirstOrDefault();
            return LINE_REPOSITORY.GetTotalMinutesFamily(line.Id, DateTime.Now);
        }

        public Package GetOptimalPackages(Client client, string packageName)
        {
            return OPTIMAL_PACKAGE.GetOptimalPackage(client, packageName);
        }
    }
}

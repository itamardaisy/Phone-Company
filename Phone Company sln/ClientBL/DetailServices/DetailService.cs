﻿using Common.Interfaces;
using Common.Interfaces.OptimalPackage_Interfaces;
using Common.Interfaces.UI.Client_Interfaces;
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
    public class DetailService : IDetailsService
    {
        private readonly ILineRepository _lineRepository;
        private readonly IOptimalPackage _optimalPackage;

        public DetailService(ILineRepository lineRepository, IOptimalPackage optimalPackage)
        {
            _lineRepository = lineRepository;
            _optimalPackage = optimalPackage;
        }

        /// <summary>
        /// Gets the a sum of call minuts for the past month.
        /// </summary>
        /// <param name="client"> The client who requested </param>
        /// <param name="lineNumber"> The line number </param>
        /// <returns> Minuts </returns>
        public double GetTotalMinutes(Client client, string lineNumber)
        {
            var line = _lineRepository.GetClientLines(client.Id).FirstOrDefault(x => x.Number == lineNumber);
            return _lineRepository.GetActualMonthMinuteCalls(line.Id, DateTime.Now);
        }

        public List<string> GetClientLines(int clientId)
        {
            List<string> lines = new List<string>();
            var theLines = _lineRepository.GetClientLines(clientId);
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
            var line = _lineRepository.GetClientLines(client.Id).FirstOrDefault(x => x.Number == lineNumber);
            return _lineRepository.GetActualMonthSMSs(line.Id, DateTime.Now);
        }

        /// <summary>
        /// Get the Total minuts calls that has been with the top 5 number.
        /// </summary>
        /// <param name="client"> The client that requested </param>
        /// <param name="lineNumber"> The line number </param>
        /// <returns> The call minuts </returns>
        public double GetTotalMinutesTopNumber(Client client, string lineNumber)
        {
            var line = _lineRepository.GetClientLines(client.Id).FirstOrDefault(x => x.Number == lineNumber);
            return _lineRepository.GetTotalMinutesTopNumber(line.Id, DateTime.Now);
        }

        /// <summary>
        /// Gets the sum of minuts with the selected numbers.
        /// </summary>
        /// <param name="client"> The client that requested </param>
        /// <param name="lineNumber"> The line number </param>
        /// <returns> The minuts </returns>
        public double GetTotalMinutesThreeTopNumber(Client client, string lineNumber)
        {
            var line = _lineRepository.GetClientLines(client.Id).FirstOrDefault(x => x.Number == lineNumber);
            return _lineRepository.GetTotalMinutesThreeTopNumber(line.Id, DateTime.Now);
        }

        /// <summary>
        /// Gets the total minuts inside the family.
        /// </summary>
        /// <param name="client"> The client that requested </param>
        /// <param name="lineNumber"> The line number </param>
        /// <returns> The minuts </returns>
        public double GetTotalMinutesFamily(Client client, string lineNumber)
        {
            var line = _lineRepository.GetClientLines(client.Id).FirstOrDefault(x => x.Number == lineNumber);
            return _lineRepository.GetTotalMinutesFamily(line.Id, DateTime.Now);
        }

        public List<Package> GetOptimalPackages(Client client, string packageName)
        {
            return _optimalPackage.GetOptimalPackage(client, packageName);
        }
    }
}

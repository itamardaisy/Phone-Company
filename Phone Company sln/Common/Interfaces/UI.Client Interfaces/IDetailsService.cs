using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces.UI.Client_Interfaces
{
    public interface IDetailsService
    {
        double GetTotalMinutes(Client client, string lineNumber);

        List<string> GetClientLines(int clientId);

        int GetTotalSMS(Client client, string lineNumber);

        double GetTotalMinutesTopNumber(Client client, string lineNumber);

        double GetTotalMinutesThreeTopNumber(Client client, string lineNumber);

        double GetTotalMinutesFamily(Client client, string lineNumber);

        List<Package> GetOptimalPackages(Client client, string packageName);
    }
}

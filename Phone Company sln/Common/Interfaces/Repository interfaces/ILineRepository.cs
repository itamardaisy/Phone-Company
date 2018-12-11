using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface ILineRepository
    {
        void AddNewLine(Line line);

        Line GetLine(string lineName);

        void UpdateLine(Line line);

        void SetPackage(int ClientId, int newPackageId);

        List<Line> GetClientLines(int clientId);

        double GetActualMonthMinuteCalls(int id, DateTime date);

        int GetActualMonthSMSs(int id, DateTime date);

        double GetTotalMinutesTopNumber(int id, DateTime date);

        double GetTotalMinutesThreeTopNumber(int id, DateTime date);

        double GetTotalMinutesFamily(int id, DateTime date);
    }
}
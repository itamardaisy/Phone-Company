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

        Line UpdateLine(Line line);

        void SetPackage(Package newPackage);
    }
}
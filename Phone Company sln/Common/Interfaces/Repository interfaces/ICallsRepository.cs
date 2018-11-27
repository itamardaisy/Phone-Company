using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface ICallsRepository
    {
        void AddNewCall(Call call);

        List<Call> GetLineCalls(string lineNumber);

        List<Call> GetLineCallsMonth(string lineNumber);
    }
}

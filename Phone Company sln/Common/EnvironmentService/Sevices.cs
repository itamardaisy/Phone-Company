using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.EnvironmentService
{
    public static class Services
    {
        public static void WriteExceptionsToLogger(Exception ex)
        {
            Logger.Logger.GetInstance().LogWrite(ex.Source);
            Logger.Logger.GetInstance().LogWrite(ex.StackTrace);
            Logger.Logger.GetInstance().LogWrite(ex.InnerException.Source);
        }

        public static void WriteToLogger(string message)
        {
            Logger.Logger.GetInstance().LogWrite(message);
        }
    }
}

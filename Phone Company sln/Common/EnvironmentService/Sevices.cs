﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.EnvironmentService
{
    /// <summary>
    /// This class represent the environment services for the all project.
    /// </summary>
    public static class Services
    {
        public static void WriteExceptionsToLogger(Exception ex)
        {
            Logger.Logger.GetInstance().LogWrite(ex.Source);
            Logger.Logger.GetInstance().LogWrite(ex.StackTrace);
        }

        public static void WriteToLogger(string message)
        {
            Logger.Logger.GetInstance().LogWrite(message);
        }
    }
}

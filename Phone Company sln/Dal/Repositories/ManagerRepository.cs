﻿using Common.EnvironmentService;
using Common.Interfaces;
using Common.Models;
using Dal.DataInitializer;
using Dal.DataModels;
using Dal.ModelConverters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Repositories
{
    public class ManagerRepository : IManagerRepository
    {
        /// <summary>
        /// This method gets the wanted client id and query from the data base his line.
        /// after this it take the all payment on the lines and returns them in list.
        /// </summary>
        /// <param name="clientId"> The wanted client </param>
        /// <returns> List of payments </returns>
        public List<Payment> GetClientReport(int clientId)
        {
            try
            {
                using (PhoneCompanyContext context = new PhoneCompanyContext())
                {
                    var clientLines = context.Lines.Where(x => x.ClientId == clientId).ToList();
                    List<Payment> clientPayments = new List<Payment>();
                    for (int i = 0; i < clientLines.Count; i++)
                        clientPayments.Add(context.Payments.FirstOrDefault(x => x.LineId == clientLines[i].Id).DbToCommon());
                    return clientPayments;
                }
            }
            catch (ArgumentNullException ex)
            {
                Services.WriteExceptionsToLogger(ex);
            }
            catch (Exception ex)
            {
                Services.WriteExceptionsToLogger(ex);
            }
            return null;
        }

        /// <summary>
        /// This method check looking for the client who most likely to unsign on folowing priorities
        /// 1 - A cline who is selected number are unsign.
        /// 2 - A client who uses the least
        /// </summary>
        /// <returns></returns>
        public List<Client> GetClientWhoMostLikelyToUnsign()
        {
            try
            {
                //ToDo

                using (PhoneCompanyContext context = new PhoneCompanyContext())
                {
                    throw new NotImplementedException();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// This method will returns the client who uses the least.
        /// </summary>
        /// <returns> The client </returns>
        private DbClient AClientWhoUsesTheLeast()
        {
            //ToDo

            throw new NotImplementedException();
        }

        /// <summary>
        /// This function  gets the client who called the call center the most
        /// </summary>
        /// <returns> The client </returns>
        public Client GetMostAnoyingClient()
        {
            try
            {
                using (PhoneCompanyContext context = new PhoneCompanyContext())
                {
                    var client = context.Clients.OrderByDescending(x => x.CallToCenter).FirstOrDefault();
                    return client.DbToCommon();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Client> GetMostConectedClients()
        {
            using (PhoneCompanyContext context = new PhoneCompanyContext())
            {
                //ToDo
                var calls = context.Calls.OrderByDescending(x => x.LineId).Select(x => x.LineId).ToList();
                throw new NotImplementedException();

            }
        }

        public Client GetMostProftableClient()
        {
            using (PhoneCompanyContext context = new PhoneCompanyContext())
            {
                //ToDo
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets the employee that answered the most calls
        /// </summary>
        /// <returns></returns>
        public User GetMostvalentEmployee()
        {
            try
            {
                using (PhoneCompanyContext context = new PhoneCompanyContext())
                {
                    var employee = context.Users.OrderByDescending(x => x.CallAnswer).FirstOrDefault();
                    return employee.DbToCommon();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
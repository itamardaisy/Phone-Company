﻿using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IClientRepository
    {
        void AddNewClient(Client client);

        void UpdateClient(Client client);

        Client GetClientById(int id);

        bool DeleteClient(int id);

        Client LoginClient(string name, string phoneNumber);
    }
}

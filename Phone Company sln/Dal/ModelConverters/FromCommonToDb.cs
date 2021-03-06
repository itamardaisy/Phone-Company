﻿using Common.Enums;
using Common.Models;
using Dal.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("Dal.UnitTest")]
[assembly: InternalsVisibleTo("BL.UnitTest")]

namespace Dal.ModelConverters
{
    internal static class FromCommonToDb
    {
        internal static DbCall CommonToDb(this Call call)
        {
            DbCall dbCall = new DbCall()
            {
                DestinationNumber = call.DestinationNumber,
                Duration = call.Duration,
                Id = call.Id,
                LineId = call.LineId,
                CallDate = call.CallDate,
                FamilyCall = call.FamilyCall,
                SelectedNumberCall = call.SelectedNumberCall
            };
            return dbCall;
        }

        internal static DbClient CommonToDb(this Client client)
        {
            DbClient dbClient = new DbClient()
            {
                Adress = client.Adress,
                CallToCenter = client.CallToCenter,
                ClientTypeId = client.ClientTypeId,
                SignDate = client.SignDate,
                ContactNumber = client.ContactNumber,
                Id = client.Id,
                LastName = client.LastName,
                Name = client.Name,
                UserId = client.UserId
            };
            return dbClient;
        }

        internal static DbClientType CommonToDb(this ClientType clientType)
        {
            DbClientType dbClientType = new DbClientType()
            {
                Id = clientType.Id,
                MinutePrice = clientType.MinutePrice,
                SMSPrice = clientType.SMSPrice,
                TypeName = clientType.TypeName
            };
            return dbClientType;
        }

        internal static DbLine CommonToDb(this Line line)
        {
            DbLine dbLine = new DbLine()
            {
                Id = line.Id,
                Number = line.Number,
                PackageId = line.PackageId,
                Status = line.Status,
                ClientId = line.ClientId
            };
            return dbLine;
        }

        internal static DbPackage CommonToDb(this Package package)
        {
            DbPackage dbPackage = new DbPackage()
            {
                DisscountPrecentage = package.DisscountPrecentage,
                FixedPrice = package.FixedPrice,
                InsideFamilyCall = package.InsideFamilyCall,
                Id = package.Id,
                SelectedNumberId = package.SelectedNumber,
                MaxMinute = package.MaxMinute,
                MostCallNumber = package.MostCallNumber,
                PackageName = package.PackageName,
                TotalPrice = package.TotalPrice,
                MaxSMSs = package.MaxSMSs
            };
            return dbPackage;
        }

        internal static DbPayment CommonToDb(this Payment payment)
        {
            DbPayment dbPayment = new DbPayment()
            {
                LineId = payment.LineId,
                Id = payment.Id,
                Month = payment.Month,
                TotalPayment = payment.TotalPayment
            };
            return dbPayment;
        }

        internal static DbSelectedNumber CommonToDb(this SelectedNumber selectedNumber)
        {
            DbSelectedNumber dbSelectedNumber = new DbSelectedNumber()
            {
                Id = selectedNumber.Id,
                FirstNumber = selectedNumber.FirstNumber,
                SecondNumber = selectedNumber.SecondNumber,
                ThirdNumber = selectedNumber.ThirdNumber,
                LineId = selectedNumber.LineId
            };
            return dbSelectedNumber;
        }

        internal static DbSMS CommonToDb(this SMS sMS)
        {
            DbSMS dbSMS = new DbSMS()
            {
                DestinationNumber = sMS.DestinationNumber,
                ExternalPrice = sMS.ExternalPrice,
                Id = sMS.Id,
                LineId = sMS.LineId,
                SelectedNumberCall = sMS.SelectedNumberCall,
                SmsDate = sMS.SMSDate,
                FamilyCall = sMS.FamilyCall
            };
            return dbSMS;
        }

        internal static DbUnsignClient CommonToDb(this UnsignClient unsignClient)
        {
            DbUnsignClient dbUnsignClient = new DbUnsignClient()
            {
                SignDate = unsignClient.SignDate,
                UnsignDate = unsignClient.UnsignDate,
                Adress = unsignClient.Adress,
                CallToCenter = unsignClient.CallToCenter,
                ClientTypeId = unsignClient.ClientTypeId,
                ContactNumber = unsignClient.ContactNumber,
                Id = unsignClient.Id,
                LastName = unsignClient.LastName,
                Name = unsignClient.Name
            };
            return dbUnsignClient;
        }

        internal static DbUser CommonToDb(this User user)
        {
            DbUser dbUser = new DbUser()
            {
                SignDate = user.SignDate,
                CallAnswer = user.CallAnswer,
                Email = user.Email,
                Id = user.Id,
                Name = user.Name,
                Password = user.Password,
                Type = (UserType)user.Type
            };
            return dbUser;
        }
    }
}
using Common.Enums;
using Common.Models;
using Dal.DataInitializer;
using Dal.DataModels;
using Dal.ModelConverters;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("Dal.UnitTest")]
[assembly: InternalsVisibleTo("BL.UnitTests")]

namespace Dal.ModelConverters
{
    internal static class FromDbToCommon
    {
        internal static Call DbToCommon(this DbCall dbCall)
        {
            Call call = new Call()
            {
                DestinationNumber = dbCall.DestinationNumber,
                Duration = dbCall.Duration,
                LineId = dbCall.LineId,
                Id = dbCall.Id,
                CallDate = dbCall.CallDate
            };
            return call;
        }

        internal static Client DbToCommon(this DbClient dbClient)
        {
            Client client = new Client()
            {
                SignDate = dbClient.SignDate,
                Adress = dbClient.Adress,
                CallToCenter = dbClient.CallToCenter,
                ClientTypeId = dbClient.ClientTypeId,
                ContactNumber = dbClient.ContactNumber,
                Id = dbClient.Id,
                LastName = dbClient.LastName,
                Name = dbClient.Name,
                UserId = dbClient.UserId
            };
            return client;
        }

        internal static ClientType DbToCommon(this DbClientType dbClientType)
        {
            ClientType clientType = new ClientType()
            {
                Id = dbClientType.Id,
                MinutePrice = dbClientType.MinutePrice,
                SMSPrice = dbClientType.SMSPrice,
                TypeName = dbClientType.TypeName
            };
            return clientType;
        }

        internal static Line DbToCommon(this DbLine dbLine)
        {
            Line line = new Line()
            {
                Id = dbLine.Id,
                Number = dbLine.Number,
                PackageId = dbLine.PackageId,
                Status = dbLine.Status
            };
            return line;
        }

        internal static Package DbToCommon(this DbPackage dbPackage)
        {
            Package package = new Package()
            {
                TotalPrice = dbPackage.TotalPrice,
                DisscountPrecentage = dbPackage.DisscountPrecentage,
                FixedPrice = dbPackage.FixedPrice,
                Id = dbPackage.Id,
                InsideFamilyCall = dbPackage.InsideFamilyCall,
                MaxMinute = dbPackage.MaxMinute,
                MostCallNumber = dbPackage.MostCallNumber,
                PackageName = dbPackage.PackageName,
                SelectedNumberId = dbPackage.SelectedNuberId
            };
            return package;
        }

        internal static Payment DbToCommon(this DbPayment dbPayment)
        {
            Payment payment = new Payment()
            {
                ClientId = dbPayment.ClientId,
                Id = dbPayment.Id,
                Month = dbPayment.Month,
                TotalPayment = dbPayment.TotalPayment
            };
            return payment;
        }

        internal static SelectedNumber DbToCommon(this DbSelectedNumber dbSelectedNumber)
        {
            SelectedNumber selectedNumber = new SelectedNumber()
            {
                FirstNumber = dbSelectedNumber.FirstNumber,
                Id = dbSelectedNumber.Id,
                SecondNumber = dbSelectedNumber.SecondNumber,
                ThirdNumber = dbSelectedNumber.ThirdNumber
            };
            return selectedNumber;
        }

        internal static SMS DbToCommon(this DbSMS dbSMS)
        {
            SMS sMS = new SMS()
            {
                DestinationNumber = dbSMS.DestinationNumber,
                ExternalPrice = dbSMS.ExternalPrice,
                Id = dbSMS.Id,
                LineId = dbSMS.LineId,
                SMSDate = dbSMS.SMSDate
            };
            return sMS;
        }

        internal static UnsignClient DbToCommon(this DbUnsignClient dbUnsignClient)
        {
            UnsignClient unsignClient = new UnsignClient()
            {
                SignDate = dbUnsignClient.SignDate,
                Adress = dbUnsignClient.Adress,
                CallToCenter = dbUnsignClient.CallToCenter,
                UnsignDate = dbUnsignClient.UnsignDate,
                ClientTypeId = dbUnsignClient.ClientTypeId,
                ContactNumber = dbUnsignClient.ContactNumber,
                Id = dbUnsignClient.Id,
                LastName = dbUnsignClient.LastName,
                Name = dbUnsignClient.Name
            };
            return unsignClient;
        }

        internal static User DbToCommon(this DbUser dbUser)
        {
            User user = new User()
            {
                SignDate = dbUser.SignDate,
                CallAnswer = dbUser.CallAnswer,
                Email = dbUser.Email,
                Id = dbUser.Id,
                Name = dbUser.Name,
                Password = dbUser.Password,
                Type = (UserType)dbUser.Type
            };
            return user;
        }
    }
}
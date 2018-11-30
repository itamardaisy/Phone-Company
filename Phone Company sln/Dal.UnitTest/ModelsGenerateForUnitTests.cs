using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Enums;
using Common.Models;

namespace Dal.UnitTest
{
    public static class ModelsGenerateForUnitTests
    {
        public static Call GenrateCall()
        {
            return new Call
            {
                Id = 1,
                CallDate = DateTime.Now,
                DestinationNumber = "123123",
                Duration = 66,
                LineId = 1
            };
        }

        public static Client GenrateClient()
        {
            return new Client
            {
                Id = 1,
                Adress = "asdasdsa",
                CallToCenter = 1321,
                ClientTypeId = 1,
                ContactNumber = "12312312",
                LastName = "asdsadsa",
                Name = "sadasdsa",
                SignDate = DateTime.MinValue,
                UserId = 1
            };
        }

        public static ClientType GenrateClientType()
        {
            return new ClientType
            {
                Id = 1,
                MinutePrice = 12,
                SMSPrice = 12,
                TypeName = "asdsad"

            };
        }

        public static Line GenrateLine()
        {
            return  new Line
            {
                Id = 1,
                ClientId = 1,
                Number = "1232131",
                PackageId = 1,
                Status = true
            };
        }

        public static Package GenratePackage()
        {
            return new Package
            {
                Id = 1,
                DisscountPrecentage = 2,
                FixedPrice = 100,
                InsideFamilyCall = false,
                MaxMinute = 100,
                MostCallNumber = false,
                PackageName = "blbal",
                SelectedNumberId = 1,
                TotalPrice = 10000,
            };
        }

        public static Payment GenratePayment()
        {
            return new Payment
            {
                Id = 1,
                LineId = 1,
                Month = DateTime.MaxValue,
                TotalPayment = 13212         
            };
        }

        public static SelectedNumber GenerateReceipt()
        {
            return new SelectedNumber
            {
                Id = 1,
                FirstNumber = "13123",
                SecondNumber = "2131231",
                ThirdNumber = "12312321"
            };
        }

        public static SMS GenreateSms()
        {
            return new SMS
            {
                Id = 1,
                DestinationNumber = "123213123",
                ExternalPrice = 123,
                LineId = 1,
                SMSDate = DateTime.MinValue
            };
        }

        public static User GenrateUser()
        {
            return new User
            {
                Id = 1,
                CallAnswer = 23,
                Email = "asdasd",
                Name = "asdasda",
                Password = "asdasd",
                SignDate = DateTime.Now,
                Type = UserType.Emploee
            };
        }
    }
}

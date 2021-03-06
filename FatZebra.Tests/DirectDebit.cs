﻿using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using FatZebra;
using Newtonsoft.Json;

namespace FatZebra.Tests
{
	[TestFixture]
	public class DirectDebitsTest
	{

		[OneTimeSetUp]
		public void Init()
		{
			FatZebra.Gateway.Username = "TEST";
			FatZebra.Gateway.Token = "TEST";
			Gateway.SandboxMode = true;
			Gateway.TestMode = true;
		}

		[Test]
		public void NewDirectDebitShouldBeSuccessful()
		{
			var response = DirectDebit.Create("012-084", "123123123", "Max Smith", 123.00m, Guid.NewGuid ().ToString (), "DotNet DE", DateTime.Today);

			Assert.IsTrue(response.Successful);
			Assert.IsTrue(response.Result.Successful);
			Assert.IsNotNull(((DirectDebit)response.Result).ID);

			Assert.AreEqual(((DirectDebit)response.Result).BSB, "012-084");
            Assert.IsTrue(((DirectDebit)response.Result).ID.Contains("-DD-"));
        }

		[Test]
		public void FetchDirectDebitShouldBeSuccessful()
		{
			var response1 = DirectDebit.Create("012-084", "123123123", "Max Smith", 123.00m, Guid.NewGuid ().ToString (), "DotNet DE", DateTime.Today);
			var response2 = DirectDebit.Find (response1.Result.ID);

			Assert.IsNotNull (response2);
			Assert.AreEqual (response1.Result.AccountName, response2.AccountName);
		}

        [Test]
        public void DeleteDirectDebitShouldBeSuccessful()
        {
            var response1 = DirectDebit.Create("012-084", "123123123", "Max Smith", 123.00m, Guid.NewGuid().ToString(), "DotNet DE", DateTime.Today);

            Assert.IsTrue(response1.Result.Delete());
        }
    }
}

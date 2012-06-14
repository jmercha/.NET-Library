﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FatZebra;

namespace FatZebra.Tests
{
    [TestClass]
    public class GatewayTest
    {

        [TestInitialize]
        public void Init()
        {
            FatZebra.Gateway.Username = "TEST";
            FatZebra.Gateway.Token = "TEST";
            Gateway.SandboxMode = true;
            Gateway.TestMode = true;
        }

        [TestMethod]
        public void PingShouldBeSuccessful()
        {
            Assert.IsTrue(Gateway.Ping());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleWebAPI;
using SimpleWebAPI.Controllers;
using SimpleWebAPI.API.Infrastructure.Http;
using System.Web.Http.Results;
using SimpleWebAPI.Entities;

namespace SimpleWebAPI.Tests.Controllers
{
    [TestClass]
    public class ValuesControllerTest
    {
        [TestMethod]
        public void Get()
        {
            // Organizar
            ValuesController controller = new ValuesController();
            int id = 1;

            // Agir
            ServiceHttpResult result = controller.Get(id);

            // Declarar
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkResult));
            Assert.IsNotNull(result.ServiceResponse.Data);
            Assert.AreEqual(id, ((Values)result.ServiceResponse.Data).Id);
        }

        [TestMethod]
        public void Add()
        {
            // Organizar
            ValuesController controller = new ValuesController();
            string value = "Test";

            // Agir
            ServiceHttpResult result = controller.Add(value);

            // Declarar
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkResult));
            Assert.IsNotNull(result.ServiceResponse.Data);
            Assert.AreEqual(value, ((Values)result.ServiceResponse.Data).Value);
        }


    }
}

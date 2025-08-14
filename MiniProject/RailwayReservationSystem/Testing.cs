using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RailwayReservationSystem
{
    [TestClass]
    public class Testing
    {
        Admin a = new Admin();
        [TestMethod]

        [DataRow("admin", "admin123", true)]
        [DataRow("admn", "admin123", false)]
        [DataRow("", "", false)]
        public void AdminLogin(string name, string password, bool expectedResult)
        {
            bool result = a.ValidateAdmin(name, password);
            Assert.AreEqual(expectedResult, result);
        }
    }
}

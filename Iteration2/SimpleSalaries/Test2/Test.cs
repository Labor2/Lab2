using NUnit.Framework;
using System;
using SimpleSalaries;

namespace Test2
{
    [TestFixture()]
    public class Test
    {
        [Test()]
        public void TestNetoCalc()
        {
            Program program = new SimpleSalaries.Program();

            Assert.AreEqual("764", SimpleSalaries.Program.CalculateFromFile("G1000"));

            Assert.AreEqual("547", SimpleSalaries.Program.CalculateFromFile("N547"));

            Assert.AreEqual("invalid", SimpleSalaries.Program.CalculateFromFile("GA7A33"));

            Assert.AreEqual("invalid", SimpleSalaries.Program.CalculateFromFile(" "));

            Assert.AreEqual("invalid", SimpleSalaries.Program.CalculateFromFile(""));
        }
    }
}

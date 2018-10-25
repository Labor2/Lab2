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

            Assert.AreEqual(764, SimpleSalaries.Program.CalculateNetoSalary("1000"));
        }
    }
}

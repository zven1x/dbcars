using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DBcars;
namespace DBcars_UnitTest_1
{
    [TestClass]
    public class TestForm1
    {
        [TestMethod]
        public void Open_Form1_test_method()
        {
            Form1 form1 = new Form1();
            form1.Show();
        }
    }
}

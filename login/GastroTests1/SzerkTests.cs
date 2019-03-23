using Microsoft.VisualStudio.TestTools.UnitTesting;
using login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using login.Misc;
using login.validator;
using System.Windows;
namespace login.Tests
{
    [TestClass()]
    public class SzerkTests
    {
        PlaceHolderTextBox p = new PlaceHolderTextBox();

        [TestMethod()]
        public void placeHolderNotContainsNumberTest()
        {
            p.setText("csirke");
                Assert.IsTrue(p.NotContainsNumber(),"Nincs benne szám, mégis kivételt dob.");



        }
        [TestMethod()]
        public void placeHolderContainsNumberTest()
        {
            p.setText("csirke1");
            Assert.IsFalse(p.NotContainsNumber(), "Van benne szám, mégis kivételt dob.");



        }
        [TestMethod()]
        public void placeHolderOnlyNumber()
        {
            p.setText("1213423545665764");
            Assert.IsTrue(p.onlyNumber(), "Nincs betű, mégis kivételt dob");
            


        }
        [TestMethod()]
        public void placeHolderNotOnlyNumber()
        {
            p.setText("12134235456  65764");
            Assert.IsFalse(p.onlyNumber(), "Van benne nem szám, mégis kivételt dob");



        }




    }
}
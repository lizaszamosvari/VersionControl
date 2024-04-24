using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using Raktárkezelő.Controllers;

namespace UnitTest
{
    public class soldquantitycontrollertest
    {

        [Test,
         TestCase("3"),
         TestCase("5")
         ]
        public void TestModifySpldQuantity(string quantity)
        {
            //Arrange
            var productcontroller = new SoldQuantityController();

            // Act
            var actualResponse = productcontroller.ModifySoldQuantity(quantity);

            // Assert
            ClassicAssert.True(actualResponse);
        }




        [Test,
        TestCase("5,5", false),
        TestCase("-10", false),
        TestCase("03", false),
        TestCase("7", true)
        ]


        public void TestValidatQuantity(string Quantity, bool expectedResult)
        {
            //Arrange
            var quantitycontroller = new SoldQuantityController();

            // Act
            var actualResult = quantitycontroller.ValidateQuantity(Quantity);

            //Assert
            ClassicAssert.AreEqual(expectedResult, actualResult);

        }

    }
}

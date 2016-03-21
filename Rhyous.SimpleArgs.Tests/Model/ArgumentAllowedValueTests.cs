using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhyous.SimpleArgs;

namespace SimpleArgs.Tests.Model
{
    [TestClass]
    public class ArgumentAllowedValueTests
    {
        #region AllowedValueCollection
        [TestMethod]
        public void SafeSetCallsIsAllowedValueTrue()
        {
            var arg = new Argument
            {
                AllowedValues = { "a" }
            };
            arg.Value = "a";
            Assert.IsTrue(arg.IsValueValid);
        }

        [TestMethod]
        public void SafeSetCallsIsAllowedValueFalse()
        {
            var arg = new Argument
            {
                AllowedValues = { "a" }
            };
            arg.Value = "b";
            Assert.IsFalse(arg.IsValueValid);
        }

        [TestMethod]
        public void ChangeAllowedValueAddedIsAllowedValueTrue()
        {
            var arg = new Argument
            {
                Value = "a"
            };
            arg.AllowedValues.Add("a");

            Assert.IsTrue(arg.IsValueValid);
        }

        [TestMethod]
        public void ChangeAllowedValueAddedIsAllowedValueFalse()
        {
            var arg = new Argument
            {
                Value = "b"
            };
            arg.AllowedValues.Add("a");

            Assert.IsFalse(arg.IsValueValid);
        }

        [TestMethod]
        public void ChangeAllowedValueNewCollectionIsAllowedValueTrue()
        {
            var arg = new Argument
            {
                Value = "a"
            };
            arg.AllowedValues = new ObservableCollection<string> { "a" };
            Assert.IsTrue(arg.IsValueValid);
        }

        [TestMethod]
        public void ChangeAllowedValueNewCollectionIsAllowedValueFalse()
        {
            var arg = new Argument
            {
                Value = "b"
            };
            arg.AllowedValues = new ObservableCollection<string> { "a" };
            Assert.IsFalse(arg.IsValueValid);
        }

        [TestMethod]
        public void ChangeAllowedValueInObjectInitializerIsAllowedValueTrue()
        {
            var arg = new Argument
            {
                Value = "a",
                AllowedValues = { "a" }
            };
            Assert.IsTrue(arg.IsValueValid);
        }

        [TestMethod]
        public void ChangeAllowedValueInObjectInitializerIsAllowedValueFalse()
        {
            var arg = new Argument
            {
                Value = "b",
                AllowedValues = { "a" }
            };
            Assert.IsFalse(arg.IsValueValid);
        }
        #endregion

        #region Pattern
        [TestMethod]
        public void ArgumentPatternMatchSetValuePositveTestTrue()
        {
            // Arrange
            var arg = new Argument
            {
                Pattern = CommonAllowedValues.Digits
            };

            // Act
            arg.Value = 100.ToString();

            // Assert
            Assert.IsTrue(arg.IsValueValid);
        }

        [TestMethod]
        public void ArgumentPatternMatchSetPatternPositveTestTrue()
        {
            // Arrange 
            var arg = new Argument
            {
                Value = 100.ToString(),
            };

            // Act 
            arg.Pattern = CommonAllowedValues.Digits;
            
            //Assert
            Assert.IsTrue(arg.IsValueValid);
        }

        [TestMethod]
        public void ArgumentPatternMatchSetValueNegativeDigitTestTrue()
        {
            // Arrange
            var arg = new Argument
            {
                Pattern = CommonAllowedValues.Digits
            };

            // Act
            arg.Value = (-100).ToString();

            // Assert
            Assert.IsTrue(arg.IsValueValid);
        }

        [TestMethod]
        public void ArgumentPatternMatchSetPatternNegativeDigitTestTrue()
        {
            // Arrange 
            var arg = new Argument
            {
                Value = (-100).ToString(),
            };

            // Act 
            arg.Pattern = CommonAllowedValues.Digits;

            //Assert
            Assert.IsTrue(arg.IsValueValid);
        }

        [TestMethod]
        public void ArgumentPatternMatchSetValueTestCharsFalse()
        {
            // Arrange 
            var arg = new Argument
            {
                Pattern = CommonAllowedValues.Digits
            };

            // Act 
            arg.Value = "abc";

            //Assert
            Assert.IsFalse(arg.IsValueValid);
        }

        [TestMethod]
        public void ArgumentPatternMatchSetPatternTestCharsFalse()
        {
            // Arrange
            var arg = new Argument
            {
                Value = "abc"
            };

            // Act
            arg.Pattern = CommonAllowedValues.Digits;

            // Assert
            Assert.IsFalse(arg.IsValueValid);
        }
        #endregion

        #region CustomValidation
        [TestMethod]
        public void ArgumentCustomValidationMatchTestTrue()
        {
            var arg = new Argument
            {
                CustomValidation = (value) => true
            };
            arg.Value = "a";
            Assert.IsTrue(arg.IsValueValid);
        }

        [TestMethod]
        public void ArgumentCustomValidationMatchTestFalse()
        {
            var arg = new Argument
            {
                CustomValidation = (value) => false
            };
            arg.Value = "a";
            Assert.IsFalse(arg.IsValueValid);
        }

        [TestMethod]
        public void ArgumentCustomValidationMatchSetSecondTestTrue()
        {
            var arg = new Argument
            {
                Value = "a"
            };
            arg.CustomValidation = (value) => true;
            Assert.IsTrue(arg.IsValueValid);
        }

        [TestMethod]
        public void ArgumentCustomValidationMatchSetSecondTestFalse()
        {
            var arg = new Argument
            {
                Value = "a"
            };
            arg.CustomValidation = (value) => false;
            Assert.IsFalse(arg.IsValueValid);
        }
        #endregion
    }
}

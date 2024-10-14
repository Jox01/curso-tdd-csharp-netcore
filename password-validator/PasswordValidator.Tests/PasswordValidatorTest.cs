using System;
using NUnit.Framework;

namespace PasswordValidator.Tests
{

    /*
 - Have more than 8 characters
 - Contains a capital letter
 - Contains a lowercase
 - Contains a number
 - Contains an underscore
    */


    public class PasswordValidatorTest
    {
        private PasswordValidator _validator;

        [SetUp]
        public void Setup()
        {
             _validator = new PasswordValidator();
        }


        [Test]
        public void Password_is_valid()
        {
            
            var password = "A17_patat";

            var result = _validator.Validate(password);

            Assert.That(result, Is.True);
        }

        [Test]
        public void Short_Password_IsInvalid()
        {
            
            var password = "A17_pata";

            var result = _validator.Validate(password);

            Assert.That(result, Is.False);
        }

        [Test]
        public void Password_WithoutUppercase_IsInvalid()
        {

            var password = "password_123";

            var result = _validator.Validate(password);

            Assert.That(result, Is.False);
        }


        [Test]
        public void Password_WithoutLowercase_IsInvalid()
        {

            var password = "PASSWORD_123";

            var result = _validator.Validate(password);

            Assert.That(result, Is.False);
        }

        [Test]
        public void Password_WithoutNumber_IsInvalid()
        {

            var password = "Password_patata";

            var result = _validator.Validate(password);

            Assert.That(result, Is.False);
        }

        [Test]
        public void Password_WithoutUnderscore_IsInvalid()
        {

            var password = "Password123";

            var result = _validator.Validate(password);

            Assert.That(result, Is.False);
        }

        [Test]
        public void Null_Password_IsInvalid()
        {

            string password = null;

            var result = _validator.Validate(password);

            Assert.That(result, Is.False);
        }


        [Test]
        public void Empty_Password_IsInvalid()
        {
            
            string password = string.Empty;

            var result = _validator.Validate(password);

            Assert.That(result, Is.False);
        }

    }
}
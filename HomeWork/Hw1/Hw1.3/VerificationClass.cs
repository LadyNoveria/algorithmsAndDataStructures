using System;

namespace VerificationLibrary
{
    public class VerificationClass
    {
        public string numberForCheck { get; set; }
        public string expectedValue { get; set; }
        public VerificationClass(string value, string ExpectedValue)
        {
            numberForCheck = value;
            expectedValue = ExpectedValue;
        }
        public VerificationClass(string ExpectedValue)
        {
            expectedValue = ExpectedValue;
        }
    }
}

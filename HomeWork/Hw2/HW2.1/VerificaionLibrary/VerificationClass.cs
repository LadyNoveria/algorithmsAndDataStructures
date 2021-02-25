using System;

namespace VerificaionLibrary
{
    public class VerificationClass
    {
        public string NumberForCheck { get; set; }
        public string ExpectedValue { get; set; }
        public VerificationClass(string value, string expectedValue)
        {
            NumberForCheck = value;
            ExpectedValue = expectedValue;
        }
        public VerificationClass(string expectedValue)
        {
            ExpectedValue = expectedValue;
        }
    }
}

using System;
namespace FindDoc.Common.Exceptions.AuthExceptions
{
    public class RegisterFailedException: Exception
    {
        public RegisterFailedException(string message): base(message)
        {

        }
    }
}

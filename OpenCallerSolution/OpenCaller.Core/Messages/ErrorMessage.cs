using System;

namespace OpenCaller.Core.Messages
{
    public sealed class ErrorMessage
    {
        public string SystemKey { get; private set; }
        public string Message { get; private set; }

        public ErrorMessage()
        {

        }

        public ErrorMessage(string pSystemKey, string pMessage)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(pSystemKey) || string.IsNullOrWhiteSpace(pMessage))
                    throw new ArgumentNullException(string.Format("Argument null ({0})", "pSystemKey|pMessage"));

                SystemKey = pSystemKey;
                Message = pMessage;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}

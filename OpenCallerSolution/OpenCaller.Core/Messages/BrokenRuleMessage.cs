namespace OpenCaller.Core.Messages
{
    public sealed class BrokenRuleMessage
    {
        public string SystemKey { get; set; }
        public string Message { get; set; }
        public BrokenRuleMessageTypes Type { get; set; }

        public BrokenRuleMessage()
        {

        }

        public BrokenRuleMessage(BrokenRuleMessageTypes pType, string pSystemKey, string pMessage)
        {
            this.Type = pType;
            this.SystemKey = pSystemKey;
            this.Message = pMessage;
        }
    }
}
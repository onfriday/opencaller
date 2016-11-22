using OpenCaller.Core.Messages;

namespace OpenCaller.Core.Services
{
    /// <summary>
    /// To be described
    /// </summary>
    public class ServiceResult : MessagesContainer
    {
        public ServiceResult()
            : base()
        {
        }
    }

    /// <summary>
    /// To be described
    /// </summary>
    /// <typeparam name="TResult">Type of return</typeparam>
    public sealed class ServiceResult<TResult> : ServiceResult
    {
        public ServiceResult()
            : base()
        {
        }

        public TResult Result { get; set; }
    }
}
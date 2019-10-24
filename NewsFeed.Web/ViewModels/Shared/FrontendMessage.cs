using System;

namespace NewsFeed.Web.ViewModels.Shared
{
    public class FrontendMessage
    {
        public string Status { get; set; }
        public string Message { get; set; }

        public FrontendMessage(MessageStatus status, string message)
        {
            switch (status)
            {
                case MessageStatus.Success:
                    this.Status = "success";
                    break;
                case MessageStatus.Info:
                    this.Status = "info";
                    break;
                case MessageStatus.Warning:
                    this.Status = "warning";
                    break;
                case MessageStatus.Danger:
                    this.Status = "danger";
                    break;
                default:
                    throw new ArgumentOutOfRangeException("status");
            }
            this.Message = message;
        }

    }

    public enum MessageStatus
    {
        Success,
        Danger,
        Warning,
        Info
    }
}

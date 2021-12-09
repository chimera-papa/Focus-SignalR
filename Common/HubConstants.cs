namespace Common
{
    public static class HubConstants
    {
        public static class MessageHub
        {
            public const string Name = "Message";
            public const string Global = "Global";
            public const string Channel = "Channel";
            public const string Private = "Private";
        }

        public static class NotificationHub
        {
            public const string Name = "Notification";
            public const string Push = "Push";
        }
    }
}
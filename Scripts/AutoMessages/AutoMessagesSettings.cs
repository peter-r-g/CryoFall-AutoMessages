namespace CryoFall.AutoMessages
{
    public class AutoMessagesSettings
    {
        /// <summary>
        /// Whether or not the messages should be displayed in sequential order or random.
        /// </summary>
        public bool InSequentialOrder = true;
        /// <summary>
        /// Whether or not a prefix should be placed before a message or not.
        /// </summary>
        public bool IncludePrefix = true;
        /// <summary>
        /// Whether or not faces and some emojis should be parse automatically. Example: :) -> 😃
        /// </summary>
        public bool ParseEmojis = true;

        /// <summary>
        /// The time in seconds between messages.
        /// </summary>
        public double DelayBetweenMessages = 60;

        /// <summary>
        /// If IncludePrefix is true, this will be the prefix placed before every message (A space (" ") is already placed after the prefix).
        /// </summary>
        public string Prefix = "[SERVER]";
        /// <summary>
        /// This will be all of the messages you want to be broadcasted to all players.
        /// </summary>
        public string[] Messages = new string[]
        {
            "This is an automated message, these and other settings can be edited in the mpk under Scripts/AutoMessages/AutoMessagesSettings.cs :)"
        };
    }
}

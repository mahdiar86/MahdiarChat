namespace MahChat.Models
{
    public class ChatMessage
    {
        public string SenderName { get; set; }

        public string Text { get; set; }

        public DateTimeOffset SendAt { get; set; }
    }
}

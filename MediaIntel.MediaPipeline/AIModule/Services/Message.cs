namespace MediaIntel.MediaPipeline.AIModule.Services
{
    public class Message
    {
        public MessageType messageType;
        public string context;

        public Message(MessageType messageType, string context)
        {
            this.messageType = messageType;
            this.context = context;
        }
    }

    public enum MessageType
    {
        System,
        User,
        AI
    }
}

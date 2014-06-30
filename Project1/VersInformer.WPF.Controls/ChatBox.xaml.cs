namespace VersInformer.WPF.Controls
{ 
    public partial class ChatBox
    {
        public ChatBox()
        {
            InitializeComponent();
        }

        public void AddMessage(ChatMessage msg)
        {
            ChatItems.Items.Add(msg);
        }
    }

    public class ChatMessage
    {
        public string Sender { get; set; }
        public string Content { get; set; }
    }
}

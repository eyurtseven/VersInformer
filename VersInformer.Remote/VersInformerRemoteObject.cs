namespace VersInformer.Remote
{
    public class VersInformerProxy : System.MarshalByRefObject
    {
        public event MessageArrivedEvent MessageArrived;

        public override object InitializeLifetimeService()
        {
            return null;
        }

        public void HandleMessageArrived(string message)
        {
            if (null != MessageArrived)
            {
                MessageArrived(message);
            }
        }

    }

    public delegate void MessageArrivedEvent(string Message);

}

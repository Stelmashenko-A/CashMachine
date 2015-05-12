namespace GuiForAtm.Statistics
{
    public class PreparedRecord
    {
        public string TimeOfOperation { get; private set; }

        public string RequestedSum { get; private set; }

        public string ResultOfOperation { get; private set; }

        public string Money { get; private set; }


        public PreparedRecord(string timeOfOperation, string requestedSum, string resultOfOperation, string money)
        {
            TimeOfOperation = timeOfOperation;
            RequestedSum = requestedSum;
            ResultOfOperation = resultOfOperation;
            Money = money;
        }
    }
}

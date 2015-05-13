using ATM;
using ATM.Utility;

namespace GuiForAtm.Output
{
    class PreparedMoney
    {
        public PreparedMoney(MutablePair<Banknote, int> data)
        {
            Nominal = data.Key.Nominal;
            Number = data.Value;
        }

        public decimal Nominal { get; set; }
        public int Number { get; set; }
    }
}

using System.ComponentModel;

namespace ATM
{
    public enum States
    {
        InProcess,
        [Description("Not so cool")]
        CombinationFailed,
        MoneyDeficiency,
        NoError
    }
}
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace ATM
{
    public interface IBanknoteSelector
    {
        void Initialize(List<MutablePair<decimal, int>> moneyCassettes);

        void TrySelect(decimal sum);

        ErrorMessages Result { get; }

        List<MutablePair<decimal, int>> SelectedMoney { get; }
    }
}

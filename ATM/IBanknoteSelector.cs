using System.Collections.Generic;

namespace ATM
{
    public interface IBanknoteSelector
    {
        bool TrySelect(List<MutablePair<decimal, int>> moneyCassettes, decimal requestedSum, out States result,
            out List<MutablePair<decimal, int>> selectedMoney);
    }
}

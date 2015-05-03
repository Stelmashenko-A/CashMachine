using System;
using System.Collections.Generic;
using System.Linq;
using ATM.Utility;
using log4net;

namespace ATM.AtmOperations
{
    internal class GreedyAlgorithm : IBanknoteSelector
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(GreedyAlgorithm));
        private static decimal TotalSum(List<MutablePair<decimal, int>> moneyCassettes)
        {
            if (moneyCassettes == null) throw new ArgumentNullException("moneyCassettes");
            return moneyCassettes.Sum(variable => variable.Key*variable.Value);
        }

        public bool TrySelect(List<MutablePair<decimal, int>> moneyCassettes, decimal requestedSum, out AtmState result,
            out List<MutablePair<decimal, int>> selectedMoney)
        {
            try
            {
                if (moneyCassettes == null)
                {
                    throw new ArgumentNullException("moneyCassettes");
                }
                if (requestedSum < 0)
                {
                    throw new FormatException("requestedSum");
                }
                if (TotalSum(moneyCassettes) < requestedSum)
                {
                    result = AtmState.MoneyDeficiency;
                    selectedMoney = null;
                    return false;
                }
                selectedMoney = new List<MutablePair<decimal, int>>();

                var cassetteUsed = new Stack<MutablePair<decimal, int>>();
                var cassetteForUsing = new LinkedList<MutablePair<decimal, int>>();
                var moneyStack = new Stack<MutablePair<decimal, int>>();
                foreach (var item in moneyCassettes)
                {
                    cassetteForUsing.AddFirst(item);
                }
                //пока для выдачи не останется ноль повторяем
                while (requestedSum > 0)
                {
                    //смотрим номинал купюр находящийся в вершине стека номиналов которые буду использованы
                    var currentCassette = cassetteForUsing.Last();

                    //если кроме текущего номинала доступен хотя бы ещё один
                    //или с помощьью текущего номинала можно выдать оставшуюся сумму
                    if ((cassetteForUsing.Count() > 1) || (
                        ((requestedSum%currentCassette.Key == 0) && (
                            requestedSum/currentCassette.Key <= currentCassette.Value))))

                    {
                        //извекаем текущий номинал из стека неиспользованных номиналов
                        cassetteForUsing.RemoveLast();
                        //находим наименьшее между количеством купюр в банкомате и максиммальным количеством купюр
                        //суммарное достоинство которых не превышает требуемой суммы
                        var banknotesNumber = Math.Min((int) (requestedSum/currentCassette.Key),
                            currentCassette.Value);
                        //извлекаем купюры из кассеты
                        currentCassette.Value -= banknotesNumber;
                        //из запрошенной суммы вычитаем сумму выбранных на данном шаге купюр
                        requestedSum -= currentCassette.Key*banknotesNumber;
                        //в стек использованных номиналов добавляем текущий номинал
                        cassetteUsed.Push(currentCassette);
                        //в деньги для выдачи добавляем купюры, выбранные на текущем шаге 
                        moneyStack.Push(new MutablePair<decimal, int>(currentCassette.Key, banknotesNumber));
                        continue;
                    }

                    //если цикл не пошёл на следующий шаг
                    //то пока есть использованные номиналы и количество
                    //купюр текущего номминала равно нулю
                    while (cassetteUsed.Any() && moneyStack.Peek().Value == 0)
                    {
                        //переносим использованные номиналы в стек неиспользованных
                        cassetteForUsing.AddLast(cassetteUsed.Pop());
                        //извлекаем из выдачи номиналы с нулевым количеством
                        moneyStack.Pop();
                    }

                    //если после извлечения купюр на предыдущем этапе
                    //в выдаче не осталось никаких номиналов
                    if (!moneyStack.Any())
                    {
                        // то получить нужную сумму невозможно
                        result = AtmState.CombinationFailed;
                        return false;
                    }

                    //если номиналы остались, то уменьшаем на единицу количество купюр
                    //номинала из вершины стека
                    moneyStack.Peek().Value--;
                    //возвращаем эту купюру в контейнер
                    cassetteUsed.Peek().Value++;
                    //увеличиваем сумму для подбора на номинал купюры, перемещённой обратно в банкомат
                    requestedSum += cassetteUsed.Peek().Key;
                }

                //если произошёл успешный выход из цикла, состоянию присваиваем статус успешного завершения
                result = AtmState.NoError;
                //деньги из стека перекладываем в объект класса Money и возвращаем результат
                selectedMoney.AddRange(moneyStack.ToArray());
            }
            catch (ArgumentNullException ex)
            {
                Log.Error(ex);
                result = AtmState.MoneyDeficiency;
                selectedMoney = null;
                return false;
            }
            catch (FormatException ex)
            {
                Log.Error(ex);
                result = AtmState.FormatError;
                selectedMoney = null;
                return false;
            }
            return true;
        }
    }
}
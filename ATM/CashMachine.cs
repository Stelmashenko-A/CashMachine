using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ATM
{
    public class CashMachine
    {
        private readonly Money _container;

        private int TotalSum
        {
            get { return _container.Banknotes.Sum(item => item.Value*item.Key.Nominal); }
        }

        public CashMachine()
        {
            _container = new Money();
            string data;
            using (var sr = new StreamReader("Money.txt"))
            {
                data = sr.ReadLine();
            }
            if (data == null) return;
            var strArray = data.Split(' ');
            var numberOfPars = strArray.Length/2;
            for (var i = 0; i < numberOfPars; i++)
            {
                var nominal = int.Parse(strArray[i*2]);
                var num = int.Parse(strArray[i*2 + 1]);
                _container.Banknotes.Add(new MutablePair<Banknote, int>(new Banknote(nominal), num));
            }
        }

        public Money Withdraw(int requestedSum)
        {
            //Проверка на достаточность денег
            var money = new Money();
            if (TotalSum < requestedSum)
            {
                money.Result = States.MoneyDeficiency;
                return money;
            }

            var nominalUsed = new Stack<MutablePair<Banknote, int>>();
            var nominalForUsing = new LinkedList<MutablePair<Banknote, int>>();
            var moneyStack = new Stack<MutablePair<Banknote, int>>();
            foreach (var item in _container.Banknotes)
            {
                nominalForUsing.AddFirst(item);
            }
            //пока для выдачи не останется ноль повторяем
            while (requestedSum > 0)
            {
                //смотрим номинал купюр находящийся в вершине стека номиналов которые буду использованы
                var currenBanknotes = nominalForUsing.Last();

                //если кроме текущего номинала доступен хотя бы ещё один
                //или с помощьью текущего номинала можно выдать оставшуюся сумму
                if (nominalForUsing.Count() > 1 ||
                    (requestedSum%currenBanknotes.Key.Nominal == 0 &&
                     requestedSum%currenBanknotes.Key.Nominal <= currenBanknotes.Value))
                {
                    //извекаем текущий номинал из стека неиспользованных номиналов
                    nominalForUsing.RemoveLast();
                    //находим наименьшее между количеством купюр в банкомате и максиммальным количеством купюр
                    //суммарное достоинство которых не превышает требуемой суммы
                    var banknotesNumber = Math.Min(requestedSum/currenBanknotes.Key.Nominal,
                        currenBanknotes.Value);
                    //извлекаем купюры из кассеты
                    currenBanknotes.Value -= banknotesNumber;
                    //из запрошенной суммы вычитаем сумму выбранных на данном шаге купюр
                    requestedSum -= currenBanknotes.Key.Nominal*banknotesNumber;
                    //в стек использованных номиналов добавляем текущий номинал
                    nominalUsed.Push(currenBanknotes);
                    //в деньги для выдачи добавляем купюры, выбранные на текущем шаге 
                    moneyStack.Push(new MutablePair<Banknote, int>(currenBanknotes.Key, banknotesNumber));
                    continue;
                }

                //если цикл не пошёл на следующий шаг
                //то пока есть использованные номиналы и количество
                //купюр текущего номминала равно нулю
                while (nominalUsed.Any() && moneyStack.Peek().Value == 0)
                {
                    //переносим использованные номиналы в стек неиспользованных
                    nominalForUsing.AddLast(nominalUsed.Pop());
                    //извлекаем из выдачи номиналы с нулевым количеством
                    moneyStack.Pop();
                }

                //если после извлечения купюр на предыдущем этапе
                //в выдаче не осталось никаких номиналов
                if (!moneyStack.Any())
                {
                    // то получить нужную сумму невозможно
                    money.Result = States.CombinationFailed;
                    return money;
                }

                //если номиналы остались, то уменьшаем на единицу количество купюр
                //номинала из вершины стека
                moneyStack.Peek().Value--;
                //возвращаем эту купюру в контейнер
                nominalUsed.Peek().Value++;
                //увеличиваем сумму для подбора на номинал купюры, перемещённой обратно в банкомат
                requestedSum += nominalUsed.Peek().Key.Nominal;
            }

            //если произошёл успешный выход из цикла, состоянию присваиваем статус успешного завершения
            money.Result = States.Success;
            //деньги из стека перекладываем в объект класса Money и возвращаем результат
            money.Banknotes.AddRange(moneyStack.ToArray());
            return money;
        }
    }
}
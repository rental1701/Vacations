using Task_5.Models;

namespace Task_5
{
    internal static class VacationDistributor
    {

        /// <summary>
        /// Функция назначения отпусков
        /// </summary>
        /// <param name="persons"></param>
        internal static void AssignVacationEmployees(IEnumerable<Person> persons)
        {
            List<DateTime> allVacations = new List<DateTime>();
            Random gen = new Random();
            int range = DateTime.IsLeapYear(DateTime.Today.Year) ? 366 : 365;
            foreach (Person person in persons)
            {
                while (person.vacationCount > 0)
                {
                    DateTime startDate = new DateTime(DateTime.Today.Year, 1, 1).AddDays(gen.Next(range)); //Генерация даты начала отпуска
                    if (!(startDate.DayOfWeek == DayOfWeek.Saturday || startDate.DayOfWeek == DayOfWeek.Sunday))
                    {
                        DateTime endDate;
                        int difference;
                        if (person.vacationCount <= 7 || gen.Next(2) == 0)
                        {
                            endDate = startDate.AddDays(7);
                            difference = 7;
                        }
                        else
                        {
                            endDate = startDate.AddDays(14);
                            difference = 14;
                        }

                        bool allPerm = CheckingVacationConditions(allVacations, startDate, endDate);
                        if (allPerm)
                        {
                            bool personPerm = ChackingPersonVacationsConditions(person.Vacations, startDate, endDate);
                            if (personPerm)
                            {
                                for (int i = 0; i < difference; i++) //Добавление отпуска в общий список и в личный список сотрудника
                                {
                                    DateTime dateAdd = startDate.AddDays(i);
                                    allVacations.Add(dateAdd);
                                    person.Vacations.Add(dateAdd);
                                }
                                person.vacationCount -= difference;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Проверка условий для общего списка отпусков разрешения отпуска.
        /// </summary>
        /// <param name="allVacations"></param>
        /// <param name="personVacations"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns>Возвращает True если отпуск не пересекается с другими отпусками в общем списке</returns>
        private static bool CheckingVacationConditions(List<DateTime> allVacations, DateTime start, DateTime end)
        {
            foreach (DateTime item in allVacations)
            {
                if (item >= start && item <= end)
                    return false;
                else
                {
                    DateTime date = item.AddDays(3);
                    if (date >= start && date <= end)
                        return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Проверка условия для разрешения добавления отпуска личный список
        /// </summary>
        /// <param name="personVacations"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        private static bool ChackingPersonVacationsConditions(List<DateTime> personVacations, DateTime start, DateTime end)
        {
            bool existStart = false;
            bool existEnd = false;
            foreach (DateTime item in personVacations)
            {
                DateTime add = item.AddMonths(1);
                DateTime sub = item.AddMonths(-1);

                if (!existStart && start <= add && end <= add)
                {
                    existStart = true;
                }
                if (!existEnd && start >= sub && end >= sub)
                {
                    existEnd = true;
                }
                if (existStart && existEnd)
                {
                    return false;
                }
            }
            return true;
        }
    }
}

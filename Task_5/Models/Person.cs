using System.Text;

namespace Task_5.Models
{
    internal class Person
    {
        internal int vacationCount;

        public Person()
        {
            vacationCount = 28;
        }
        public string? Name { get; set; }
        public List<DateTime> Vacations { get; set; } = new();

        /// <summary>
        /// Возвращает строку со всеми отпусками для сотрудника
        /// </summary>
        /// <returns></returns>
        internal string GetInfoAllVacations()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Дни отпуска {Name} :\n");
            for (int i = 0; i < Vacations.Count; i++)
            {
                sb.Append($"{Vacations[i].ToString("d")}\n");
            }
            return sb.ToString();
        }
    }
}

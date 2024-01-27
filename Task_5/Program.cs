using Task_5;
using Task_5.Models;

List<Person> persons = new List<Person>();
persons.Add(new() { Name = "Иванов Иван Иванович" });
persons.Add(new() { Name = "Петров Петр Петрович" });
persons.Add(new() { Name = "Юлина Юлия Юлиановна" });
persons.Add(new() { Name = "Сидоров Сидор Сидорович" });
persons.Add(new() { Name = "Павлов Павел Павлович" }); 
persons.Add(new() { Name = "Георгиев Георг Георгиевич" });

VacationDistributor.AssignVacationEmployees(persons);

foreach (var person in persons)
{
    Console.WriteLine(person.Vacations.Count);
    Console.WriteLine(person.GetInfoAllVacations());
}
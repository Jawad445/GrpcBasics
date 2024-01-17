using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using Grpc.Course.Protbuf.Test;

Console.WriteLine("Welcome to the Protbuf App !");

var emp = new Employee();
emp.Id = 1;
emp.FirstName = "Jawad";
emp.LastName = "Hassan";
emp.IsRetired = false;
var birthdate = new DateTime(1994, 12, 25);
birthdate = DateTime.SpecifyKind(birthdate, DateTimeKind.Utc);
emp.BirthDate = Timestamp.FromDateTime(birthdate);
emp.MaritalStatus = Employee.Types.MaritalStatus.Married;
var empadress = new Address();
empadress.City = "Lahore";
empadress.HouseNumber = 44;
empadress.StreetName = "s83";
empadress.ZipCode = "54000";
emp.CurrentAddress = empadress;
emp.PreviousEmployers.Add("Computan");
emp.PreviousEmployers.Add("Techverx");

emp.Relatives.Add("Father", "Hassan Abbas");
emp.Relatives.Add("Mother", "Shazia Hassan");
emp.Relatives.Add("Sister", "Nida Zahra");
emp.Relatives.Add("Brother1", "Ali Aitazaz");
emp.Relatives.Add("Brother2", "Hamdan Ali");
emp.Relatives.Add("Wife", "Kainat Fatima");
using (var output = File.Create("emp.dat"))
{
    emp.WriteTo(output);
}

Employee empFromFile;
using (var input = File.OpenRead("emp.dat"))
{
    empFromFile = Employee.Parser.ParseFrom(input);
}



Console.WriteLine("Completed Successfully!");
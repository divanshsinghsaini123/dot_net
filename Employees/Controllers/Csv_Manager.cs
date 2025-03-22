using Microsoft.Extensions.Diagnostics.HealthChecks;
using Employees.Models;
namespace Employees.Controllers
{
    public class Csv_Manager
    {
        private List<Emp> cslst = new List<Emp>();
        string path = "E:/dotNetNew/Employees/wwwroot/data_hai_ye.csv";
        public Csv_Manager()
        {
            //read data from csv file and add to the list
            //read the file line by line 
            using (var reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] values = line.Split(',');
                    Emp emp = new Emp()
                    {
                        Id = Convert.ToInt32(values[0]),
                        Name = values[1],
                        Position = values[2],
                        DateOfBirth = Convert.ToDateTime(values[3]),
                        Email = values[4],
                        Salary = Convert.ToDecimal(values[5])
                    };
                    cslst.Add(emp);
                }
            }
        }
        public List<Emp> loader()
        {
            return cslst;
        }
        public void CSV_updater(List<Emp> lst)
        {
            using (var writer = new StreamWriter(path))
            {
                foreach (var emp in lst)
                {
                    writer.WriteLine($"{emp.Id},{emp.Name},{emp.Position},{emp.DateOfBirth},{emp.Email},{emp.Salary},{emp.Department},{emp.PhoneNo},{emp.JoiningDate}");
                }
            }

        }
        public void Add_to_csv(Emp emp)
        {
            using (var writerrr = new StreamWriter(path))  // Correct placement of parentheses
            {
                writerrr.WriteLine($"{emp.Id},{emp.Name},{emp.Position},{emp.DateOfBirth},{emp.Email},{emp.Salary},{emp.Department},{emp.PhoneNo},{emp.JoiningDate}");
            }
        }
        //remove me bhi csv updater hi cla denge 


    }
}


using Microsoft.Extensions.Diagnostics.HealthChecks;
using Employee_manager.Models;
using Employees.Models;
using Employee_manager.Interfaces;

namespace Employee_manager.Service
{
    public class Csv_Manager : ICsv_Manager
    {
        private List<EmpModel> cslst = new List<EmpModel>();
        string path = "wwwroot/data_hai_ye.csv";
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
                    EmpModel emp = new()
                    {
                        Id = Convert.ToInt32(values[0]),
                        Name = values[1],
                        Position = values[2],
                        //DateOfBirth = Convert.ToDateTime(values[3]),
                        DateOfBirth = DateOnly.FromDateTime(Convert.ToDateTime(values[3])),
                        Email = values[4],
                        Salary = Convert.ToDecimal(values[5]),
                        Department = values[6] ,
                        PhoneNo = values[7] ,
                        JoiningDate = DateOnly.FromDateTime(Convert.ToDateTime(values[8])),
                    };
                    Console.WriteLine(emp.Id);
                    Console.WriteLine(emp.Name);
                    Console.WriteLine(emp.Position);
                    Console.WriteLine(emp.DateOfBirth);
                    Console.WriteLine(emp.Email);
                    Console.WriteLine(emp.Salary);
                    Console.WriteLine(emp.Department);
                    Console.WriteLine(emp.PhoneNo);
                    Console.WriteLine(emp.JoiningDate);

                    cslst.Add(emp);
                }
            }
        }
        public List<EmpModel> loader()
        {
            return cslst;
        }
        public void CSV_updater(List<EmpModel> lst)
        {
            using (var writer = new StreamWriter(path))
            {
                foreach (var emp in lst)
                {
                    writer.WriteLine($"{emp.Id},{emp.Name},{emp.Position},{emp.DateOfBirth},{emp.Email},{emp.Salary},{emp.Department},{emp.PhoneNo},{emp.JoiningDate}");
                }
            }

        }
        public void Add_to_csv(EmpModel emp)
        {
            using (var writerrr = new StreamWriter(path))  // Correct placement of parentheses
            {
                writerrr.WriteLine($"{emp.Id},{emp.Name},{emp.Position},{emp.DateOfBirth},{emp.Email},{emp.Salary},{emp.Department},{emp.PhoneNo},{emp.JoiningDate}");
            }
        }
        //remove me bhi csv updater hi cla denge 


    }
}


using Employees.Models;

namespace Employee_manager.Interfaces
{
    public interface ICsv_Manager
    {
        public List<EmpModel> loader();
        public void CSV_updater(List<EmpModel> lst);
        public void Add_to_csv(EmpModel emp);
    }
}

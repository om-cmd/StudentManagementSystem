using StudentManagementSystem.Models;
using StudentManagementSystem.ViewModels;

namespace StudentManagementSystem.DataAcess.Interface
{
    public interface ICourcesInterface
    {
        CourcesViewModel GetCources(int id);
        ICollection<CourcesViewModel> GetAllCources();
        Cources Create(CourcesViewModel cources);
        Cources Edit(CourcesViewModel courcesChanges);
        CourcesViewModel Delete(int id);
    }
}

using StudentManagementSystem.Models;
using StudentManagementSystem.ViewModels;

namespace StudentManagementSystem.DataAcess.Interface
{
    public interface  IChosenCourcesInterface
    {
        ChosenCourcesViewModel GetChosenCources(int id);
        ICollection<ChosenCourcesViewModel> GetAllChosenCources();
        ChosenCources Create(ChosenCourcesViewModel chosen);
        ChosenCources Edit(ChosenCourcesViewModel chosenChanges);
        ChosenCourcesViewModel Delete(int id);
        IQueryable<Student> Students { get; }
        IQueryable<Faculty> Faculty { get; }
        IQueryable<Cources> Cources { get; }
    }
}

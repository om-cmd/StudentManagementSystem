using AutoMapper;
using StudentManagementSystem.Models;
using StudentManagementSystem.ViewModels;

namespace StudentManagementSystem.AutoMappersProfile
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Student, StudentViewModel>().ReverseMap();
            CreateMap<Cources, CourcesViewModel>().ReverseMap();
            CreateMap<Faculty, FacultyViewModel>().ReverseMap();
            CreateMap<ChosenCources, ChosenCourcesViewModel>().ReverseMap();
        }
    }
}

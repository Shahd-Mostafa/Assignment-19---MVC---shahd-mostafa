using Assignment_19___MVC___shahd_mostafa.Models;
using AutoMapper;
using Demo.DAL.Entities;

namespace Assignment_19___MVC___shahd_mostafa.Helper.profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee,EmployeeViewModels>().ReverseMap();
            //CreateMap<EmployeeViewModels, Employee>();
        }
    }
}

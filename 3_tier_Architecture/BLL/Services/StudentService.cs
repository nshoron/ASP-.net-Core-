using AutoMapper;
using BLL.DTOs;
using DAL.EF.Models;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class StudentService
    {
        StudentRepo Repo;
        public StudentService(StudentRepo Repo)
        {
            this.Repo = Repo;
        }
    Mapper GetMapper ()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Student,StudentDTO>().ReverseMap();
            });
            return new Mapper(config);
        }
   
    }
}

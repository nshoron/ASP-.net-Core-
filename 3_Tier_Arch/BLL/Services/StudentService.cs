using AutoMapper;
using BLL.DTOs;
using DAL.EF;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class StudentService
    {
        StudentRepo repo;
        public StudentService(StudentRepo repo)
        {
            this.repo = repo;
        }

        Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Student, StudentDTO>().ReverseMap();
            });
            return new Mapper(config);
        }
        public List<StudentDTO> Get()
        {
            List<Student> data = repo.Get();
            //convert to DTO
            var ret = GetMapper().Map<List<StudentDTO>>(data);
            return ret;
        }
        public bool Create(StudentDTO student)
        {
            Student s = GetMapper().Map<Student>(student);
            return repo.Create(s);
        }
    }
}

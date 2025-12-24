using AutoMapper;
using CFWebApiDB.EF;
using CFWebApiDB.EF.Models;
using CodeFirstDbWebApi.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

using Microsoft.EntityFrameworkCore.Metadata.Conventions;


namespace CodeFirstDbWebApi.Controllers 
{
    [ApiController]
    [Route("api/[controller]")]

    public class NewsController : ControllerBase
    {
        NmsDbContext db;
        public NewsController (NmsDbContext db)
        {
            this.db = db;
        }
        Mapper GetMapper ()
        {
            var config = new MapperConfiguration(cfg => {cfg.CreateMap<NewsDTO,News>().ReverseMap(); });
            return new Mapper(config);
        }
        [HttpGet("all")]
        public IActionResult All()
        {
            var data = db.Newses.ToList();
           return Ok (data);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = db.Newses.Find(id);
            return Ok (data);

        }
        [HttpPost("create")]
        public IActionResult Create(NewsDTO data)
        {
            var news = GetMapper().Map<News>(data);
            db.Newses.Add(news);
            db.SaveChanges();
            return Ok(news);

        }


    }
}

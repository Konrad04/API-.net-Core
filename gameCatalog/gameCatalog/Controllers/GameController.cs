using gameCatalog.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace gameCatalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
       
        private readonly GameDbContext gameDbContext;


        public GameController(GameDbContext context)
        {
            gameDbContext = context;
        }

       
        [HttpGet]
        public IEnumerable<Game> GetProducts()
        {
            return gameDbContext.Games.ToList();
        }
        
        [HttpGet("{id}")]
        public Game GetProduct(int id)
        {
            return gameDbContext.Games.Find(id);
        }
        [HttpPost]
        public HttpResponseMessage AddProduct(Game model)
        {
            try
            {
                gameDbContext.Games.Add(model);
                gameDbContext.SaveChanges();
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Created);
                return response;
            }
            catch (Exception ex)
            {
                if (ex != null)
                {
                    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                    return response;
                }
                return null;

            }
        }
        [HttpPut("{id}")]
        public HttpResponseMessage UpdateGame(int id, [Bind("Nazwa,Rok,Gatunek,Nota,Zdjecie")] Game model)
        {
            try
            {
                if (id == model.Id)
                {

                    gameDbContext.Games.Update(model);
                    gameDbContext.SaveChanges();
                    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                    return response;
                }
                else
                {
                    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.NotModified);
                    return response;
                }
            }
            catch (Exception ex)
            {
                if (ex != null)
                {
                    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                    return response;
                }
                return null;

            }
        }

        [HttpDelete("{id}")]
        public HttpResponseMessage DeleteGame(int id)
        {
            try
            {

                Game record = gameDbContext.Games.Find(id);
                if (record != null)
                {
                    gameDbContext.Games.Remove(record);
                    gameDbContext.SaveChanges();
                    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                    return response;
                }
                else
                {
                    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.NotFound);
                    return response;
                }
            }
            catch (Exception ex)
            {
                if (ex != null)
                {
                    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                    return response;
                }
                return null;

            }
        }
    }
}

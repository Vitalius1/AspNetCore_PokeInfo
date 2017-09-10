using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PokeInfo.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("pokemon/{pokeid}")]
        public IActionResult QueryPoke(int pokeid)
        {
            var Pokemon = new Dictionary<string, object>();
            WebRequest.GetPokemonDataAsync(pokeid, ApiResponse =>
            {
                Pokemon = ApiResponse;
            }).Wait();
           
           
            // System.Console.WriteLine(Pokemon["types"]);
            var Types = new List<Dictionary<string, object>>();

            
            
            ViewBag.name = Pokemon["name"];
            ViewBag.height = Pokemon["height"];
            ViewBag.weight = Pokemon["weight"];

            return View("index");
        }
    }
}

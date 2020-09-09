using AGL.Web.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AGL.Web.Repository
{
    public class AGLRepository : IAGLRepository
    {
        private WebClient _client;
        private IConfiguration _config;

        private string _serviceUrl { get; set; }

        public AGLRepository(IConfiguration config)
        {
            _client = new WebClient();
            _config = config;

            this._serviceUrl = _config["ServiceURL"];
        }
        
        public List<Person> GetPeronsWithCats()
        {
            var res =  _client.DownloadString(_serviceUrl);
            var persons = JsonConvert.DeserializeObject<List<Person>>(res);
            var grouped = persons.Select(x => new Person { Name = x.Name, Age = x.Age, Gender = x.Gender, Pets = x.Pets.Where(c => c.Type == "Cat").ToList() }).ToList();
            return grouped;
        }                
    }
}

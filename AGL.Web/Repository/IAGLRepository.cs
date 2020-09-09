using AGL.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AGL.Web.Repository
{
    public interface IAGLRepository
    {
        List<Person> GetPeronsWithCats();
    }
}

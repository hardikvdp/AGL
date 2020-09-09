using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AGL.Web.Models
{
    public class Person
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }

        private List<Pet> _Pets;
        public List<Pet> Pets
        {
            get { return this._Pets; }
            set
            {
                if (value == null)
                {
                    this._Pets = new List<Pet>();
                }
                else
                {
                    this._Pets = value;
                }
            }
        }
    }
}

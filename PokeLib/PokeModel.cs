using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeLib
{
    public class PokeModel
    {
        /// <summary>
        /// PokeModel to store the information from our JSON response from our call to PokeApi.co 
        /// </summary>
      
       public string name { get; set; }
       public string id { get; set; }
       public Dictionary<string, string> sprites { get; set; }


        /// <summary>
        ///Reference: http://json2csharp.com/
        ///For JSON field 'types' we need to create two class objects since 'types' holds an array, to access to array 'Type' we need to 
        ///create a class handler for its properties as well. 
        /// </summary>
        public List<Types> types { get; set; }
        public class Types
        {
            public int slot { get; set; }
            public Type type { get; set; }
        }
        public class Type
        {
            public string name { get; set; }
            public string url {get; set; }
        }


        /// <summary>
        /// Class models for Stats and stat property
        /// </summary>
        public List<Stats> stats { get; set; }
        public class Stats
        {
            public int base_stat { get; set; }
            public int effort { get; set; }
            public Stat stat { get; set; }        
        }

        public class Stat
        {
            public string name { get; set; }
        }


        public List<Abilities> abilities { get; set; }
        public class Abilities
        {
            public ability ability { get; set; }
            public bool is_hidden { get; set; }
            public int slot { get; set; }
            
        }
        public class ability
        {
            public string name { get; set; }
        }

    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokiAPIWebsite.Models
{
    /// <summary>
    /// Information for a single Pokemon pokedex Entry
    /// </summary>
    public class PokeDexEntryViewModel
    {
        public string PokedexImageUrl { get; set; }
        public string Name { get; set; }

        public int Id { get; set; }

        public string Height { get; set; }

        public string Weight { get; set; }

        public IEnumerable<string> MoveList { get; set; }
    }
}

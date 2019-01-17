using System;

namespace gql.core.model {

    public class Game {
        public int Id { get; set; }
        public string Name { get; set; }
        public Company Developer { get; set; }
        public Company Publisher { get; set; }
        public DateTime RelaseDate { get; set; }
    }
    
}
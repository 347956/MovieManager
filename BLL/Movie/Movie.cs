using ContractLayer;
using FactoryDAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class Movie
    {
        //properties
        public string Name { get; set; }
        public string Genre { get; private set; }
        public string GenreTwo { get; private set; }
        public string Date { get; private set; }
        public bool Watched { get; private set; }
        public int ID { get; private set; }

        //constructor
        public Movie(MovieDTO movieDTO)
        {
            this.Name = movieDTO.Name;
            this.Genre = movieDTO.Genre;
            this.GenreTwo = movieDTO.GenreTwo;
            this.Date = movieDTO.Date;
            this.Watched = movieDTO.Watched;
            this.ID = movieDTO.ID;
        }
        IMovieDAL getDAL = FactoryMovieDAL.CreateMovieDAL();
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ContractLayer
{
    public interface IMovieDAL
    {
        void Update(MovieDTO movieDTO, int ID);
    }
}

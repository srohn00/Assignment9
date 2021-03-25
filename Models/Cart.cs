using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment9.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        public virtual void AddItem(Movie movie)
        {
            CartLine line = Lines
                .Where(m => m.Movie.MovieID == movie.MovieID)
                .FirstOrDefault();

            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Movie = movie,
                });
            }
            else
            {

            }
        }

        public virtual void RemoveLine(Movie movie) =>
            Lines.RemoveAll(m => m.Movie.MovieID == movie.MovieID);
        public virtual void Clear() => Lines.Clear();
        public class CartLine
        {
            public int CartLineID { get; set; }
            public Movie Movie { get; set; }

        }
    }
}

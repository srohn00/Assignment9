using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Assignment9.Models;

namespace Assignment9.Pages
{
    public class AddedMoviesModel : PageModel
    {
        private IMovieRepository repository;

        //constructor
        public AddedMoviesModel (IMovieRepository repo, Cart cartService)
        {
            repository = repo;
            Cart = cartService;
        }

        //properties
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }

        //methods
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            
;        }
        //adds book based on bookID
        public IActionResult OnPost(long movieId, string returnUrl)
        {
            Movie movie = repository.Movies.FirstOrDefault(m => m.MovieID == movieId);
           

            Cart.AddItem(movie);
            
            return RedirectToPage(new { returnUrl = returnUrl });
        }
        //removes book based on bookID
        public IActionResult OnPostRemove(long movieID, string returnUrl)
        {
            {
                Cart.RemoveLine(Cart.Lines.First(cl => cl.Movie.MovieID == movieID).Movie);
                return RedirectToPage(new { returnUrl = returnUrl });
            }
        }
    }
}

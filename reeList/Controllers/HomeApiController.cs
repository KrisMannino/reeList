using reeList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace reeList.Controllers
{
    public class HomeApiController : ApiController
    {
        public IEnumerable<Movie> GetAll()
        {
            using (MovieDBContext objMovieDBContext = new MovieDBContext())
            {
                return objMovieDBContext.movie.ToList();
            }
        }

        public IHttpActionResult Get(int MovieId)
        {
            using (MovieDBContext objMovieDBContext = new MovieDBContext())
            {
                var movie = objMovieDBContext.movie.FirstOrDefault(a => a.MovieId == MovieId);
                if (movie != null)
                {
                    return Ok(movie);
                }
                else
                {
                    return NotFound();
                }
            }

        }

        [ResponseType(typeof(Movie))]
        public IHttpActionResult Post(Movie movie)
        {
            using (MovieDBContext objMovieDBContext = new MovieDBContext())
            {
                objMovieDBContext.movie.Add(movie);
                objMovieDBContext.SaveChanges();
            }
            return CreatedAtRoute("DefaultApi", new { MovieId = movie.MovieId }, movie);
        }

        [ResponseType(typeof(Movie))]
        public IHttpActionResult Delete(int MovieId)
        {
            using (MovieDBContext objMovieDBContext = new MovieDBContext())
            {
                var GetMovie = objMovieDBContext.movie.FirstOrDefault(a => a.MovieId == MovieId);
                if (GetMovie != null)
                {
                    objMovieDBContext.movie.Remove(GetMovie);
                    objMovieDBContext.SaveChanges();
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
        }

        [ResponseType(typeof(Movie))]
        public IHttpActionResult Put(int MovieId, Movie movie)
        {
            if (MovieId != movie.MovieId)
            {
                return BadRequest();
            }
            else
            {
                using (MovieDBContext contextObj = new MovieDBContext())
                {

                    Movie GetMovie = contextObj.movie.Find(MovieId);
                    GetMovie.Title = movie.Title;
                    GetMovie.Year = movie.Year;
                    GetMovie.Rated = movie.Rated;
                    contextObj.SaveChanges();
                    return CreatedAtRoute("DefaultApi", new { MovieId = movie.MovieId }, movie);
                }
            }
        }

    }
}
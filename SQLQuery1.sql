SELECT MovieList_Movies.MovieList_Id, MovieTest.Id, MovieTest.Name, MovieTest.Genre, MovieTest.Genre2, MovieTest.Date, MovieTest.Watched, MovieLIst.Id, MovieList.Name, MovieList.MovieCount, MovieList.UserId
FROM MovieList_Movies
INNER JOIN MovieTest ON MovieList_Movies.Movie_Id= MovieTest.Id
INNER JOIN MovieList ON MovieList_Movies.MovieList_Id = MovieList.Id
WHERE MovieList.UserId = 1;

SELECT MovieList.Id FROM MovieList WHERE UserId = 1;
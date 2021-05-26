SELECT MovieList_Movies.MovieList_Id, MovieTest.Id, MovieTest.Name, MovieTest.Genre, MovieTest.Genre2, MovieTest.Date, MovieTest.Watched, MovieLIst.Id, MovieList.Name, MovieList.MovieCount, MovieList.UserId
FROM MovieList_Movies
INNER JOIN MovieTest ON MovieList_Movies.Movie_Id= MovieTest.Id
INNER JOIN MovieList ON MovieList_Movies.MovieList_Id = MovieList.Id
WHERE MovieList.UserId = 0;

SELECT MovieList.Id AS MLID, MovieList.Name
FROM MovieList
WHERE MovieList.UserId = 1;

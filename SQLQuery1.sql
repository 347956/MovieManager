SELECT MovieList_Movies.MovieList_Id, MovieTest.Id, MovieTest.Name, MovieTest.Genre, MovieTest.Genre2, MovieTest.Date, MovieTest.Watched, MovieLIst.Id, MovieList.Name, MovieList.MovieCount, MovieList.UserId
FROM MovieList_Movies
INNER JOIN MovieTest ON MovieList_Movies.Movie_Id= MovieTest.Id
INNER JOIN MovieList ON MovieList_Movies.MovieList_Id = MovieList.Id
WHERE MovieList.UserId = 1;

SELECT MovieList_Movies.MovieList_Id AS MovieListID, MovieTest.Id AS MID, MovieTest.Name, MovieTest.Genre, MovieTest.Genre2, MovieTest.Date, MovieTest.Watched, MovieLIst.Id AS MLID, MovieList.Name, MovieList.MovieCount, MovieList.UserId AS userId
FROM MovieList_Movies
INNER JOIN MovieTest ON MovieList_Movies.Movie_Id= MovieTest.Id
INNER JOIN MovieList ON MovieList_Movies.MovieList_Id = MovieList.Id
WHERE MovieList_Id = 6;

SELECT MovieList.Id AS MLID, MovieList.Name
FROM MovieList
WHERE MovieList.UserId = 1;

SELECT MovieList.Id AS MLId, MovieList.Name AS MLN, MovieList.UserId FROM MovieList WHERE MovieList.Id = 6;
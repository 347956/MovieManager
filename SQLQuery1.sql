SELECT MovieList_Movies.MovieList_Id, MovieTest.Id, MovieTest.Name, MovieTest.Genre, MovieTest.Genre2, MovieTest.Date, MovieTest.Watched, MovieLIst.Id, MovieList.Name, MovieList.MovieCount, MovieList.UserId
FROM MovieList_Movies
INNER JOIN MovieTest ON MovieList_Movies.Movie_Id= MovieTest.Id
INNER JOIN MovieList ON MovieList_Movies.MovieList_Id = MovieList.Id
WHERE MovieList.UserId = 0;

SELECT MovieList.Id AS MLID, MovieList.Name
FROM MovieList
WHERE MovieList.UserId = 1;

SELECT MovieList_Movies.MovieList_Id, MovieTest.Id AS MID, MovieTest.Name AS MName, MovieTest.Genre, MovieTest.Genre2, MovieTest.Date, MovieTest.Watched, MovieList.Id MLID, MovieList.Name AS MLName, MovieList.MovieCount, MovieList.UserId AS MLUID 
FROM MovieList_Movies 
INNER JOIN MovieTest ON MovieList_Movies.Movie_Id= MovieTest.Id 
INNER JOIN MovieList ON MovieList_Movies.MovieList_Id = MovieList.Id
WHERE MovieList_Id = 2;

Select MovieList.Name, MovieList.Id, MovieList.UserId FROM MovieList WHERE MovieList.Id = 6;
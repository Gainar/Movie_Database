using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Movie.Core.Models;

namespace DAL.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly string _connectionString;

        public MovieRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void AddMovie(MovieCreator mov)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sqlInsert = "INSERT INTO Movie VALUES (NEWID(),@Tit, @y, @g, @t, @r,@key)";
                var creatorList = connection.Query<Creator>("Select * From Creator").ToList();
                connection.Execute(sqlInsert, new { Tit = mov.Title, y = mov.Year, g = mov.Genre, t = mov.Type, r = mov.Rating, key = creatorList.Find(item => item.Name.Trim() == mov.Name).Pk_Creator_Id });
            }
        }
        public void DeleteByTitleMovie(string title)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sqlDelete = "DELETE FROM Movie WHERE Title=@t;";
                connection.Execute(sqlDelete, new { t = title });
            }

        }
        public void EditMovie(MovieCreator mov)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sqlUpdate = "UPDATE Movie SET Year=@y, Genre=@g, Type=@t, Rating=@r,Fk_Creator_Id=@key WHERE Title=@title";
                Console.WriteLine("Enter the creator's name");
                var creators = connection.Query<Creator>("Select * From Creator;").ToList();
                var x = creators.Find(item => item.Name.Trim().ToUpper() == mov.Name.Trim().ToUpper()).Pk_Creator_Id;
                connection.Execute(sqlUpdate, new { y = mov.Year, g = mov.Genre, t = mov.Type, r = mov.Rating, key = x, title = mov.Title });
            }
        }

        public List<MovieCreator> GetAllMovies()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sqlSelect = "Select Title, Year, Genre, Type, Rating, Name From Movie INNER JOIN Creator on Fk_Creator_Id = Pk_Creator_Id;";
                return connection.Query<MovieCreator>(sqlSelect).ToList();

            }
        }

        public MovieCreator GetMovie(string tit)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sqlSelect = "Select Title, Year, Genre, Type, Rating, Name From Movie INNER JOIN Creator on Fk_Creator_Id = Pk_Creator_Id Where Title=@title ;";
                var mov = connection.Query<MovieCreator>(sqlSelect, new { title = tit }).ToList();
                return mov[0];

            }
        }
    }
}

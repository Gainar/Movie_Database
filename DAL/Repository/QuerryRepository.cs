using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Movie.Core.Models;

namespace DAL.Repository
{
    public class QuerryRepository : IQuerryRepository
    {
        private readonly string _connectionString;

        public QuerryRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<MovieCreator> Querry(string param, string val)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = 
                    "Select Title, Year, Genre, Type, Rating, Name From Movie INNER JOIN Creator on Fk_Creator_Id = Pk_Creator_Id Where " +
                    param + "=" + val + ";";
                var mov = connection.Query<MovieCreator>(sql).ToList();
                return mov;
            }
        }

        public List<MovieCreator> Querry(string param)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string sql;
                if (param.ToUpper() == "TITLE")
                    sql =
                        "Select Title, Year, Genre, Type, Rating, Name From Movie INNER JOIN Creator on Fk_Creator_Id = Pk_Creator_Id Order BY " +
                        param + " ASC";
                else
                    sql =
                        "Select Title, Year, Genre, Type, Rating, Name From Movie INNER JOIN Creator on Fk_Creator_Id = Pk_Creator_Id Order BY " +
                        param + " DESC, Title ASC";
                var mov = connection.Query<MovieCreator>(sql).ToList();
                return mov;
            }
        }
    }
}

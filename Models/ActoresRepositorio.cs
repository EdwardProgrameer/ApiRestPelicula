using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestPelicula.Models
{
    public class ActoresRepositorio
    {

        private string conStr;
        public ActoresRepositorio()
        {

            conStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DB_Peliculas;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(conStr);
            }
        }
        //INSERT 

        public void Add(Actores actores)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string Sql = @"INSERT INTO Actores(Actor_Id,Nombre,Apellido) VALUES (@Actor_Id,@Nombre,@Apellido)";
                dbConnection.Open();
                dbConnection.Execute(Sql, actores);
                dbConnection.Close();
            }
        }

        //GET ALL

        public IEnumerable<Actores> GetAll()
        {

            using (IDbConnection dbConnection = Connection)
            {
                string Sql = @" SELECT FROM Actores";
                dbConnection.Open();
                return dbConnection.Query<Actores>(Sql);
            }

        }

        //GET BY ID

        public Actores GetById(int id)
        {

            using (IDbConnection dbConnection = Connection)
            {
                string Sql = @" SELECT FROM Actores WHERE Actor_Id=@Actor_Id";
                dbConnection.Open();
                return dbConnection.Query<Actores>(Sql, new { Id = id }).FirstOrDefault();
            }

        }

        //UPDATE

        public void update(Actores actores)
        {

            using (IDbConnection dbConnection = Connection)
            {
                string Sql = @" UPDATE Actores SET @Actor_Id,@Nombre,@Apellido, WHERE Actor_Id=@Actor_Id";
                dbConnection.Open();
                dbConnection.Query(Sql, actores);

            }
        }

        //DELETE

        public void Delete (int id)
        {

            using (IDbConnection dbConnection = Connection)
            {
                string Sql = @" DELETE FROM Actores WHERE Actor_Id=@Actor_Id";
                dbConnection.Open();
                dbConnection.Query(Sql, new { Id = id });

            }
        }

    }
}
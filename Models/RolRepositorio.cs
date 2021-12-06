using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestPelicula.Models
{
    public class RolRepositorio
    {

        private string conStr;
        public RolRepositorio()
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

        public void Add(Rol rol)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string Sql = @"INSERT INTO Rol (Id,Nombre)";
                dbConnection.Open();
                dbConnection.Execute(Sql, rol);
                dbConnection.Close();
            }
        }

        //GET ALL

        public IEnumerable<Rol> GetAll()
        {

            using (IDbConnection dbConnection = Connection)
            {
                string Sql = @" SELECT FROM Rol";
                dbConnection.Open();
                return dbConnection.Query<Rol>(Sql);
            }

        }

        //GET BY ID

        public Rol GetById(int id)
        {

            using (IDbConnection dbConnection = Connection)
            {
                string Sql = @" SELECT FROM Rol WHERE Id=@Id";
                dbConnection.Open();
                return dbConnection.Query<Rol>(Sql, new { Id = id }).FirstOrDefault();
            }

        }

        //UPDATE

        public void update(Rol rol)
        {

            using (IDbConnection dbConnection = Connection)
            {
                string Sql = @" UPDATE Rol SET @Id,@Nombre";
                dbConnection.Open();
                dbConnection.Query(Sql, rol);

            }
        }

        //DELETE

        public void Delete(int id)
        {

            using (IDbConnection dbConnection = Connection)
            {
                string Sql = @" DELETE FROM Rol WHERE Usuario_Id=@Id";
                dbConnection.Open();
                dbConnection.Query(Sql, new { Id = id });
            }
        }
    }
}
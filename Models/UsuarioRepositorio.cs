using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestPelicula.Models
{
    public class UsuarioRepositorio
    {

        private string conStr;
        public UsuarioRepositorio()
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

        public void Add(Usuarios usuarios)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string Sql = @"INSERT INTO usuario (usuario_Id,Password_ID,Nombre,Apellido)";
                dbConnection.Open();
                dbConnection.Execute(Sql, usuarios);
                dbConnection.Close();
            }
        }

        //GET ALL

        public IEnumerable<Usuarios> GetAll()
        {

            using (IDbConnection dbConnection = Connection)
            {
                string Sql = @" SELECT FROM usuario";
                dbConnection.Open();
                return dbConnection.Query<Usuarios>(Sql);
            }

        }

        //GET BY ID

        public Usuarios GetById(int id)
        {

            using (IDbConnection dbConnection = Connection)
            {
                string Sql = @" SELECT FROM usario WHERE Usuario_Id=@Usuario_Id";
                dbConnection.Open();
                return dbConnection.Query<Usuarios>(Sql, new { Id = id }).FirstOrDefault();
            }

        }

        //UPDATE

        public void update(Usuarios usuarios)
        {

            using (IDbConnection dbConnection = Connection)
            {
                string Sql = @" UPDATE usuario SET @usuario_Id,@Password_ID,@Nombre,@Apellido";
                dbConnection.Open();
                dbConnection.Query(Sql, usuarios);

            }
        }

        //DELETE

        public void Delete(int id)
        {

            using (IDbConnection dbConnection = Connection)
            {
                string Sql = @" DELETE FROM usuario WHERE Usuario_Id=@Usuario_Id";
                dbConnection.Open();
                dbConnection.Query(Sql, new { Id = id });

            }
        }
    }
}

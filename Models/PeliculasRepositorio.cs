using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestPelicula.Models { 

    public class PeliculasRepositorio
    {


            private string conStr;
            public PeliculasRepositorio()
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

        public void Add(Peliculas pelicula)
            {
                using (IDbConnection dbConnection = Connection)
                {
                    string Sql = @"INSERT INTO Pelicula (Pelicula_Id,Nombre,Actor,Fecha,Descripcion)";
                    dbConnection.Open();
                    dbConnection.Execute(Sql,pelicula);
                    dbConnection.Close();
                }
            }

            //GET ALL

            public IEnumerable<Peliculas> GetAll()
            {

                using (IDbConnection dbConnection = Connection)
                {
                    string Sql = @" SELECT FROM Pelicula";
                    dbConnection.Open();
                    return dbConnection.Query<Peliculas>(Sql);
                }

            }

            //GET BY ID

            public Peliculas GetById(int id)
            {

                using (IDbConnection dbConnection = Connection)
                {
                    string Sql = @" SELECT FROM Pelicula WHERE Pelicula_Id=@Pelicula_Id";
                    dbConnection.Open();
                    return dbConnection.Query<Peliculas>(Sql, new { Id = id }).FirstOrDefault();
                }

            }

            //UPDATE

            public void update(Peliculas peliculas)
            {

                using (IDbConnection dbConnection = Connection)
                {
                    string Sql = @" Pelicula SET @Pelicula_Id,@Nombre,@Actor,@Fecha,@Descripcion";
                    dbConnection.Open();
                    dbConnection.Query(Sql, peliculas);

                }
            }

            //DELETE

            public void Delete(int id)
            {

                using (IDbConnection dbConnection = Connection)
                {
                    string Sql = @" DELETE FROM Pelicula WHERE Pelicula_Id=@Pelicula_Id";
                    dbConnection.Open();
                    dbConnection.Query(Sql, new { Id = id });

                }
            }

        
    }
}
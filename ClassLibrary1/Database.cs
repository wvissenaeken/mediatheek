using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFilmLibrary
{
    class Database
    {
        private readonly string connectionString = "Server=.;Database=ProjectFilm;Integrated Security=True";
        private SqlConnection conn;

        public Database()
        {
        }


        public int GetAantalFilms()
        {
            //maak een db connectie
            conn = new SqlConnection(connectionString);

            try
            {
                //open de verbinding
                conn.Open();

                string query = "SELECT COUNT(*) AS Aantal FROM Film";

                SqlCommand command = new SqlCommand(query, conn);
                object resultaat = command.ExecuteScalar();
                int aantalFilms = (int)resultaat;

                return aantalFilms;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                //sluit de verbinding
                conn.Close();
                conn.Dispose();
            }
        }

        public List<Film> GetFilm()
        {
            List<Film> films = new List<Film>();

            SqlCommand command = new SqlCommand();
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                command.Connection = conn;
                command.CommandText = @"
SELECT	film_id, Titel, 	
FROM Film
ORDER BY titel
";

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read()) //zolang we nog records te lezen hebben...
                {
                    Film film = new Film
                    {
                        Id = SafeReadValue<int>(dataReader, "film_id"),
                        Titel = SafeReadValue<string>(dataReader, "Titel"),
                        Jaar = SafeReadValue<short>(dataReader, "Release_jaar")
                    };

                    films.Add(film);

                    Debug.WriteLine($"Record Id: {film.Id}, titel: {film.Titel}");
                }

                return films;

            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
                command.Dispose();

            }
        }

        private T SafeReadValue<T>(SqlDataReader reader, string fieldName)
        {
            try
            {
                return (T)reader[fieldName];
            }
            catch
            {
                return default(T);
            }
        }
        }
}
    

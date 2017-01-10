using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFilmLibrary
{
    public class Database
    {
        private readonly string connectionString = @"Data Source=.\SQLEXPRESS;Database=ProjectFilm; Integrated security=true";
        public SqlConnection conn;

        public Film opgezochtefilm = new Film();

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
                throw ex;
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
SELECT	film_id, Titel, Stock
FROM Film
WHERE Stock != 0
ORDER BY titel
";
                SqlDataReader dataReader = command.ExecuteReader();
                Debug.WriteLine("Connection geopend!");
                while (dataReader.Read()) //zolang we nog records te lezen hebben...
                {
                    Film film = new Film
                    {
                        _Id = SafeReadValue<int>(dataReader, "film_id"),
                        _Titel = SafeReadValue<string>(dataReader, "Titel"),
                        _Release = SafeReadValue<DateTime>(dataReader, "Release_datum"),
                        _Stock = SafeReadValue<int>(dataReader, "Stock")
                    };
                    films.Add(film);
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

        //update gegevens van gezochte film
        public void updateGegevensFilm()
        {
            //maak een db connectie
            conn = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                command.Connection = conn;
                command.CommandText = @" UPDATE dbo.Film
                                         SET Titel= @Titel, Beschrijving= @Beschrijving, Release_datum= @Release, Score= @Score
                                         WHERE Film_ID = 2";
                    command.Parameters.AddWithValue("@Titel", opgezochtefilm._Titel);
                    command.Parameters.AddWithValue("@Beschrijving", opgezochtefilm._Beschrijving);
                    command.Parameters.AddWithValue("@Release", opgezochtefilm._Release);
                    command.Parameters.AddWithValue("@Score", opgezochtefilm._Score); 

                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                //sluit de verbinding
                conn.Close();
                conn.Dispose();
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
    

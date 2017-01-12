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
            catch
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
                command.CommandText = @"SELECT	film_id, Titel, Stock
                                        FROM Film
                                        WHERE Stock != 0
                                        ORDER BY titel";
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read()) 
                {
                    Film film = new Film
                    {
                        _Id = SafeReadValue<int>(dataReader, "film_id"),
                        _Titel = SafeReadValue<string>(dataReader, "Titel"),
                        _Release = SafeReadValue<int>(dataReader, "Release_datum"),
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
                //CONTROLE of film aanwezig is in database
                command.CommandText = @"SELECT	Titel, Release_datum, Onlinezoeken_ID
                                        FROM Film";
                SqlDataReader dataReader = command.ExecuteReader();
                if (dataReader.Read()) 
                {
                    Film film = new Film
                    {
                        _Id = SafeReadValue<int>(dataReader, "Onlinezoeken_ID"),
                        _Titel = SafeReadValue<string>(dataReader, "Titel"),
                        _Release = SafeReadValue<int>(dataReader, "Release_datum"),
                    };
                    if (film._Titel == opgezochtefilm._Titel && film._Release == opgezochtefilm._Release && film._Id == opgezochtefilm._Id)
                    {}
                    else
                    {
                        //sluit controleverbinding
                        conn.Close();
                        conn.Dispose();
                        //Open nieuwe verbinding
                        conn = new SqlConnection(connectionString);
                        conn.Open();
                        command.Connection = conn;
                        command.CommandText = @" INSERT INTO dbo.Film (Onlinezoeken_ID,Titel, Beschrijving, Release_datum, Score)
                                               VALUES (@OnlineID ,@Titel,  @Beschrijving, @Release,  @Score);";
                        command.Parameters.AddWithValue("@OnlineID", opgezochtefilm._Id);
                        command.Parameters.AddWithValue("@Titel", opgezochtefilm._Titel);
                        command.Parameters.AddWithValue("@Beschrijving", opgezochtefilm._Beschrijving);
                        command.Parameters.AddWithValue("@Release", opgezochtefilm._Release);
                        command.Parameters.AddWithValue("@Score", opgezochtefilm._Score);
                        //VOEG TOE aan database
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch
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
    

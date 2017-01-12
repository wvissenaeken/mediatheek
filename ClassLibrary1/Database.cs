using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjectFilmLibrary
{
    public class Database
    {
        private readonly string connectionString = @"Data Source=.\SQLEXPRESS;Database=ProjectFilm; Integrated security=true";
        public SqlConnection conn;

        public int aanwezigInDatabase;
        public int gevondenCode;

        public Film opgezochtefilm = new Film();

        public Database()
        {
        }

        //ZOEK barcode
        public int zoekOfBarcodeAanwezigIsInDB()
        {
            //maak een db connectie
            conn = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            try
            {
                //open de verbinding
                conn.Open();
                command.Connection = conn;
                //CONTROLE of film aanwezig is in database
                command.CommandText = @"SELECT COUNT(*) 
                                        FROM Film
                                        WHERE Barcode =@Barcode;";
                command.Parameters.AddWithValue("@Barcode", opgezochtefilm._Barcode);
                object resultaat = command.ExecuteScalar();
                aanwezigInDatabase = (int)resultaat;
                return aanwezigInDatabase;
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

        //TOON lijst van alle te huren films waarvan stock groter is dan 0.
        public List<Film> GetFilm()
        {
            List<Film> films = new List<Film>();
            conn = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            try
            {
                conn.Open();
                command.Connection = conn;
                command.CommandText = @"SELECT Film_ID, Titel, Stock, Release_datum
                                        FROM Film
                                        WHERE Stock > 0
                                        ORDER BY Titel";
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
        //SCAN CODE - controleer of film in database zit op basis van barcode
        public void zoekFilmInDatabase()
        {
            zoekOfBarcodeAanwezigIsInDB();
            if (aanwezigInDatabase == 1)
            {
                //maak een db connectie
                conn = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand();
                try
                {
                    conn = new SqlConnection(connectionString);
                    conn.Open();
                    command.Connection = conn;
                    command.CommandText = @"SELECT Barcode, Onlinezoeken_ID
                                        FROM Film
                                        WHERE Barcode = @Barcode;";
                    command.Parameters.AddWithValue("@Barcode", opgezochtefilm._Barcode);
                    SqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {
                        Film filminDB = new Film
                        {
                            _Id = SafeReadValue<int>(dataReader, "Onlinezoeken_ID"),
                            _Barcode = SafeReadValue<string>(dataReader, "Barcode"),
                        };
                        if (filminDB._Barcode == opgezochtefilm._Barcode)
                        {
                             gevondenCode = filminDB._Id;
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
            else
            {
                MessageBox.Show("Barcode incorrect.", "Probeer hernieuw", MessageBoxButton.OK);
            }
        }

        //update gegevens van gezochte film
        public void updateGegevensFilm()
        {
            if (aanwezigInDatabase == 1)
            { }
            else
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
                        Film filminDB = new Film
                        {
                            _Id = SafeReadValue<int>(dataReader, "Onlinezoeken_ID"),
                            _Titel = SafeReadValue<string>(dataReader, "Titel"),
                            _Release = SafeReadValue<int>(dataReader, "Release_datum")
                        };
                        if (filminDB._Titel == opgezochtefilm._Titel && filminDB._Id == opgezochtefilm._Id)
                        { }
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
        }

        //Methode om de SQL database te raadplegen en gegevens in te lezen.
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
    

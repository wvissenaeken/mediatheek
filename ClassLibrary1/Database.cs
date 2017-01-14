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
        public int aanwezigOnlineIDinDatabase;
        public int gevondenCode;

        public Film opgezochtefilm = new Film();
        public Klant VerifieerKlant = new Klant();

        public Database()
        {
        }

        //--------------------------//
        //DBconnecties mbt KLANT//
        //--------------------------//
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

        //Zoek of online ID aanwezig is in eigen database
        public int zoekOfIDAanwezigIsInDB()
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
                                        WHERE Onlinezoeken_ID =@OzID;";
                command.Parameters.AddWithValue("@OzID", opgezochtefilm._Id);
                object resultaat = command.ExecuteScalar();
                aanwezigOnlineIDinDatabase = (int)resultaat;
                return aanwezigOnlineIDinDatabase;
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
                    command.CommandText = @"SELECT Barcode, Onlinezoeken_ID, Stock, Titel, Release_datum
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
                            _Titel = SafeReadValue<string>(dataReader,"Titel"),
                            _Stock = SafeReadValue<int>(dataReader,"Stock"),
                            _Release = SafeReadValue<int>(dataReader,"Release_datum")
                        };
                        if (filminDB._Barcode == opgezochtefilm._Barcode)
                        {
                            gevondenCode = filminDB._Id;
                            opgezochtefilm._Titel = filminDB._Titel;
                            opgezochtefilm._Release = filminDB._Release;
                            opgezochtefilm._Stock = filminDB._Stock;
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
            zoekOfIDAanwezigIsInDB();
            if (aanwezigInDatabase == 1| aanwezigOnlineIDinDatabase ==1)
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

        //--------------------------//
        //DBconnecties mbt KLANT//
        //--------------------------//
        //Verifieer of klant bestaat op basis van unieke EID-kaartnummer
        public int DB_VerifieerKlant()
        {
            //DBCONNECT
            conn = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            try
            {
                //DBCONN OPEN
                conn.Open();
                command.Connection = conn;
                command.CommandText = @"SELECT COUNT(*) FROM Klanten WHERE Klant_ID = @Klant_ID;";
                command.Parameters.AddWithValue("@Klant_ID", VerifieerKlant.Kaartnummer);
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
                //DBCONN CLOSE
                conn.Close();
                conn.Dispose();
            }
        }

        //Oproepen/bijwerken van de klantgegevens
        public void DB_UpdateKlant()
        {
            DB_VerifieerKlant();
            if (aanwezigInDatabase == 1)
            {
                //Eventueel bijwerken van de bestaande gegevens, wanneer bijvoorbeeld adres wijzigde???????
            }
            else
            {
                //DBCONNECT
                conn = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand();
                try
                {
                    conn = new SqlConnection(connectionString);
                    //DBCONN OPEN
                    conn.Open();
                    command.Connection = conn;
                    //CONTROLE of klant bestaat
                    command.CommandText = @"SELECT Voornaam, Achternaam, Adres, Postcode_Gemeente, Geslacht, Geboortedatum, Lid_sinds, Geboorteplaats, Klant_ID, Telefoon, Email FROM Klanten";
                    SqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {
                        Klant DBKlant = new Klant
                        {
                            Voornaam = SafeReadValue<string>(dataReader, "Voornaam"),
                            Achternaam = SafeReadValue<string>(dataReader, "Achternaam"),
                            Adres = SafeReadValue<string>(dataReader, "Adres"),
                            Postcode_Gemeente = SafeReadValue<string>(dataReader, "Postcode_Gemeente"),
                            Geslacht = SafeReadValue<string>(dataReader, "Geslacht"),
                            Geboortedatum = SafeReadValue<DateTime>(dataReader, "Geboortedatum"),
                            Geboorteplaats = SafeReadValue<string>(dataReader, "Geboorteplaats"),
                            Lidmaatschap = SafeReadValue<DateTime>(dataReader, "Lid_sinds"),
                            Kaartnummer = SafeReadValue<string>(dataReader, "Klant_ID"),
                            Telefoon = SafeReadValue<string>(dataReader, "Telefoon"),
                            Email = SafeReadValue<string>(dataReader, "Email")
                        };
                        if (DBKlant.Kaartnummer == VerifieerKlant.Kaartnummer)
                        {
                            //Zie hoger. Quid inzake bijwerken?
                        }
                        else
                        {
                            //DBCONN CLOSE
                            conn.Close();
                            conn.Dispose();
                            //DBCONN OPEN NEW
                            conn = new SqlConnection(connectionString);
                            conn.Open();
                            command.Connection = conn;
                            command.CommandText = @" INSERT INTO dbo.Klanten (Voornaam, Achternaam, Adres, Postcode_Gemeente, Geslacht, Geboortedatum, Lid_sinds, Geboorteplaats, Klant_ID, Telefoon, Email)
                                               VALUES (@Voornaam, @Achternaam, @Adres, @Postcode_Gemeente, @Geslacht, @Geboortedatum, @Lid_sinds, @Geboorteplaats, @Kaart_ID, @Telefoon, @Email);";
                            command.Parameters.AddWithValue("@Voornaam", VerifieerKlant.Voornaam);
                            command.Parameters.AddWithValue("@Achternaam", VerifieerKlant.Achternaam);
                            command.Parameters.AddWithValue("@Adres", VerifieerKlant.Adres);
                            command.Parameters.AddWithValue("@Postcode_Gemeente", VerifieerKlant.Postcode_Gemeente);
                            command.Parameters.AddWithValue("@Geslacht", VerifieerKlant.Geslacht);
                            command.Parameters.AddWithValue("@Geboortedatum", VerifieerKlant.Geboortedatum);
                            command.Parameters.AddWithValue("@Lidmaatschap", VerifieerKlant.Lidmaatschap);
                            command.Parameters.AddWithValue("@Geboorteplaats", VerifieerKlant.Geboorteplaats);
                            command.Parameters.AddWithValue("@Kaartnummer", VerifieerKlant.Kaartnummer);
                            command.Parameters.AddWithValue("@Telefoon", VerifieerKlant.Telefoon);
                            command.Parameters.AddWithValue("@Email", VerifieerKlant.Email);
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
                    //DBCONN CLOSE
                    conn.Close();
                    conn.Dispose();
                }
            }
        }

    }
}
    

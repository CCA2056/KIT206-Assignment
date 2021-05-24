using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using MySql.Data.Types;

namespace RAP
{
    abstract class DBconnect
    {
        private static List<Researcher> DBresearchers = new List<Researcher>();
        private static List<Publication> DBpublications = new List<Publication>();
        private const string db = "kit206";
        private const string user = "kit206";
        private const string pass = "kit206";
        private const string server = "alacritas.cis.utas.edu.au";

        private static MySqlConnection conn = null;
        public static T ParseEnum<T>(string type)
        {
            return (T)Enum.Parse(typeof(T), type);
        }
        private static MySqlConnection GetConnection()
        {
            if (conn == null)
            {
                //Note: This approach is not thread-safe
                string connectionString = String.Format("Database={0};Data Source={1};User Id={2};Password={3}", db, server, user, pass);
                conn = new MySqlConnection(connectionString);
            }
            return conn;
        }

        public static List<Researcher> LoadAll()
        {
            List<Researcher> researchers = new List<Researcher>();

            MySqlConnection conn = GetConnection();
            MySqlDataReader rdr = null;

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM researcher", conn);

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {

                    if (rdr.GetString(1) == "Student")
                    {

                        researchers.Add(new Student
                        {

                            ID = rdr.GetInt32(0),
                            GivenName = rdr.GetString(2),
                            FamilyName = rdr.GetString(3),
                            Title = rdr.GetString(4),
                            Unit = rdr.GetString(5),
                            Campus = rdr.GetString(6),
                            Email = rdr.GetString(7),
                            Photo = rdr.GetString(8),
                            Degree = rdr.GetString(9),
                            SupervisorID = rdr.GetInt32(10),
                            Level = EmploymentLevel.Student,
                            EarliestStart = rdr.GetDateTime(12),
                            CurrentJobStartDate = rdr.GetDateTime(13),

                        }); ;
                    }
                    else
                    {

                        researchers.Add(new Staff
                        {
                            ID = rdr.GetInt32(0),
                            GivenName = rdr.GetString(2),
                            FamilyName = rdr.GetString(3),
                            Title = rdr.GetString(4),
                            Unit = rdr.GetString(5),
                            Campus = rdr.GetString(6),
                            Email = rdr.GetString(7),
                            Photo = rdr.GetString(8),
                            Level = ParseEnum<EmploymentLevel>(rdr.GetString(11)),
                            EarliestStart = rdr.GetDateTime(12),
                            CurrentJobStartDate = rdr.GetDateTime(13),
                        });
                        
                    }
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error connecting to database: " + e);
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }
            DBresearchers = researchers;
            return researchers;
        }
        public static List<Publication> LoadAllPub()
        {
            List<Publication> publications = new List<Publication>();

            MySqlConnection conn = GetConnection();
            MySqlDataReader rdr = null;

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM publication", conn);

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    publications.Add(new Publication
                    {
                        DOI = rdr.GetString(0),
                        Title = rdr.GetString(1),
                        Authors = rdr.GetString(2),
                        Year = rdr.GetInt32(3),
                        Type = ParseEnum<PublicationType>(rdr.GetString(4)),
                        Cite_as = rdr.GetString(5),
                        Available = rdr.GetDateTime(6)
                    });
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error connecting to database: " + e);
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }
            DBpublications = publications;
            return publications;
        }
        public static string getSupervisor(Student researcher)
        {
            string supervisor = "";
            MySqlConnection conn = GetConnection();
            MySqlDataReader rdr = null;
            
    
               try
                {
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand("SELECT given_name, family_name FROM researcher WHERE id=" + researcher.SupervisorID, conn);

                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        supervisor = rdr.GetString(0) + " " + rdr.GetString(1);
                    }
                }
                catch (MySqlException e)
                {
                    Console.WriteLine("Error connecting to database: " + e);
                }
                finally
                {
                    if (rdr != null)
                    {
                        rdr.Close();
                    }
                    if (conn != null)
                    {
                        conn.Close();
                    }
                }
            return supervisor;
        }

        public static List<Student> getSupervision(Staff s)
        {
            List<Student> students = new List<Student>();
            MySqlConnection conn = GetConnection();
            MySqlDataReader rdr = null;

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM researcher WHERE supervisor_id=" + s.ID, conn);

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    students.Add(new Student
                    {
                        ID = rdr.GetInt32(0),
                        GivenName = rdr.GetString(2),
                        FamilyName = rdr.GetString(3),
                        Title = rdr.GetString(4),
                    });

                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error connecting to database: " + e);
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return students;
        }

        public static List<Position> getPosition(Staff staff)
        {
            List<Position> positions = new List<Position>();
            MySqlConnection conn = GetConnection();
            MySqlDataReader rdr = null;
            DateTime endDate;

            try
            {
                conn.Open();

                // retrieve the position of the researcher from the latest to the earliest
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM position WHERE id=" + staff.ID + " ORDER BY start DESC", conn);

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    if (!rdr.IsDBNull(3))
                    {
                        endDate = rdr.GetDateTime(3);
                    }
                    else
                    {
                        endDate = Convert.ToDateTime("01/01/1900");
                    }

                    positions.Add(new Position
                    {
                        Level = ParseEnum<EmploymentLevel>(rdr.GetString(1)),
                        StartDate = rdr.GetDateTime(2),
                        EndDate = endDate,
                        
                    });

                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error connecting to database: " + e);
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return positions;
        }

        public static List<Publication> getPublication(Researcher researcher)
        {
            List<Publication> pubs = new List<Publication>();
            MySqlConnection conn = GetConnection();
            MySqlDataReader rdr = null;


            try
            {
                conn.Open();

                // retrieve the publications of the researcher
                MySqlCommand cmd = new MySqlCommand("SELECT publication.doi,publication.title,publication.authors,publication.year,publication.type,publication.cite_as,publication.available FROM researcher_publication, publication WHERE publication.doi = researcher_publication.doi AND researcher_publication.researcher_id=" + researcher.ID + " ORDER BY year DESC, title ASC", conn);

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    pubs.Add(new Publication
                    {
                        DOI = rdr.GetString(0),
                        Title = rdr.GetString(1),
                        Authors = rdr.GetString(2),
                        Year = rdr.GetInt32(3),
                        Type = ParseEnum<PublicationType>(rdr.GetString(4)),
                        Cite_as = rdr.GetString(5),
                        Available = rdr.GetDateTime(6)
                    });

                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error connecting to database: " + e);
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return pubs;
        }
    }
}

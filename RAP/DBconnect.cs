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
                            SupervisorID = rdr.GetInt32(10)
                        });
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
            return researchers;
        }

        public static string getSupervisor(Student s)
        {
            string supervisor = "";
            MySqlConnection conn = GetConnection();
            MySqlDataReader rdr = null;

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT given_name, family_name FROM researcher WHERE id=" + s.SupervisorID, conn);

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
                        Unit = rdr.GetString(5),
                        Campus = rdr.GetString(6),
                        Email = rdr.GetString(7),
                        Photo = rdr.GetString(8),
                        Degree = rdr.GetString(9),
                        SupervisorID = rdr.GetInt32(10)
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

    }
}

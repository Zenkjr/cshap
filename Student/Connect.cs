using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Student
{
    class Connect
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        public void Initialize()
        {
            server = "localhost";
            database = "aptech_fpt";
            uid = "root";
            password = "";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + "; CharSet=utf8;";

            connection = new MySqlConnection(connectionString);
            //Boolean open = OpenConnection();
            //Console.WriteLine(open);
        }
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool Insert(Students students)
        {

            string query = "INSERT INTO student (rollNumber, name, email, phone) VALUES('" + students.RollNumber + "', '" + students.Name + "', '" + students.Email + "', '" + students.Phone + "')";

            //open connection
            if (this.OpenConnection() == true)
            {
                try
                {
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    //Execute command
                    cmd.ExecuteNonQuery();
                    //close connection
                    this.CloseConnection();
                    //Console.ReadKey();
                    return true;
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return false;
        }
        public void ConectMySQL()
        {
            Students students = new Students("d65989", "ngo nam", "nam2@gmail.com", "01514654544");
            Initialize();
            Insert(students);
        }
    }
}

﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceRegistrationWinForm
{
    internal class DBConnect
    {
        public MySqlConnection connection { get; set; }
        public MySqlCommand command { get; set; }
        public MySqlDataAdapter dataAdapter { get; set; }
        public DataTable dataTable { get; set; }

        public string server { get; set; }
        public string database { get; set; }
        public string uid { get; set; }
        public string password { get; set; }
        public string connectionString { get; set; }

        public DBConnect()
        {
            connection = new MySqlConnection();
            command= new MySqlCommand();
            dataAdapter= new MySqlDataAdapter();
            dataTable = new DataTable();
            server = string.Empty;
            database= string.Empty;
            uid= string.Empty;
            password= string.Empty;
            connectionString = string.Empty;
        }

        public void OpenDB()
        {
            try
            {
                server = "localhost";
                database = "conreg";
                uid = "root";
                password = "root";
                connectionString = "SERVER="+server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
                connection = new MySqlConnection(connectionString);
                connection.Open();
                //MessageBox.Show("You are now connected to the database");

            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void CloseDB()
        {
            connection.Close();
        }

        public DataTable ReadRegistrationRecord()
        {
            OpenDB();
            string sql = "SELECT * FROM tblregister";
            dataTable = new DataTable();
            command = new MySqlCommand(sql, connection);
            dataTable.Load(command.ExecuteReader());
            CloseDB();
            return dataTable;
        }

        public void InsertRegistration(Registration reg)
        {
            OpenDB();
            string sql =
                "INSERT INTO tblregister (regid,firstname,lastname,address,contactno) " +
                "VALUES('" + reg.regid + "'," +
                "'" + reg.firstname + "'," +
                "'" + reg.lastname + "'," +
                "'" + reg.address + "'," +
                "'" + reg.contactno + "')";
            command = new MySqlCommand(sql, connection);
            command.ExecuteNonQuery();
            CloseDB();
        }


    }
}

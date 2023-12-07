using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using ArcadeAppNick.Models; 

namespace ArcadeAppNick;

public class UserRepository
{
    string dbPath;
    private SQLiteConnection conn; 

    public UserRepository(string db)
    {
        dbPath = db;
    }

    private void Init()
    {
        //check if connection successful
        if (conn != null)
            return;
        //set connection
        conn = new SQLiteConnection(dbPath);
        //generate table (database)
        conn.CreateTable<Users>();
    }

    public void AddUser(string username, string password)
    {
        int result = 0;
        Init();

        if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
        {
            //inserts a new user into the database with a username and password
            result = conn.Insert(new Users { Username = username, Password = password });
        }
    }

    public Users GetUser(string username)
    {
        Init();
        //searches the databse for a entry with a matching username
        return conn.Table<Users>().Where(u => u.Username == username).FirstOrDefault();
    }
}

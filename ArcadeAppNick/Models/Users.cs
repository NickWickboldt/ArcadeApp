using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite; 

namespace ArcadeAppNick.Models;

[Table("users")]
public class Users
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [MaxLength(250), Unique]
    public string Username { get; set; }

    [MaxLength(250), Unique]
    public string Password { get; set; }
}
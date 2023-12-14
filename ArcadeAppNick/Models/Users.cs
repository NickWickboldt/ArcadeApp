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

    public int BabyGoat { get; set; }
    public int Buffalo { get; set; }
    public int Hyena { get; set; }
    public int Moose { get; set; }
    public int PolarBear {  get; set; }
    public int Rat {  get; set; }
    public int Seal { get; set; }
    public int Tiger {  get; set; }
    public int Shark { get; set; }
    
}
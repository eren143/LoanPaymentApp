 using System;

namespace API.Entities;

//the class will be a table in the database
public class AppUser
{
    //each property will be a column
    public int Id { get; set; }
    public required string UserName { get; set; }
}
 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User
{
    public string username;
    public string email;
    public string password;
    public string passwordRpt;

    public User()
    {

    }

    public User(string username, string email, string password, string passwordRpt)
    {
        this.username = username;
        this.email = email;
        this.password = password;
        this.passwordRpt = passwordRpt;
    }
}

public class User
{

        
    public int Userid { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    
    public User()
    {
        Username = "";
        Password = "";
            
    }

    public User(int Userid, string Username, string Password)
    {
        this.Userid = Userid;
        this.Username = Username;
        this.Password = Password;
       
    }


}

//Data entities in the application
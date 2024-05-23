class User
{

        
    public int Userid { get; set; }
    public string Username { get; set; }
    public int PIN { get; set; }
    
    public User()
    {
        Username = "";
            
    }

    public User(int Userid, string Username, int PIN)
    {
        this.Userid = Userid;
        this.Username = Username;
        this.PIN = PIN;
       
    }


}

//Data entities in the application
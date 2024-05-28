class UserService
{
    UserRepo up;
    

    //Constructor
    public UserService(UserRepo up)
    {
        this.up = up;
    }

 public User Login(string Username, string inputPassword)
    {
        User user = up.GetUser(Username);

        if (inputPassword == user.Password)
        {
            return user;
        }
        else
        {
            System.Console.WriteLine("Password is incorrect");
            
        } return null;
    }
}


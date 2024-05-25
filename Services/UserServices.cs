class UserService
{
        UserRepo up;

    public UserService(UserRepo up)
    {
        this.up = up;
    }
        
    public User? Login(string username, string Password)
    {
        //Get all users
        User? allUsers = up.GetUser(2);

            if (allUsers.Username == username && allUsers.Password == Password)

            {
                   
            return allUsers; //us returning the user will indicate success.
            } 
            else
            {
            System.Console.WriteLine("Invalid Password! Please Try Again!");
            return null; 
            }            
    }
}
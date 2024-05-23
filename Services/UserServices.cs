class UserService
{
        UserRepo up;

    public UserService(UserRepo up)
    {
        this.up = up;
    }
        
    public User? Login(string username, int PIN)
    {
        //Get all users
        User? allUsers = up.GetUser(2);

            if (allUsers.Username == username && allUsers.PIN == PIN)

            {
                   
            return allUsers; //us returning the user will indicate success.
            } 
            else
            {
            System.Console.WriteLine("Invalid PIN! Please Try Again!");
            return null; 
            }            
    }
}
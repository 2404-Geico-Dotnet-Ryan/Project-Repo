class UserService
{
    UserRepo ur = new();
        
    public User? Login(string username, int PIN)
    {
        //Get all users
        User? allUsers = ur.GetUser(2);

        //check each one to see if we find a match.
            
            //If matching username and password, they 'login' -> return that user
            if (allUsers.Username == username && allUsers.PIN == PIN)

            {
                   
            return allUsers; //us returning the user will indicate success.
            } 
            else
            {
            System.Console.WriteLine("Invalid PIN! Please Try Again!");
            return null; //reject the login
            }            
    }
}
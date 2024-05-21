class UserRepo

{

    UserStorage userStorage = new();
    //private readonly string _connectionString; //comment out later****  the underscore means private so you could leave the word off and it would be the same.
    //public UserRepo(string connString) //****Dependency injection within the constructor
   // {
    //    _connectionString = connString; //****
    //}

    public User? GetUser(int id)
    {
        if (userStorage.users.ContainsKey(id))
        {
            User selectedUser = userStorage.users[id];
            return selectedUser;
        }
        else
        {
            System.Console.WriteLine("Invalid PIN - Please Try Again");
            return null;
        }
    }

    
}

//How to interact with the data (abstracts the data layer) CRUD operations - create, read, update, delete

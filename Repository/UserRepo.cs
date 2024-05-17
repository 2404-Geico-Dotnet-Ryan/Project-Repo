class UserRepo

{

    UserStorage userStorage = new();

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

class UserStorage
{

    public Dictionary<int, User> users;
    public int idcounter=1;
    

    public UserStorage()
    {
        User user1 = new User(idcounter, "Guest", 1);idcounter++;
        User user2 = new User(idcounter, "Maintenance", 12345);idcounter++;
       
        users = [];
        users.Add(user1.Userid, user1);
        users.Add(user2.Userid, user2);
      
    }

}

//The place where the data is stored. Writes to the database or file system.
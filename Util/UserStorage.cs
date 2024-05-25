class UserStorage
{

    public Dictionary<int, User> users;
    public int idcounter = 1;


    public UserStorage()
    {
        User user1 = new User(idcounter, "Guest", "1"); idcounter++;
        User user2 = new User(idcounter, "Maintenance", "12345"); idcounter++;
        User user3 = new User(idcounter, "Gayle", "pass1"); idcounter++;
        User user4 = new User(idcounter, "Barb", "pass4"); idcounter++;
        User user5 = new User(idcounter, "Sally", "pass5"); idcounter++;
        User user6 = new User(idcounter, "Mike", "pass6"); idcounter++;

        users = [];
        users.Add(user1.Userid, user1);
        users.Add(user2.Userid, user2);
        users.Add(user3.Userid, user3);
        users.Add(user4.Userid, user4);
        users.Add(user5.Userid, user5);
        users.Add(user6.Userid, user6);

    }

}

//The place where the data is stored. Writes to the database or file system.

using Microsoft.Data.SqlClient;

class UserRepo
{

    private readonly string _connectionString;

    
    public UserRepo(string connString)
    {
        _connectionString = connString;
    }

      
    public User? GetUser(int id)
    {
        try
        {
            //Set up DB Connection
            using SqlConnection connection = new(_connectionString);
            connection.Open();

            //Create the SQL String
            string sql = "SELECT * FROM dbo.[USER] WHERE Id = @Id";

            //Set up SqlCommand Object
            using SqlCommand cmd = new(sql, connection);
            cmd.Parameters.AddWithValue("@Id", id);

            //Execute the Query
            using var reader = cmd.ExecuteReader();

            //Extract the Results
            if (reader.Read())
            {
                //for each iteration -> extract the results to a User object -> add to list.
                User newUser = BuildUser(reader);
                return newUser;
            }

            return null; //Didnt find anyone :(

        }
        catch (Exception e)
        {
            System.Console.WriteLine(e.Message);
            System.Console.WriteLine(e.StackTrace);
            return null;
        }
    }

    public List<User>? GetAllUsers()
    {
        List<User> users = [];

        try
        {
            //Set up DB Connection
            using SqlConnection connection = new(_connectionString);
            connection.Open();

            //Create the SQL String
            string sql = "SELECT * FROM dbo.[USER]";

            //Set up SqlCommand Object
            using SqlCommand cmd = new(sql, connection);

            //Execute the Query
            using var reader = cmd.ExecuteReader(); 

            //Extract the Results
            while (reader.Read())
            {
                
                User newUser = BuildUser(reader);

               
                users.Add(newUser);
            }

            return users;
        }
        catch (Exception e)
        {
            System.Console.WriteLine(e.Message);
            System.Console.WriteLine(e.StackTrace);
            return null;
        }
    }

    
    //Helper Method
    private static User BuildUser(SqlDataReader reader)
    {
        User newUser = new();
        newUser.Userid = (int)reader["Id"];
        newUser.Username = (string)reader["Username"];
        newUser.PIN = (int)reader["PIN"];
        

        return newUser;
    }
}

//How to interact with the data (abstracts the data layer) CRUD operations - create, read, update, delet
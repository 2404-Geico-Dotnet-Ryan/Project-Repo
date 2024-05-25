using Microsoft.Data.SqlClient;

public class VendingMachineRepo

{
    private readonly string _connectionString;

    public VendingMachineRepo(string connString)
    {
        _connectionString = connString;
    }
    

    public VendingMachine? GetItem(int id)
    {

        using SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();

        string sql = "SELECT * FROM [GayleVendingMachine].[dbo].[vendingMachine] where Id = @Id";
        using SqlCommand cmd = new(sql, connection);

        cmd.Parameters.AddWithValue("@Id", id);
        using var reader = cmd.ExecuteReader();

        if (reader.Read())
        {
            VendingMachine newVendingMachine = BuildVendingMachine(reader);
            return newVendingMachine;
        }
        else
        {
            return null;
        }

    }


    public List<VendingMachine>? GetAllitems()
    {
        
        List<VendingMachine> vendingMachines = new();

        try
        {

            using SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            string sql = "SELECT  *  FROM [GayleVendingMachine].[dbo].[vendingMachine]";
            using SqlCommand cmd = new(sql, connection);

            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                VendingMachine newVendingMachine = BuildVendingMachine(reader);
                vendingMachines.Add(newVendingMachine);

            }
            return vendingMachines;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine(e.StackTrace);
            return null;
        }

    }

    private static VendingMachine BuildVendingMachine(SqlDataReader reader)
    {
        VendingMachine newVendingMachine = new();
        newVendingMachine.Id = (int)reader["Id"];
        newVendingMachine.Item = (string)reader["Item"];
        newVendingMachine.Price = (double)(decimal)reader["Price"];
        newVendingMachine.Quantity = (int)reader["Quantity"];
        newVendingMachine.Sold = (int)reader["Sold"];

        return newVendingMachine;
    }


    public VendingMachine? UpdatedItem(VendingMachine item)
    {


        using SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();

        string sql = "UPDATE [GayleVendingMachine].[dbo].[vendingMachine] SET Price = @Price, Sold = @Sold, Quantity = @Quantity OUTPUT inserted.* WHERE Id = @Id";

        using SqlCommand cmd = new(sql, connection);

        cmd.Parameters.AddWithValue("@Id", item.Id);
        cmd.Parameters.AddWithValue("@Price", item.Price);
        cmd.Parameters.AddWithValue("@Sold", item.Sold);
        cmd.Parameters.AddWithValue("@Quantity", item.Quantity);


        using var reader = cmd.ExecuteReader();

        if (reader.Read())
        {
            VendingMachine newVendingMachine = BuildVendingMachine(reader);
            return newVendingMachine;
        }
        else
        {
            return null;
        }

    }

}


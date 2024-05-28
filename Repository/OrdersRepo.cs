using Microsoft.Data.SqlClient;
public class OrdersRepo
{
    private readonly string _connectionString;

    public OrdersRepo(string connString)
    {
        _connectionString = connString;
    }

    public Orders? AddAllOrders(Orders Oh)
    {
        try
        {

            using SqlConnection connection = new(_connectionString);
            connection.Open();


            string sql = "INSERT into dbo.[Purchasehistory] OUTPUT inserted.* VALUES (@Username, @Item, @Quantity, @Purchasedate)";

            using SqlCommand cmd = new(sql, connection);
           
            cmd.Parameters.AddWithValue("@Username", Oh.Username);
            cmd.Parameters.AddWithValue("@Item", Oh.Item);
            cmd.Parameters.AddWithValue("@Quantity", Oh.Quantity);
            cmd.Parameters.AddWithValue("@Purchasedate", Oh.Purchasedate);


            using SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {

                Orders newPurchaseHistory = BuildVisit(reader);
                return newPurchaseHistory;
            }
            else
            {

                return null;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine(e.StackTrace);
            return null;
        }
    }

    public List<Orders> GetAllOrders(string username)
    {
        List<Orders> purchaseHistory = new();

        try
        {

            using SqlConnection connection = new(_connectionString);
            connection.Open();


            string sql = "SELECT * FROM dbo.[Purchasehistory] where Username = @Username order by Purchasedate";


            using SqlCommand cmd = new(sql, connection);
            cmd.Parameters.AddWithValue("@Username", username);


            using SqlDataReader reader = cmd.ExecuteReader();


            while (reader.Read())
            {

                Orders allpurchaseHistory = BuildVisit(reader);
                purchaseHistory.Add(allpurchaseHistory);
            }

            return purchaseHistory;
        }

        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine(e.StackTrace);
            return null;
        }
    }

    private static Orders BuildVisit(SqlDataReader reader)
    {
        Orders newpurchaseHistory = new();
        newpurchaseHistory.Id = (int)reader["Id"];
        newpurchaseHistory.Username = (string)reader["Username"];
        newpurchaseHistory.Item = (string)reader["Item"];
        newpurchaseHistory.Quantity = (int)reader["Quantity"];
        newpurchaseHistory.Purchasedate = (DateTime)reader["Purchasedate"];

        return newpurchaseHistory;
    }
}
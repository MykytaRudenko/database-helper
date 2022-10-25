namespace DatabaseHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            const string connStr = @"Data Source=DESKTOP-2DC9VDS\SQLEXPRESS;Initial Catalog=testdb;Integrated Security=True;TrustServerCertificate=True;";
            Database db = new Database(connStr);
            int i = db.ExecuteCommand("INSERT INTO test_table VALUES ('AAA', '13');");
            Console.WriteLine("Inserted: " + i);
            db.Destroy();
        }
    }
}

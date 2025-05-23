using System.Data.SQLite;
using System.IO;

namespace SouthVPN
{
    public static class DatabaseHelper
    {
        public static string dbPath = "users.db";

        public static void Init()
        {
            if (!File.Exists(dbPath))
            {
                SQLiteConnection.CreateFile(dbPath);
                using var conn = new SQLiteConnection($"Data Source={dbPath};Version=3;");
                conn.Open();
                string sql = "CREATE TABLE users (id INTEGER PRIMARY KEY, username TEXT NOT NULL, password TEXT NOT NULL)";
                using var cmd = new SQLiteCommand(sql, conn);
                cmd.ExecuteNonQuery();

                sql = "INSERT INTO users (username, password) VALUES ('admin', 'vpn123')";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
        }

        public static bool CheckLogin(string username, string password)
        {
            using var conn = new SQLiteConnection($"Data Source={dbPath};Version=3;");
            conn.Open();
            string sql = "SELECT COUNT(*) FROM users WHERE username = @user AND password = @pass";
            using var cmd = new SQLiteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@user", username);
            cmd.Parameters.AddWithValue("@pass", password);
            long count = (long)cmd.ExecuteScalar();
            return count == 1;
        }
    }
}

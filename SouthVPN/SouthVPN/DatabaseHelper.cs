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

                // Hash des Passworts 'vpn123' erzeugen
                string hashedPassword = PasswordHasher.Hash("vpn123");

                sql = "INSERT INTO users (username, password) VALUES (@user, @pass)";
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@user", "admin");
                cmd.Parameters.AddWithValue("@pass", hashedPassword);
                cmd.ExecuteNonQuery();
            }
        }

        public static bool CheckLogin(string username, string password)
        {
            using var conn = new SQLiteConnection($"Data Source={dbPath};Version=3;");
            conn.Open();

            string hashedPassword = PasswordHasher.Hash(password);

            string sql = "SELECT COUNT(*) FROM users WHERE username = @user AND password = @pass";
            using var cmd = new SQLiteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@user", username);
            cmd.Parameters.AddWithValue("@pass", hashedPassword);

            long count = (long)cmd.ExecuteScalar();
            return count == 1;
        }

        public static bool UserExists(string username)
        {
            using var conn = new SQLiteConnection($"Data Source={dbPath};Version=3;");
            conn.Open();

            string sql = "SELECT COUNT(*) FROM users WHERE username = @user";
            using var cmd = new SQLiteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@user", username);
            long count = (long)cmd.ExecuteScalar();
            return count > 0;
        }

        public static bool RegisterUser(string username, string password)
        {
            try
            {
                string hashed = PasswordHasher.Hash(password);

                using var conn = new SQLiteConnection($"Data Source={dbPath};Version=3;");
                conn.Open();

                string sql = "INSERT INTO users (username, password) VALUES (@user, @pass)";
                using var cmd = new SQLiteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@user", username);
                cmd.Parameters.AddWithValue("@pass", hashed);
                cmd.ExecuteNonQuery();

                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}

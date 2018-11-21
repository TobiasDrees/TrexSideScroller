using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sidescroller
{
    public sealed class SQLManager
    {

        private static SQLManager instance = null;
        private static readonly object padlock = new object();

        SQLManager()
        {
            connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\\..\\..\\Sidescroller.accdb");
        }

        ~SQLManager()
        {
            if (connection.State != 0)
                connection.Close();
        }

        public static SQLManager Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new SQLManager();
                    }
                    return instance;
                }
            }
        }

        private OleDbConnection connection;
        private OleDbCommand cmd;
        private string SELECT_USER = "SELECT * FROM [User] WHERE Login=?;";
        private string INSERT_USER = "INSERT INTO [User] ([Login], [Password], [Username]) VALUES (?, ?, ?);";
        private string SELECT_USER_UPGRADES = "SELECT upgrade_ID FROM [User_upgrades] WHERE user_ID=?;";
        private string INSERT_USER_UPGRADE = "INSERT INTO [User_upgrades] ([user_ID], [upgrade_ID]) VALUES (?, ?);";
        private string SELECT_HIGHSCORE = "SELECT * FROM [Highscore]";

        public User selectUser(string login)
        {
            if (!String.IsNullOrEmpty(login))
            {
                connection.Open();
                try {
                    cmd = connection.CreateCommand();
                    cmd.CommandText = SELECT_USER;
                    cmd.Parameters.AddWithValue("?", login);

                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // User: id, login, password, name
                            if (reader.FieldCount != 5)
                                throw new Exception(String.Format("Invalid entry for user! Fieldcount was {0} expected was 5!", reader.FieldCount));
                            return new User(Convert.ToInt32(reader[0]), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), Convert.ToInt32(reader[4]));
                        }
                    }
                    return null;
                }
                finally
                {
                    connection.Close();
                }                
            }
            else
            {
                throw new ArgumentNullException("login");
            }
        }

        public int insertUser(User user)
        {
            if (user != null)
            {
                connection.Open();
                try
                {
                    cmd = connection.CreateCommand();
                    cmd.CommandText = INSERT_USER;
                    cmd.Parameters.AddWithValue("?", user.Login);
                    cmd.Parameters.AddWithValue("?", PasswordHasher.Hash(user.Password));
                    cmd.Parameters.AddWithValue("?", user.Name);

                    return cmd.ExecuteNonQuery();
                }
                finally
                {
                    connection.Close();
                }
            } 
            else
            {
                throw new ArgumentNullException("user");
            }
        }

        public LinkedList<HighscoreEntry> selectHighscore()
        {
            connection.Open();
            try
            {
                cmd = connection.CreateCommand();
                cmd.CommandText = SELECT_HIGHSCORE;
                LinkedList<HighscoreEntry> highscoreList = new LinkedList<HighscoreEntry>();
                int place = 1;
                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // HistoryEntry: place, name, score
                        if (reader.FieldCount != 3)
                            throw new Exception(String.Format("Invalid entry for highscore! Fieldcount was {0} expected was 3!", reader.FieldCount));

                        HighscoreEntry entry = new HighscoreEntry();
                        entry.setFields(place, reader[0].ToString(), Convert.ToInt64(reader[1]));
                        highscoreList.AddLast(entry);
                        place++;
                    }
                }
                return highscoreList;
            }
            finally
            {
                connection.Close();
            }
        }

        public int updateUserProgress(User user)
        {
            if (user != null)
            {
                connection.Open();
                try
                {
                    cmd = connection.CreateCommand();
                    cmd.CommandText = INSERT_USER;
                    cmd.Parameters.AddWithValue("?", user.Login);
                    cmd.Parameters.AddWithValue("?", PasswordHasher.Hash(user.Password));
                    cmd.Parameters.AddWithValue("?", user.Name);
                    return cmd.ExecuteNonQuery();
                }
                finally
                {
                    connection.Close();
                }
            }
            else
            {
                throw new ArgumentNullException("user");
            }
        }

        public List<int> selectUserUpgrades(int user_ID)
        {
            if (user_ID != 0)
            {
                connection.Open();
                try
                {
                    cmd = connection.CreateCommand();
                    cmd.CommandText = SELECT_USER_UPGRADES;
                    cmd.Parameters.AddWithValue("?", user_ID);
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        List<int> result = new List<int>();
                        while (reader.Read())
                        {
                            if (reader.FieldCount != 1)
                                throw new Exception(String.Format("Invalid entry for user! Fieldcount was {0} expected was 1!", reader.FieldCount));
                            result.Add(Convert.ToInt32(reader[0]));
                        }
                        return result;
                    }
                }
                finally
                {
                    connection.Close();
                }
            }
            else
            {
                throw new ArgumentNullException("user_ID");
            }
        }

        public int insertUserUpgrade(User user, int upgradeId)
        {
            if (user != null)
            {
                connection.Open();
                try
                {
                    cmd = connection.CreateCommand();
                    cmd.CommandText = INSERT_USER_UPGRADE;
                    cmd.Parameters.AddWithValue("?", user.Id);
                    cmd.Parameters.AddWithValue("?", upgradeId);
                    return cmd.ExecuteNonQuery();
                }
                finally
                {
                    connection.Close();
                }
            }
            else
            {
                throw new ArgumentNullException("user");
            }
        }
    }
}

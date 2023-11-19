using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpecialProjectInventory
{
    public partial class HashPasswords : Form
    {
        public HashPasswords()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Confirmation dialog to ensure the admin wants to proceed.
            if (MessageBox.Show("Are you sure you want to hash all existing passwords? This action cannot be undone.",
                                "Confirm Password Hashing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    HashExistingPasswords();
                    MessageBox.Show("All passwords have been hashed successfully.", "Operation Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while hashing passwords: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void HashExistingPasswords()
        {
            using (SqlConnection connection = new SqlConnection(SpecialProjectInventory.DatabaseConfig.ConnectionString))
            {
                connection.Open();
                List<Tuple<int, string>> users = new List<Tuple<int, string>>();

                // Fetch all user IDs and passwords
                using (SqlCommand command = new SqlCommand("SELECT userID, password FROM tbUser", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int userId = reader.GetInt32(0);
                            string password = reader.GetString(1);
                            users.Add(Tuple.Create(userId, password));
                        }
                    } // The reader is closed here, so it's safe to continue using the connection
                }

                // Now hash each password and update
                foreach (var user in users)
                {
                    // Hash the password
                    string hashedPassword = ProjectUtility.HashPassword(user.Item2);

                    // Update the password in the database
                    using (SqlCommand updateCommand = new SqlCommand("UPDATE tbUser SET password = @password WHERE userID = @userID", connection))
                    {
                        updateCommand.Parameters.AddWithValue("@password", hashedPassword);
                        updateCommand.Parameters.AddWithValue("@userID", user.Item1);
                        updateCommand.ExecuteNonQuery();
                    }
                }
            }
        }



    }
}

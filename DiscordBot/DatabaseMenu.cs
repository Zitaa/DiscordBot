using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace DiscordBot
{
    public partial class DatabaseMenu : Form
    {
        private SqlConnection connection;
        private string connectionString;

        public DatabaseMenu()
        {
            InitializeComponent();

            connectionString = ConfigurationManager.ConnectionStrings["DiscordBot.Properties.Settings.UserDatabaseConnectionString"].ConnectionString;
        }

        private void DatabaseMenu_Load(object sender, System.EventArgs e)
        {
            PopulateUsers();
        }

        private void PopulateUsers()
        {
            using (connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM UserTable", connection))
            {
                DataTable usersTable = new DataTable();
                adapter.Fill(usersTable);

                UsersList.DisplayMember = "Name";
                UsersList.ValueMember = "Id";
                UsersList.DataSource = usersTable;
            }
        }

        private void PopulateData()
        {
            string query = "SELECT Name, Level FROM UserTable";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                //command.Parameters.AddWithValue("@UserId", UsersList.SelectedValue);

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                DataList.DisplayMember = "Name";
                DataList.DisplayMember += " Level";
                DataList.ValueMember = "Id";
                DataList.DataSource = dataTable;
            }
        }

        private void UsersList_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            PopulateData();
        }
    }
}

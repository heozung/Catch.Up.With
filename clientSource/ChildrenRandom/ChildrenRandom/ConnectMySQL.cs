using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Windows.Forms;
using System.Data;

    public class ConnectMySQL
    {
        private MySqlConnection connection;

        public ConnectMySQL()
        {
            Initialize();
        }

        private void Initialize()
        {
            string connectionString;
            connectionString = "Persist Security Info=False;Host=localhost;Database=vntalkin_testDB;user=root;password=;";
            connection = new MySqlConnection(connectionString);
        }
        // Mở kết nối
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Không thể kết nối tới Server. Xin liên hệ người quản trị");
                        break;

                    case 1045:
                        MessageBox.Show("Tên đăng nhập hoặc mật khẩu chưa chính xác, xin thử lại!");
                        break;
                }
                return false;
            }
        }

        //Đóng kết nối
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        //Insert statement
        public void ExecuteSQL(string strSQL)
        {
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(strSQL, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }

        public DataTable Select(string strSQL)
        {
            DataTable dt = new DataTable();
            if (this.OpenConnection() == true)
            {
                MySqlDataAdapter da = new MySqlDataAdapter(strSQL, connection);
                da.Fill(dt);
                this.CloseConnection();
                return dt;
            }
            else
            {
                return null;
            }
        }
}

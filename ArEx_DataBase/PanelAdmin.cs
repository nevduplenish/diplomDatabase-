using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ArEx_DataBase
{
    public partial class PanelAdmin : Form
    {
        DataBase dataBase = new DataBase();
        public PanelAdmin()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void CreateColumns()
        {
            dataGridView1.Columns.Add("id_user", "ID");
            dataGridView1.Columns.Add("Login", "Логин");
            dataGridView1.Columns.Add("Password", "Пароль");
            var checkColumn = new DataGridViewCheckBoxColumn();
            checkColumn.HeaderText = "IsAdmin";
            dataGridView1.Columns.Add(checkColumn);
        }

        private void ReadSingleRow(IDataRecord record)
        {
            dataGridView1.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetBoolean(3));
        }

        private void RefreshDataGrid()
        {
            dataGridView1.Rows.Clear();

            string queryString = $"select * from register";

            SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());

            dataBase.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(reader);
            }
            reader.Close();

            dataBase.closeConnection();
        }

        private void PanelAdmin_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefreshDataGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();

            for (int index = 0; index < dataGridView1.Rows.Count; index++)
            {
                var id = dataGridView1.Rows[index].Cells[0].Value.ToString();
                var isadmin = dataGridView1.Rows[index].Cells[3].Value.ToString();
                
                var changeQuery = $"UPDATE register SET is_admin = '{isadmin}' WHERE id_user = '{id}'";

                var command = new SqlCommand(changeQuery, dataBase.getConnection());
                command.ExecuteNonQuery();
            }

            dataBase.closeConnection();

            RefreshDataGrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();

            var selectedRowIndex = dataGridView1.CurrentCell.RowIndex;

            var id = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells[0].Value);

            var deleteQuery = $"DELETE FROM register WHERE id_user = {id}";

            var command = new SqlCommand(deleteQuery,dataBase.getConnection());
            command.ExecuteNonQuery();

            dataBase.closeConnection();

            RefreshDataGrid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
      
        }
    }
}

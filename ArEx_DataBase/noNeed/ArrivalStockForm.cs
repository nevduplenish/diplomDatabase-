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
    public partial class ArrivalStockForm : Form
    {
        DataBase dataBase = new DataBase();

        int selectedRow;

        public ArrivalStockForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

        }
        private void CreateColumns()
        {
            dataGridView1.Columns.Add("Ar_St_ID", "Ar_St_ID");
            dataGridView1.Columns.Add("Arrival_ID", "Arrival_ID");
            dataGridView1.Columns.Add("Stock_ID", "Stock_ID");
            dataGridView1.Columns.Add("IsNew", String.Empty);
        }

        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt64(0), record.GetInt64(1), record.GetInt64(2), RowState.ModifiedNew);
        }

        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string queryString = $"select * from Arrival_Stock";

            SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());

            dataBase.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dgw, reader);
            }
            reader.Close();
        }
        private void ArrivalStockForm_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefreshDataGrid(dataGridView1);
        }

        private void pictureBox_refresh_Click(object sender, EventArgs e)
        {
            RefreshDataGrid(dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddFormArSt frm_arst = new AddFormArSt();
            frm_arst.Show();
        }

        private void Search(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string searchString = $"select * from Arrival_Stock where concat (Ar_St_ID,Arrival_ID,Stock_ID) like '%" + textBox_search.Text + "%'";

            SqlCommand com = new SqlCommand(searchString, dataBase.getConnection());

            dataBase.openConnection();

            SqlDataReader read = com.ExecuteReader();

            while (read.Read())
            {
                ReadSingleRow(dgw, read);
            }

            read.Close();
        }
        private void deleteRow()
        {
            int index = dataGridView1.CurrentCell.RowIndex;

            dataGridView1.Rows[index].Visible = false;

            if (dataGridView1.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {
                dataGridView1.Rows[index].Cells[3].Value = RowState.Deleted;
                return;
            }

        }

        private void Update()
        {
            dataBase.openConnection();

            for (int index = 0; index < dataGridView1.Rows.Count; index++)
            {
                var rowState = (RowState)dataGridView1.Rows[index].Cells[3].Value;

                if (rowState == RowState.Existed)
                    continue;

                if (rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt64(dataGridView1.Rows[index].Cells[0].Value);
                    var deleteQuery = $"delete from Arrival_Stock where Ar_St_ID = {id}";

                    var command = new SqlCommand(deleteQuery, dataBase.getConnection());
                    command.ExecuteNonQuery();


                }
                if (rowState == RowState.Modified)
                {
                    var id = dataGridView1.Rows[index].Cells[0].Value.ToString();
                    var ar = dataGridView1.Rows[index].Cells[1].Value.ToString();
                    var st = dataGridView1.Rows[index].Cells[2].Value.ToString();

                    var changeQuery = $"update Arrival_Stock set Arrival_ID = '{ar}', Stock_ID = '{st}' where Ar_St_ID = '{id}'";

                    var command = new SqlCommand(changeQuery, dataBase.getConnection());
                    command.ExecuteNonQuery();
                }
            }
            dataBase.closeConnection();
        }

        private void textBox_search_TextChanged(object sender, EventArgs e)
        {
            Search(dataGridView1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            deleteRow();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Update();
        }

        private void Change()
        {
            var selectedRowIndex = dataGridView1.CurrentCell.RowIndex;

            var id = textBox_arst.Text;
            var ar = textBox_ar.Text;
            var st = textBox_st.Text;
          

            if (dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                    dataGridView1.Rows[selectedRowIndex].SetValues(id, ar, st);
                    dataGridView1.Rows[selectedRowIndex].Cells[3].Value = RowState.Modified;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Change();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];

                textBox_arst.Text = row.Cells[0].Value.ToString();
                textBox_ar.Text = row.Cells[1].Value.ToString();
                textBox_st.Text = row.Cells[2].Value.ToString();
            }
        }
    }
}

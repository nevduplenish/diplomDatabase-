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
    public partial class RecipeExpenseForm : Form
    {
        DataBase dataBase = new DataBase();

        int selectedRow;

        public RecipeExpenseForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

        }
        private void CreateColumns()
        {
            dataGridView1.Columns.Add("Re_Ex_ID", "Re_Ex_ID");
            dataGridView1.Columns.Add("Recipe_ID", "Recipe_ID");
            dataGridView1.Columns.Add("Expense_ID", "Expense_ID");
            dataGridView1.Columns.Add("IsNew", String.Empty);
        }

        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt64(0), record.GetInt64(1), record.GetInt64(2), RowState.ModifiedNew);
        }

        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string queryString = $"select * from Recipe_Expense";

            SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());

            dataBase.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dgw, reader);
            }
            reader.Close();
        }



        private void RecipeExpenseForm_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefreshDataGrid(dataGridView1);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];

                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                textBox3.Text = row.Cells[2].Value.ToString();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            RefreshDataGrid(dataGridView1);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddFormReEx addfrmreex = new AddFormReEx();
            addfrmreex.Show();
        }

        private void Search(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string searchString = $"select * from Recipe_Expense where concat (Re_Ex_ID,Recipe_ID,Expense_ID) like '%" + textBox_search.Text + "%'";

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
                    var deleteQuery = $"delete from Recipe_Expense where Re_Ex_ID = {id}";

                    var command = new SqlCommand(deleteQuery, dataBase.getConnection());
                    command.ExecuteNonQuery();


                }
                if (rowState == RowState.Modified)
                {
                    var id = dataGridView1.Rows[index].Cells[0].Value.ToString();
                    var re = dataGridView1.Rows[index].Cells[1].Value.ToString();
                    var ex = dataGridView1.Rows[index].Cells[2].Value.ToString();


                    var changeQuery = $"update Recipe_Expense set Recipe_ID = '{re}', Expense_ID = '{ex}' where Re_Ex_ID = '{id}'";

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

        private void Change()
        {
            var selectedRowIndex = dataGridView1.CurrentCell.RowIndex;

            var id = textBox1.Text;
            var re = textBox2.Text;
            var ex = textBox3.Text;

            if (dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                dataGridView1.Rows[selectedRowIndex].SetValues(id, re, ex);
                dataGridView1.Rows[selectedRowIndex].Cells[3].Value = RowState.Modified;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Change();
        }
    }
}

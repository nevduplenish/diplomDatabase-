﻿using System;
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
    public partial class StockForm : Form
    {
        DataBase dataBase = new DataBase();

        int selectedRow;
        public StockForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

        }

        private void CreateColumns()
        {
            dataGridView1.Columns.Add("Stock_ID", "ID");
            dataGridView1.Columns.Add("St_name_material", "Наименование материала");
            dataGridView1.Columns.Add("St_brand_material", "Марка материала");
            dataGridView1.Columns.Add("St_GOST", "ГОСТ материала");
            dataGridView1.Columns.Add("St_reserve_material", "Запас материала");
            dataGridView1.Columns.Add("IsNew", String.Empty);
        }
        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt64(0), record.GetString(1), record.GetString(2), record.GetString(3), record.GetInt32(4), RowState.ModifiedNew);
        }

        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string queryString = $"select * from Stock";

            SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());

            dataBase.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dgw, reader);
            }
            reader.Close();
        }

        private void StockForm_Load(object sender, EventArgs e)
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
            StockAddForm addfrm = new StockAddForm();
            addfrm.Show();
        }

        private void Search(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string searchString = $"select * from Stock where concat (Stock_ID,St_name_material,Ar_date,St_brand_material,St_GOST,St_reserve_material) like '%" + textBox_search.Text + "%'";

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
                dataGridView1.Rows[index].Cells[5].Value = RowState.Deleted;
                return;
            }

        }

        private void Update()
        {
            dataBase.openConnection();

            for (int index = 0; index < dataGridView1.Rows.Count; index++)
            {
                var rowState = (RowState)dataGridView1.Rows[index].Cells[7].Value;

                if (rowState == RowState.Existed)
                    continue;

                if (rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt64(dataGridView1.Rows[index].Cells[0].Value);
                    var deleteQuery = $"delete from Arrival where Arrival_ID = {id}";

                    var command = new SqlCommand(deleteQuery, dataBase.getConnection());
                    command.ExecuteNonQuery();


                }
                if (rowState == RowState.Modified)
                {
                    var id = dataGridView1.Rows[index].Cells[0].Value.ToString();
                    var namemat = dataGridView1.Rows[index].Cells[1].Value.ToString();
                    var brand = dataGridView1.Rows[index].Cells[2].Value.ToString();
                    var gost = dataGridView1.Rows[index].Cells[3].Value.ToString();
                    var reserve = dataGridView1.Rows[index].Cells[4].Value.ToString();

                    var changeQuery = $"update Stock set St_name_material = '{namemat}', St_brand_material = '{brand}', St_GOST ='{gost}', St_reserve_material ='{reserve}' where Stock_ID = '{id}'";

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

            var id = textBox_id.Text;
            var namemat = textBox_namemat.Text;
            var brand = textBox_brand.Text;
            var gost = textBox_gost.Text;
            int reserve;

            if (dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                if (int.TryParse(textBox_reserve.Text, out reserve))
                {
                    dataGridView1.Rows[selectedRowIndex].SetValues(id, namemat, brand, gost, reserve);
                    dataGridView1.Rows[selectedRowIndex].Cells[5].Value = RowState.Modified;
                }
                else
                {
                    MessageBox.Show("Запас материала должен иметь числовой формат!");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Change();
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];

                textBox_id.Text = row.Cells[0].Value.ToString();
                textBox_namemat.Text = row.Cells[1].Value.ToString();
                textBox_brand.Text = row.Cells[2].Value.ToString();
                textBox_gost.Text = row.Cells[3].Value.ToString();
                textBox_reserve.Text = row.Cells[4].Value.ToString();
            }
        }
    }
}

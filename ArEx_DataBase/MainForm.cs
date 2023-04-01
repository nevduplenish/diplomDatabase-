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
    public partial class MainForm : Form
    {
        

        DataBase database = new DataBase();
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ExpenseForm expensefrm = new ExpenseForm();
            expensefrm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RecipeForm recipefrm = new RecipeForm();
            recipefrm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            StockForm stockfrm = new StockForm();
            stockfrm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ArrivalStockForm arstfrm = new ArrivalStockForm();
            arstfrm.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            StockRecipeForm strefrm = new StockRecipeForm();
            strefrm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            RecipeExpenseForm reexfrm = new RecipeExpenseForm();
            reexfrm.Show();
        }
    }
}

using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ToDoList
{
    public partial class ToDoList : Form
    {
        public ToDoList()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")
            {
                MessageBox.Show("Tapşırığın adını daxil edin");
                return;
            }

            string tarix = dateTimePicker1.Value.ToString("dd.MM.yyyy");
            dataGridView1.Rows.Add(textBox1.Text, textBox2.Text, tarix, false);

            textBox1.Clear();
            textBox2.Clear();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 3)
            {
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);

                DialogResult cavab = MessageBox.Show("Bu tapşırığı silmək istəyirsiniz?", "Təsdiq", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (cavab == DialogResult.Yes)
                {
                    dataGridView1.Rows.RemoveAt(e.RowIndex);
                }
                else
                {
                    dataGridView1.Rows[e.RowIndex].Cells[3].Value = false;
                }
            }
        }
    }
}
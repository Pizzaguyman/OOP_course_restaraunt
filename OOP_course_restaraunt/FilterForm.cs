using OOP_course_restaraunt.DTO;
using OOP_course_restaraunt.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OOP_course_restaraunt
{
    public partial class FilterForm : Form
    {
        MenuRepository menuRepository;
        public event Action<List<DishDTO>>? FilterCompleted;
        public event Action? FilterStopped;
        static readonly string[] comboBox1Values = ["Название", "Описание", "Ингредиенты", "Цена приготовления", "Цена продажи"];
        public FilterForm(MenuRepository repo)
        {
            menuRepository = repo;
            InitializeComponent();
        }

        private void FilterForm_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = comboBox1Values;
            comboBox1.DisplayMember = "Value";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var menu = menuRepository.GetAll();
            List<DishDTO> filteredMenu = comboBox1.SelectedIndex switch
            {
                0 => menu.FindAll(d => (d._name ?? "").Contains(textBox1.Text)),
                1 => menu.FindAll(d => (d._description ?? "").Contains(textBox1.Text)),
                2 => menu.FindAll(d => string.Join(';', d._ingredients ?? []).Contains(textBox1.Text)),
                3 => menu.FindAll(d => d._prod_price == Double.Parse(textBox1.Text)),
                4 => menu.FindAll(d => d._sell_price == Double.Parse(textBox1.Text)),
                _ => []
            };
            FilterCompleted?.Invoke(filteredMenu);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "-";
            textBox1.Text = "";
            FilterStopped?.Invoke();
        }
    }
}

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
    /// <summary>
    /// Форма для фильтрации
    /// </summary>
    public partial class FilterForm : Form
    {
        MenuPresenter menuPresenter;
        public event Action<List<DishDTO>>? FilterCompleted;
        public event Action? FilterStopped;
        static readonly string[] comboBox1Values = ["Название", "Описание", "Ингредиенты", "Цена приготовления", "Цена продажи"];
        /// <summary>
        /// Создаёт форму для фильтрации
        /// </summary>
        /// <param name="repo">Объект сообщения с базой данных</param>
        public FilterForm(MenuPresenter repo)
        {
            menuPresenter = repo;
            InitializeComponent();
        }

        /// <summary>
        /// Инициализирует элементы формы
        /// </summary>
        /// <param name="sender">Отправитель</param>
        /// <param name="e">Параметры события</param>
        private void FilterForm_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = comboBox1Values;
            comboBox1.DisplayMember = "Value";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        /// <summary>
        /// Фильтрует блюда
        /// </summary>
        /// <param name="sender">Отправитель</param>
        /// <param name="e">Параметры события</param>
        private void button1_Click(object sender, EventArgs e)
        {
            var menu = menuPresenter.GetAll();
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

        /// <summary>
        /// СБрасывает фильтрацию блюд
        /// </summary>
        /// <param name="sender">Отправитель</param>
        /// <param name="e">Параметры события</param>
        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "-";
            textBox1.Text = "";
            FilterStopped?.Invoke();
        }
    }
}

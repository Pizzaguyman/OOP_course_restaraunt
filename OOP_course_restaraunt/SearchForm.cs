using OOP_course_restaraunt.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OOP_course_restaraunt
{
    /// <summary>
    /// Форма для поиска блюд
    /// </summary>
    public partial class SearchForm : Form
    {
        MenuPresenter menuPresenter;
        public event Action<int>? SearchCompleted;
        string previousSearch = "";
        int previousFindIndex = 0;
        static readonly string[] comboBox1Values = ["ID", "Название", "Описание", "Ингредиенты", "Цена приготовления", "Цена продажи"];

        /// <summary>
        /// СОздаёт форму для поиска блюд
        /// </summary>
        /// <param name="repo">Объект для сообщения с базой данных</param>
        public SearchForm(MenuPresenter repo)
        {
            menuPresenter = repo;
            InitializeComponent();
        }

        /// <summary>
        /// Инициализирует элементы формы
        /// </summary>
        /// <param name="sender">Отправитель</param>
        /// <param name="e">Параметры события</param>
        private void SearchForm_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = comboBox1Values;
            comboBox1.DisplayMember = "Value";
        }

        /// <summary>
        /// Ищет следующее блюдо, удовлетворяещее заданному фильтру
        /// </summary>
        /// <param name="sender">Отправитель</param>
        /// <param name="e">Параметры события</param>
        private void button1_Click(object sender, EventArgs e)
        {
            var menu = menuPresenter.GetAll();
            if (previousSearch != textBox1.Text) previousFindIndex = -1;
            previousFindIndex = comboBox1.SelectedIndex switch
            {
                0 => menu.FindIndex(previousFindIndex+1, d => d._id == Int32.Parse(textBox1.Text)),
                1 => menu.FindIndex(previousFindIndex+1, d => (d._name??"").Contains(textBox1.Text)),
                2 => menu.FindIndex(previousFindIndex+1, d => (d._description??"").Contains(textBox1.Text)),
                3 => menu.FindIndex(previousFindIndex+1, d => string.Join(';', d._ingredients ?? []).Contains(textBox1.Text)),
                4 => menu.FindIndex(previousFindIndex+1, d => d._prod_price == Double.Parse(textBox1.Text)),
                5 => menu.FindIndex(previousFindIndex+1, d => d._sell_price == Double.Parse(textBox1.Text)),
                _ => -2
            };
            if (previousFindIndex == -2)
            {
                return;
            }
            if (previousFindIndex == -1)
            {
                MessageBox.Show(
                "Больше блюд, удовлетворяющих данному условию, не было найдено",
                "Поиск завершен",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
                );
                return;
            }
            previousSearch = textBox1.Text;
            SearchCompleted?.Invoke(menu[previousFindIndex]._id);
        }
    }
}

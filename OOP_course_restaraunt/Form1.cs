using OOP_course_restaraunt.DTO;
using OOP_course_restaraunt.Repository;
using System.Data;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OOP_course_restaraunt
{
    /// <summary>
    /// Главная форма приложения
    /// </summary>
    public partial class Form1 : Form
    {
        MenuPresenter menuPresenter = new();
        SearchForm searchForm;
        FilterForm filterForm;
        bool IsFiltered
        {
            get; set
            {
                field = value;
                button1.Enabled = !value;
                button3.Enabled = !value;
            }
        } = false;

        bool UsingMarkup
        {
            get; set
            {
                field = value;
                inputSell.Enabled = !value;
                inputMarkup.Enabled = value;
            }
        } = false;
        bool IsEditing
        {
            get; set
            {
                field = value;
                addDishBtn.Enabled = !value;
                confirmEditBtn.Enabled = value;
                cancelEditBtn.Enabled = value;
            }
        } = false;
        int editedId = 0;

        /// <summary>
        /// Создаёт форму
        /// </summary>
        public Form1()
        {
            searchForm = new(menuPresenter);
            filterForm = new(menuPresenter);
            InitializeComponent();
        }

        /// <summary>
        /// Выбирает блюдо с определённым идентификатором
        /// </summary>
        /// <param name="id">Идентификатор</param>
        private void FocusIndex(int id)
        {
            Focus();
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Selected = false;
                if ((int)(dataGridView1.Rows[i].Cells[0].Value ?? 0) == id) dataGridView1.Rows[i].Selected = true;
            }

        }

        /// <summary>
        /// Обновляет таблицу отфильтрованного меню
        /// </summary>
        /// <param name="filteredMenu">Отфильтрованное меню</param>
        private void GridUpdateFilter(List<DishDTO> filteredMenu)
        {
            dataGridView1.RowCount = filteredMenu.Count;
            for (int i = 0; i < filteredMenu.Count; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = filteredMenu[i]._id;
                dataGridView1.Rows[i].Cells[1].Value = filteredMenu[i]._name;
                dataGridView1.Rows[i].Cells[2].Value = filteredMenu[i]._description;
                dataGridView1.Rows[i].Cells[3].Value = string.Join("; ", filteredMenu[i]._ingredients ?? []);
                dataGridView1.Rows[i].Cells[4].Value = filteredMenu[i]._prod_price;
                dataGridView1.Rows[i].Cells[5].Value = filteredMenu[i]._sell_price;
            }
            IsFiltered = true;
        }

        /// <summary>
        /// Инициализирует элементы формы
        /// </summary>
        /// <param name="sender">Отправитель</param>
        /// <param name="e">Параметры события</param>
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Курсовая работа по ООП. Медведев М. 24ВП1. База данных \"Меню\".",
                "Введение в приложение",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                GridUpdate();
                UsingMarkup = false;
                IsEditing = false;
            }
            catch (Npgsql.NpgsqlException ex)
            {
                MessageBox.Show("Не удалось соединиться с базой данных\n" + ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
                Close();
            }
        }

        /// <summary>
        /// Добавление нового блюда по нажатию кнопки
        /// </summary>
        /// <param name="sender">Отправитель</param>
        /// <param name="e">Параметры события</param>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var ingredients = inputIngr.Text.Split(";").ToList();
                for (int i = 0; i < ingredients.Count; i++) ingredients[i] = ingredients[i].Trim();
                menuPresenter.Add(new DishDTO(
                    inputName.Text,
                    inputDesc.Text,
                    ingredients,
                    (double)inputProd.Value,
                    UsingMarkup ? null : (double)inputSell.Value,
                    (double)inputMarkup.Value
                    ));
                GridUpdate();
                IsFiltered = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Обновляет таблицу блюд
        /// </summary>
        private void GridUpdate()
        {
            var menu = menuPresenter.GetAll();
            dataGridView1.RowCount = menu.Count;
            for (int i = 0; i < menu.Count; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = menu[i]._id;
                dataGridView1.Rows[i].Cells[1].Value = menu[i]._name;
                dataGridView1.Rows[i].Cells[2].Value = menu[i]._description;
                dataGridView1.Rows[i].Cells[3].Value = string.Join("; ", menu[i]._ingredients ?? []);
                dataGridView1.Rows[i].Cells[4].Value = menu[i]._prod_price;
                dataGridView1.Rows[i].Cells[5].Value = menu[i]._sell_price;
            }
            IsFiltered = false;
        }

        /// <summary>
        /// Обновляет таблицу блюд, отсортированную определённым способом
        /// </summary>
        private void GridUpdateSorted()
        {
            var menu = menuPresenter.sortedMenu;
            dataGridView1.RowCount = menu?.Count ?? 0;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = menu?[i]._id;
                dataGridView1.Rows[i].Cells[1].Value = menu?[i]._name;
                dataGridView1.Rows[i].Cells[2].Value = menu?[i]._description;
                dataGridView1.Rows[i].Cells[3].Value = string.Join("; ", menu?[i]._ingredients ?? []);
                dataGridView1.Rows[i].Cells[4].Value = menu?[i]._prod_price;
                dataGridView1.Rows[i].Cells[5].Value = menu?[i]._sell_price;
            }
        }

        /// <summary>
        /// Очищает базу данных
        /// </summary>
        /// <param name="sender">Отправитель</param>
        /// <param name="e">Параметры события</param>
        private void button4_Click(object sender, EventArgs e)
        {
            menuPresenter.Clear();
            GridUpdate();
            IsFiltered = false;
            IsEditing = false;
        }

        /// <summary>
        /// Изменяет или удаляет блюда в зависимости от нажатой кнопки в таблице
        /// </summary>
        /// <param name="sender">Отправитель</param>
        /// <param name="e">Параметры события</param>
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                IsEditing = true;
                editedId = (int)(dataGridView1.Rows[e.RowIndex].Cells[0].Value ?? 0);
                inputName.Text = (string)(dataGridView1.Rows[e.RowIndex].Cells[1].Value ?? "");
                inputDesc.Text = (string)(dataGridView1.Rows[e.RowIndex].Cells[2].Value ?? "");
                inputIngr.Text = ((string)(dataGridView1.Rows[e.RowIndex].Cells[3].Value ?? "")).Replace(";", ";");
                inputProd.Value = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells[4].Value ?? 0);
                inputSell.Value = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells[5].Value ?? 0);
            }
            if (e.ColumnIndex == 7)
            {
                menuPresenter.RemoveById((int)(dataGridView1.Rows[e.RowIndex].Cells[0].Value ?? 0));
                GridUpdate();
                IsFiltered = false;
            }
        }

        /// <summary>
        /// Подтверждает редактирование блюда
        /// </summary>
        /// <param name="sender">Отправитель</param>
        /// <param name="e">Параметры события</param>
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                var ingredients = inputIngr.Text.Split(";").ToList();
                for (int i = 0; i < ingredients.Count; i++) ingredients[i] = ingredients[i].Trim();
                menuPresenter.ChangeById(editedId, new DishDTO(
                    inputName.Text,
                    inputDesc.Text,
                    ingredients,
                    (double)inputProd.Value,
                    UsingMarkup ? null : (double)inputSell.Value,
                    (double)inputMarkup.Value
                ));
                IsEditing = false;
                GridUpdate();
                IsFiltered = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Открывает форму поиска
        /// </summary>
        /// <param name="sender">Отправитель</param>
        /// <param name="e">Параметры события</param>
        private void button2_Click(object sender, EventArgs e)
        {
            searchForm = new(menuPresenter);
            searchForm.SearchCompleted += FocusIndex;
            searchForm.Show();
        }

        /// <summary>
        /// Изменяет режим использования наценки
        /// </summary>
        /// <param name="sender">Отправитель</param>
        /// <param name="e">Параметры события</param>
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            UsingMarkup = checkBox1.Checked;
        }
        /// <summary>
        /// Отменяет редактирование
        /// </summary>
        /// <param name="sender">Отправитель</param>
        /// <param name="e">Параметры события</param>
        private void button6_Click(object sender, EventArgs e)
        {
            IsEditing = false;
        }

        /// <summary>
        /// Закрывает программу
        /// </summary>
        /// <param name="sender">Отправитель</param>
        /// <param name="e">Параметры события</param>
        private void button8_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Сохраняет базу данных в виде файла
        /// </summary>
        /// <param name="sender">Отправитель</param>
        /// <param name="e">Параметры события</param>
        private void button5_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "Табличные файлы(*.csv)|*.csv";
            saveFileDialog1.Title = "Сохраните ваш файл";
            saveFileDialog1.FileName = "MyTable.csv";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string savePath = saveFileDialog1.FileName;
                menuPresenter.SaveToCsv(savePath);
            }
        }

        /// <summary>
        /// Сортирует блюда по возрастанию
        /// </summary>
        /// <param name="sender">Отправитель</param>
        /// <param name="e">Параметры события</param>
        private void button1_Click_1(object sender, EventArgs e)
        {
            menuPresenter.Sort(comboBox1.SelectedIndex switch
            {
                0 => "name",
                1 => "description",
                2 => "cardinality(ingredients)",
                3 => "prod_price",
                4 => "sell_price",
                _ => ""
            });
            GridUpdateSorted();
        }

        /// <summary>
        /// Сортирует блюда по убыванию
        /// </summary>
        /// <param name="sender">Отправитель</param>
        /// <param name="e">Параметры события</param>
        private void button3_Click_1(object sender, EventArgs e)
        {
            menuPresenter.SortDesc(comboBox1.SelectedIndex switch
            {
                0 => "name",
                1 => "description",
                2 => "cardinality(ingredients)",
                3 => "prod_price",
                4 => "sell_price",
                _ => ""
            });
            GridUpdateSorted();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            filterForm = new(menuPresenter);
            filterForm.FilterCompleted += GridUpdateFilter;
            filterForm.FilterStopped += GridUpdate;
            filterForm.Show();
        }
    }
}
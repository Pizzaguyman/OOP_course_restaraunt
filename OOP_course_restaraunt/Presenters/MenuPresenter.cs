using Npgsql;
using NpgsqlTypes;
using OOP_course_restaraunt.DTO;
using System.Data;
using System.Text;

namespace OOP_course_restaraunt.Repository
{
    /// <summary>
    /// Класс, сообщающий приложение с базой данных
    /// </summary>
    public class MenuPresenter
    {
        const string CONNECTION_STRING = "Host=localhost;Database=postgres;Username=postgres;Password=mihandr";
        public List<DishDTO>? sortedMenu = null;

        /// <summary>
        /// Создаёт объект
        /// </summary>
        public MenuPresenter() { }

        /// <summary>
        /// Добавляет новое блюдо
        /// </summary>
        /// <param name="dto">Блюдо</param>
        /// <exception cref="ArgumentException">Исключение при повторении ингредиентов</exception>
        public void Add(DishDTO dto)
        {
            NpgsqlConnection con = new NpgsqlConnection(CONNECTION_STRING);
            foreach (string ing in dto._ingredients)
            {
                if (dto._ingredients.Count(x=>x==ing) > 1)
                {
                    throw new ArgumentException("Ингредиенты не должны повторяться");
                }
            }
            con.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("insert into menu (name, description, ingredients, prod_price, sell_price) " +
                "values (@name, @desc, @ingredients, @prodprice, @sellprice);", con);
            cmd.Parameters.Add("name", NpgsqlDbType.Text).Value = dto._name;
            cmd.Parameters.Add("desc", NpgsqlDbType.Text).Value = dto._description;
            cmd.Parameters.Add("ingredients", NpgsqlDbType.Array | NpgsqlDbType.Text).Value = dto._ingredients.ToArray();
            cmd.Parameters.Add("prodprice", NpgsqlDbType.Double).Value = dto._prod_price;
            cmd.Parameters.Add("sellprice", NpgsqlDbType.Double).Value = dto._sell_price;
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Получает все блюда
        /// </summary>
        /// <returns>Блюда</returns>
        public List<DishDTO> GetAll()
        {
            NpgsqlConnection con = new NpgsqlConnection(CONNECTION_STRING);
            List<DishDTO> result = new();
            con.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("select * from menu", con);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                DishDTO dto = new(reader.GetString(1), reader.GetString(2), reader.GetFieldValue<string[]>(3).ToList(), 
                    reader.GetDouble(4), reader.GetDouble(5));
                dto._id = reader.GetInt32(0);
                result.Add(dto);
            }
            return result;
        }

        /// <summary>
        /// Удаляет блюдо по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        public void RemoveById(int id)
        {
            NpgsqlConnection con = new NpgsqlConnection(CONNECTION_STRING);
            con.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("DELETE FROM menu WHERE id = @id;" +
                "SELECT setval(pg_get_serial_sequence('menu', 'id'), coalesce((select max(id)+1 from menu), 1), false);", con);
            cmd.Parameters.AddWithValue("id", id);
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Очищает базу данных
        /// </summary>
        public void Clear()
        {
            NpgsqlConnection con = new NpgsqlConnection(CONNECTION_STRING);
            con.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("DELETE FROM menu;" +
                "SELECT setval(pg_get_serial_sequence('menu', 'id'), 1, false);", con);
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Изменяет блюдо по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="dto">Новые данные блюда</param>
        /// <exception cref="ArgumentException">Исключение при повторении ингредиентов</exception>
        public void ChangeById(int id, DishDTO dto)
        {
            NpgsqlConnection con = new NpgsqlConnection(CONNECTION_STRING);
            foreach (string ing in dto._ingredients)
            {
                if (dto._ingredients.Count(x => x == ing) > 1)
                {
                    throw new ArgumentException("Ингредиенты не должны повторяться");
                }
            }
            con.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("update menu set name = @name, description = @desc, ingredients = @ing, " +
                "prod_price = @prod, sell_price = @sell where id = @id", con);
            cmd.Parameters.Add("id",NpgsqlDbType.Integer).Value = id;
            cmd.Parameters.Add("name", NpgsqlDbType.Text).Value = dto._name;
            cmd.Parameters.Add("desc", NpgsqlDbType.Text).Value = dto._description;
            cmd.Parameters.Add("ing", NpgsqlDbType.Array | NpgsqlDbType.Text).Value = dto._ingredients.ToArray();
            cmd.Parameters.Add("prod", NpgsqlDbType.Double).Value = dto._prod_price;
            cmd.Parameters.Add("sell", NpgsqlDbType.Double).Value = dto._sell_price;
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Сохраняет базу данных в виде файла
        /// </summary>
        /// <param name="filePath">Путь к файлу</param>
        public void SaveToCsv(string filePath)
        {
            NpgsqlConnection con = new NpgsqlConnection(CONNECTION_STRING);
            con.Open();
            // Получаем данные в DataTable
            var writer = con.BeginTextExport("COPY (SELECT * FROM menu) TO STDOUT WITH (FORMAT CSV, HEADER, DELIMITER ',')");
            using (var fileStream = new StreamWriter(filePath))
            {
                string? line;
                while ((line = writer.ReadLine()) != null)
                {
                    fileStream.WriteLine(line);
                }
            }
        }

        /// <summary>
        /// Сортирует базу данных по возастанию
        /// </summary>
        /// <param name="field">Поле-аргумент для сортировки</param>
        public void Sort(string field)
        {
            List<DishDTO> result = new();
            NpgsqlConnection con = new NpgsqlConnection(CONNECTION_STRING);
            con.Open();
            var cmd = new NpgsqlCommand($"select * from menu order by {field} asc", con);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                DishDTO dto = new(reader.GetString(1), reader.GetString(2), reader.GetFieldValue<string[]>(3).ToList(),
                    reader.GetDouble(4), reader.GetDouble(5));
                dto._id = reader.GetInt32(0);
                result.Add(dto);
            }
            sortedMenu = result;
        }

        /// <summary>
        /// Сортирует базу данных по убыванию
        /// </summary>
        /// <param name="field">Поле-аргумент для сортировки</param>
        public void SortDesc(string field)
        {
            List<DishDTO> result = new();
            NpgsqlConnection con = new NpgsqlConnection(CONNECTION_STRING);
            con.Open();
            var cmd = new NpgsqlCommand($"select * from menu order by {field} desc", con);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                DishDTO dto = new(reader.GetString(1), reader.GetString(2), reader.GetFieldValue<string[]>(3).ToList(),
                    reader.GetDouble(4), reader.GetDouble(5));
                dto._id = reader.GetInt32(0);
                result.Add(dto);
            }
            sortedMenu = result;
        }
    }
}

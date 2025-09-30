using Microsoft.Data.Sqlite;
using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace AndreaProyectoWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CargarIdsProductos();
            CargarCategorias();
        }

        public void CargarIdsProductos()
        {
            cbProductos.Items.Clear(); // limpiar combo
            string connectionString = "Data Source=tienda.sqlite3";

            using var connection = new SqliteConnection(connectionString);
            connection.Open();

            string query = "SELECT Id_producto FROM Producto";
            using var command = new SqliteCommand(query, connection);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                cbProductos.Items.Add(reader.GetInt32(0));
            }
        }

        private void cbProductos_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (cbProductos.SelectedItem == null) return;

            try
            {
                string connectionString = "Data Source=tienda.sqlite3";
                using var connection = new SqliteConnection(connectionString);
                connection.Open();

                string query = "SELECT * FROM Producto WHERE Id_producto=@id";
                using var command = new SqliteCommand(query, connection);
                command.Parameters.AddWithValue("@id", cbProductos.SelectedItem);

                using var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    txtId.Text = reader.GetInt32(0).ToString();
                    txtNombre.Text = reader.IsDBNull(1) ? "" : reader.GetString(1);
                    txtPrecio.Text = reader.IsDBNull(2) ? "" : reader.GetDouble(2).ToString("N2");
                    txtStock.Text = reader.IsDBNull(3) ? "" : reader.GetInt32(3).ToString();
                    txtFecha.Text = reader.IsDBNull(4) ? "" : reader.GetString(4);
                    cbDisponible.SelectedItem = reader.IsDBNull(5) ? null : (reader.GetBoolean(5) ? "Sí" : "No");
                    cbCategoria.SelectedItem = reader.IsDBNull(6) ? null : reader.GetString(6);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el producto:\n" + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }





        private void btnInsertar_Click(object sender, RoutedEventArgs e)
        {
            // Validar campos (ahora comprobamos cbCategoria)
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtPrecio.Text) ||
                string.IsNullOrWhiteSpace(txtStock.Text) ||
                string.IsNullOrWhiteSpace(txtFecha.Text) ||
                cbDisponible.SelectedItem == null ||
                cbCategoria.SelectedItem == null)
            {
                MessageBox.Show("Todos los campos deben estar completos.", "Advertencia",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Parsear precio y stock
            if (!double.TryParse(txtPrecio.Text, out double precio) ||
                !int.TryParse(txtStock.Text, out int stock))
            {
                MessageBox.Show("Precio o Stock no son valores válidos.", "Error",
                                MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            bool disponible = (cbDisponible.SelectedItem?.ToString() ?? "") == "Sí";
            string categoria = cbCategoria.SelectedItem?.ToString() ?? "";

            try
            {
                string connectionString = "Data Source=tienda.sqlite3";
                using var connection = new SqliteConnection(connectionString);
                connection.Open();

                string query = @"INSERT INTO Producto 
                         (Nombre, Precio, Stock, Fecha_creacion, Disponible, Categoria) 
                         VALUES (@nombre, @precio, @stock, @fecha, @disponible, @categoria)";

                using var command = new SqliteCommand(query, connection);
                command.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                command.Parameters.AddWithValue("@precio", precio);
                command.Parameters.AddWithValue("@stock", stock);
                command.Parameters.AddWithValue("@fecha", txtFecha.Text.Trim());
                // SQLite guarda 0/1; si tu columna es INTEGER, usa 0/1
                command.Parameters.AddWithValue("@disponible", disponible ? 1 : 0);
                command.Parameters.AddWithValue("@categoria", categoria.Trim());

                int rows = command.ExecuteNonQuery();

                if (rows > 0)
                {
                    MessageBox.Show("Producto insertado correctamente.",
                                    "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                    CargarIdsProductos();
                    CargarCategorias(); // opcional: refrescar lista de categorías si permites añadir nuevas
                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al insertar producto:\n{ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Seleccione un producto para actualizar.", "Advertencia",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!double.TryParse(txtPrecio.Text, out double precio) ||
                !int.TryParse(txtStock.Text, out int stock))
            {
                MessageBox.Show("Precio o Stock no son válidos.", "Error",
                                MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            bool disponible = cbDisponible.SelectedItem != null && cbDisponible.SelectedItem.ToString() == "Sí";

            string connectionString = "Data Source=tienda.sqlite3";
            using var connection = new SqliteConnection(connectionString);
            connection.Open();

            string query = @"UPDATE Producto SET 
                                Nombre=@nombre, Precio=@precio, Stock=@stock, 
                                Fecha_creacion=@fecha, Disponible=@disponible, Categoria=@categoria 
                             WHERE Id_producto=@id";

            using var command = new SqliteCommand(query, connection);
            command.Parameters.AddWithValue("@id", int.Parse(txtId.Text));
            command.Parameters.AddWithValue("@nombre", txtNombre.Text);
            command.Parameters.AddWithValue("@precio", precio);
            command.Parameters.AddWithValue("@stock", stock);
            command.Parameters.AddWithValue("@fecha", txtFecha.Text);
            command.Parameters.AddWithValue("@disponible", disponible);
            command.Parameters.AddWithValue("@categoria", cbCategoria.SelectedItem?.ToString());

            int rows = command.ExecuteNonQuery();

            if (rows > 0)
            {
                MessageBox.Show("Producto actualizado correctamente.",
                                "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                CargarIdsProductos();
            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Seleccione un producto para eliminar.", "Advertencia",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string connectionString = "Data Source=tienda.sqlite3";
            using var connection = new SqliteConnection(connectionString);
            connection.Open();

            string query = "DELETE FROM Producto WHERE Id_producto=@id";
            using var command = new SqliteCommand(query, connection);
            command.Parameters.AddWithValue("@id", int.Parse(txtId.Text));

            int rows = command.ExecuteNonQuery();

            if (rows > 0)
            {
                MessageBox.Show("Producto eliminado correctamente.",
                                "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                CargarIdsProductos();
                LimpiarCampos();
            }
        }
        private void CargarCategorias()
        {
            cbCategoria.Items.Clear();
            string connectionString = "Data Source=tienda.sqlite3";

            using var connection = new SqliteConnection(connectionString);
            connection.Open();

            string query = "SELECT DISTINCT Categoria FROM Producto";
            using var command = new SqliteCommand(query, connection);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                cbCategoria.Items.Add(reader.GetString(0));
            }
        }


        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtId.Text = "";
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtStock.Text = "";
            txtFecha.Text = "";
            cbDisponible.SelectedItem = null;
            cbCategoria.SelectedItem = null;
            cbProductos.SelectedItem = null;
        }
    }
}

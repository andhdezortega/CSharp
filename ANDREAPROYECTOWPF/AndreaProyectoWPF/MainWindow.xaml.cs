using Microsoft.Data.Sqlite;
using System;
using System.Windows;

namespace AndreaProyectoWPF;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        CargarIdsProductos();
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
            txtNombre.Text = reader.GetString(1);
            txtPrecio.Text = reader.GetDouble(2).ToString("N2");
            txtStock.Text = reader.GetInt32(3).ToString();
            txtFecha.Text = reader.GetString(4);
            txtDisponible.Text = reader.GetBoolean(5) ? "Sí" : "No";
            txtCategoria.Text = reader.GetString(6);
        }
    }

    private void btnInsertar_Click(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
            string.IsNullOrWhiteSpace(txtPrecio.Text) ||
            string.IsNullOrWhiteSpace(txtStock.Text) ||
            string.IsNullOrWhiteSpace(txtFecha.Text) ||
            string.IsNullOrWhiteSpace(txtDisponible.Text) ||
            string.IsNullOrWhiteSpace(txtCategoria.Text))
        {
            MessageBox.Show("Todos los campos deben estar completos.", "Advertencia",
                            MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        if (!double.TryParse(txtPrecio.Text, out double precio) ||
            !int.TryParse(txtStock.Text, out int stock))
        {
            MessageBox.Show("Precio o Stock no son valores válidos.", "Error",
                            MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        bool disponible = txtDisponible.Text.ToLower() == "sí" || txtDisponible.Text.ToLower() == "si";

        string connectionString = "Data Source=tienda.sqlite3";
        using var connection = new SqliteConnection(connectionString);
        connection.Open();

        string query = @"INSERT INTO Producto 
                         (Nombre, Precio, Stock, Fecha_creacion, Disponible, Categoria) 
                         VALUES (@nombre, @precio, @stock, @fecha, @disponible, @categoria)";

        using var command = new SqliteCommand(query, connection);
        command.Parameters.AddWithValue("@nombre", txtNombre.Text);
        command.Parameters.AddWithValue("@precio", precio);
        command.Parameters.AddWithValue("@stock", stock);
        command.Parameters.AddWithValue("@fecha", txtFecha.Text);
        command.Parameters.AddWithValue("@disponible", disponible);
        command.Parameters.AddWithValue("@categoria", txtCategoria.Text);

        int rows = command.ExecuteNonQuery();

        if (rows > 0)
        {
            MessageBox.Show("Producto insertado correctamente.",
                            "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
            CargarIdsProductos();
            LimpiarCampos();
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

        bool disponible = txtDisponible.Text.ToLower() == "sí" || txtDisponible.Text.ToLower() == "si";

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
        command.Parameters.AddWithValue("@categoria", txtCategoria.Text);

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
        txtDisponible.Text = "";
        txtCategoria.Text = "";
        cbProductos.SelectedItem = null;
    }




}
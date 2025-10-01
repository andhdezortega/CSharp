using Microsoft.Data.Sqlite;
using System;
using System.Windows;
using System.Windows.Controls;
using System.IO;

namespace BibliotecaWPF
{
    public partial class MainWindow : Window
    {
        string connectionString = "Data Source=biblioteca.sqlite";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                EnsureDatabase();
                CargarIdsLibros();
                CargarGeneros();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inicializando la base de datos: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EnsureDatabase()
        {
            using var connection = new SqliteConnection(connectionString);
            connection.Open();

            using (var cmd = connection.CreateCommand())
            {
                cmd.CommandText = @"CREATE TABLE IF NOT EXISTS Libro (
                    IdLibro INTEGER PRIMARY KEY AUTOINCREMENT,
                    Titulo TEXT NOT NULL,
                    Autor TEXT NOT NULL,
                    Anio INTEGER NOT NULL,
                    Genero TEXT NOT NULL
                );";
                cmd.ExecuteNonQuery();
            }

            // Seed from SQL file if table is empty
            long count;
            using (var countCmd = connection.CreateCommand())
            {
                countCmd.CommandText = "SELECT COUNT(1) FROM Libro";
                count = (long)countCmd.ExecuteScalar();
            }

            if (count == 0)
            {
                var baseDir = AppContext.BaseDirectory;
                var projectDir = Environment.CurrentDirectory;
                var sqlPath = Path.Combine(baseDir, "biblioteca.sql");
                if (!File.Exists(sqlPath))
                {
                    sqlPath = Path.Combine(projectDir, "biblioteca.sql");
                }

                if (File.Exists(sqlPath))
                {
                    var script = File.ReadAllText(sqlPath);
                    using var seedCmd = connection.CreateCommand();
                    seedCmd.CommandText = script;
                    seedCmd.ExecuteNonQuery();
                }
            }
        }

        private void CargarIdsLibros()
        {
            cbLibros.Items.Clear();
            using var connection = new SqliteConnection(connectionString);
            connection.Open();
            string query = "SELECT IdLibro FROM Libro";
            using var command = new SqliteCommand(query, connection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                cbLibros.Items.Add(reader.GetInt32(0));
            }
        }

        private void CargarGeneros()
        {
            cbGenero.Items.Clear();
            using var connection = new SqliteConnection(connectionString);
            connection.Open();
            string query = "SELECT DISTINCT Genero FROM Libro";
            using var command = new SqliteCommand(query, connection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                cbGenero.Items.Add(reader.GetString(0));
            }
        }

        private void cbLibros_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbLibros.SelectedItem == null) return;

            using var connection = new SqliteConnection(connectionString);
            connection.Open();
            string query = "SELECT * FROM Libro WHERE IdLibro = @id";
            using var command = new SqliteCommand(query, connection);
            command.Parameters.AddWithValue("@id", cbLibros.SelectedItem);
            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                txtId.Text = reader.GetInt32(0).ToString();
                txtTitulo.Text = reader.GetString(1);
                txtAutor.Text = reader.GetString(2);
                txtAnio.Text = reader.GetInt32(3).ToString();
                cbGenero.SelectedItem = reader.GetString(4);
            }
        }

        private void btnInsertar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitulo.Text) || string.IsNullOrWhiteSpace(txtAutor.Text) ||
                !int.TryParse(txtAnio.Text, out int anio) || cbGenero.SelectedItem == null)
            {
                MessageBox.Show("Completa todos los campos correctamente.");
                return;
            }

            using var connection = new SqliteConnection(connectionString);
            connection.Open();
            string query = "INSERT INTO Libro (Titulo, Autor, Anio, Genero) VALUES (@t, @a, @y, @g)";
            using var command = new SqliteCommand(query, connection);
            command.Parameters.AddWithValue("@t", txtTitulo.Text);
            command.Parameters.AddWithValue("@a", txtAutor.Text);
            command.Parameters.AddWithValue("@y", anio);
            command.Parameters.AddWithValue("@g", cbGenero.SelectedItem.ToString());
            command.ExecuteNonQuery();

            MessageBox.Show("Libro insertado correctamente.");
            CargarIdsLibros();
            LimpiarCampos();
        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id) ||
                string.IsNullOrWhiteSpace(txtTitulo.Text) || string.IsNullOrWhiteSpace(txtAutor.Text) ||
                !int.TryParse(txtAnio.Text, out int anio) || cbGenero.SelectedItem == null)
            {
                MessageBox.Show("Selecciona un libro y completa todos los campos.");
                return;
            }

            using var connection = new SqliteConnection(connectionString);
            connection.Open();
            string query = "UPDATE Libro SET Titulo=@t, Autor=@a, Anio=@y, Genero=@g WHERE IdLibro=@id";
            using var command = new SqliteCommand(query, connection);
            command.Parameters.AddWithValue("@t", txtTitulo.Text);
            command.Parameters.AddWithValue("@a", txtAutor.Text);
            command.Parameters.AddWithValue("@y", anio);
            command.Parameters.AddWithValue("@g", cbGenero.SelectedItem.ToString());
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();

            MessageBox.Show("Libro actualizado.");
            CargarIdsLibros();
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id))
            {
                MessageBox.Show("Selecciona un libro para eliminar.");
                return;
            }

            using var connection = new SqliteConnection(connectionString);
            connection.Open();
            string query = "DELETE FROM Libro WHERE IdLibro=@id";
            using var command = new SqliteCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();

            MessageBox.Show("Libro eliminado.");
            CargarIdsLibros();
            LimpiarCampos();
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtId.Text = "";
            txtTitulo.Text = "";
            txtAutor.Text = "";
            txtAnio.Text = "";
            cbGenero.SelectedItem = null;
            cbLibros.SelectedItem = null;
        }
    }
}

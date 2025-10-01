using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace BibliotecaWPF
{
    public partial class MainWindow : Window
    {
        string connectionString = "Data Source=biblioteca.sqlite3";

        public MainWindow()
        {
            InitializeComponent();
            CargarIdsLibros();
            CargarGeneros();
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

using Negocio;

namespace Escritorio
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool editar = false;
        private string idUsu = null;
        CN_Usuario CNUsuario = new CN_Usuario();

        private void mostrarUsuarios()
        {
            try
            {
                dgvUsuarios.DataSource = CNUsuario.mostrarUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pueden mostrar los usuarios por " + ex);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mostrarUsuarios();
        }



        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (!editar)
            {
                try
                {
                    CNUsuario.insertarUsuario(txtName.Text, txtPass.Text);
                    mostrarUsuarios();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se puede insertar el usuario por " + ex);
                }
            }
            else
            {
                try
                {
                    CNUsuario.actualizarUsuario(txtName.Text, txtPass.Text, idUsu);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se puede actualizar el usuario por " + ex);
                }
                finally
                {
                    editar = false;
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                txtName.Text = dgvUsuarios.CurrentRow.Cells["nombreUsuario"].Value.ToString();
                txtPass.Text = dgvUsuarios.CurrentRow.Cells["clave"].Value.ToString();
                idUsu = dgvUsuarios.CurrentRow.Cells["id"].Value.ToString();
                editar = true;
            }
            else
            {
                MessageBox.Show("Selecciona una fila");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                DialogResult confirmacion = MessageBox.Show("¿Estas seguro?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmacion == DialogResult.Yes)
                {
                    try
                    {
                        idUsu = dgvUsuarios.CurrentRow.Cells["id"].Value.ToString();
                        CNUsuario.eliminarUsuario(idUsu);
                        MessageBox.Show("Usuario eliminado");
                        mostrarUsuarios();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se puede eliminar el usuario por " + ex);
                    }


                }
            }
            else
            {
                MessageBox.Show("Selecciona una fila");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Length > 0)
            {
                try
                {
                    dgvUsuarios.DataSource = CNUsuario.mostrarUsuario(txtName.Text);
                    if (dgvUsuarios.Rows.Count == 1)
                    {
                        MessageBox.Show("No hay usuarios con ese nombre de usuario");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se puede mostrar el usuario por " + ex);
                }
            }
            else
            {
                MessageBox.Show("Ingrese un nombre de usuario");
            }
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            mostrarUsuarios();
        }
    }
}
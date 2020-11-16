using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using LibreriaBD;

namespace GestionDeOperacionesTI
{
   public class ManejaEmpleado
    {
        public int GetID(string Email)
        {
            SqlConnection Connection = UsoBD.ConectaBD(Utileria.GetConnectionString());
            int ID = 0;

            if (Connection == null)
            {
                MessageBox.Show("ERROR DE CONEXIÓN CON LA BASE DE DATOS");

                foreach (SqlError E in UsoBD.ESalida.Errors)
                    MessageBox.Show(E.Message);
                return ID;
            }
            SqlDataReader Lector = null;

            string strComandoC = "SELECT ID FROM EMPLEADO WHERE Email LIKE '" + Email + "'";

            Lector = UsoBD.Consulta(strComandoC, Connection);
            if (Lector == null)
            {
                MessageBox.Show("ERROR AL HACER LA CONSULTA");
                foreach (SqlError E in UsoBD.ESalida.Errors)
                    MessageBox.Show(E.Message);

                Connection.Close();
                return ID;
            }
            if (Lector.HasRows)
            {
                while (Lector.Read())
                {
                    ID = Convert.ToInt32(Lector.GetValue(0).ToString());
                }
            }
            Connection.Close();
            return ID;
        }
        public string GetRol(int ID)
        {
            SqlConnection Connection = UsoBD.ConectaBD(Utileria.GetConnectionString());
            string Rol = "";

            if (Connection == null)
            {
                MessageBox.Show("ERROR DE CONEXIÓN CON LA BASE DE DATOS");

                foreach (SqlError E in UsoBD.ESalida.Errors)
                    MessageBox.Show(E.Message);
                return Rol;
            }
            SqlDataReader Lector = null;

            string strComandoC = "SELECT R.Nombre FROM EMPLEADO E INNER JOIN ROL R ON E.ID_Rol = R.ID WHERE E.ID ="+ID;

            Lector = UsoBD.Consulta(strComandoC, Connection);
            if (Lector == null)
            {
                MessageBox.Show("ERROR AL HACER LA CONSULTA");
                foreach (SqlError E in UsoBD.ESalida.Errors)
                    MessageBox.Show(E.Message);

                Connection.Close();
                return Rol;
            }
            if (Lector.HasRows)
            {
                while (Lector.Read())
                {
                    Rol = Lector.GetValue(0).ToString();
                }
            }
            Connection.Close();
            return Rol;
        }
        public bool UpdateCel(int ID, string Celular)
        {
            SqlConnection Connection = UsoBD.ConectaBD(Utileria.GetConnectionString());
            bool Band=false;

            if (Connection == null)
            {
                MessageBox.Show("ERROR DE CONEXIÓN CON LA BASE DE DATOS");

                foreach (SqlError E in UsoBD.ESalida.Errors)
                    MessageBox.Show(E.Message);
                return Band;
            }
            string strComando = "UPDATE EMPLEADO SET Celular=@Celular WHERE ID=@ID";

            SqlCommand Update = new SqlCommand(strComando, Connection);

            Update.Parameters.AddWithValue("@Celular", Celular);
            Update.Parameters.AddWithValue("@ID", ID);

            try
            {
                Update.ExecuteNonQuery();
            }
            catch (SqlException Ex)
            {
                foreach (SqlError item in Ex.Errors)
                    MessageBox.Show(item.Message);

                Connection.Close();
                return Band;
            }
            Connection.Close();
            MessageBox.Show("CAMPO 'NUMERO CELULAR' ACTUALIZADO EXITOSAMENTE", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return !Band;
        }
        public bool UpdateDir(int ID, string Dir)
        {
            SqlConnection Connection = UsoBD.ConectaBD(Utileria.GetConnectionString());
            bool Band = false;

            if (Connection == null)
            {
                MessageBox.Show("ERROR DE CONEXIÓN CON LA BASE DE DATOS");

                foreach (SqlError E in UsoBD.ESalida.Errors)
                    MessageBox.Show(E.Message);
                return Band;
            }
            string strComando = "UPDATE EMPLEADO SET Direccion=@Direccion WHERE ID=@ID";

            SqlCommand Update = new SqlCommand(strComando, Connection);

            Update.Parameters.AddWithValue("@Direccion", Dir);
            Update.Parameters.AddWithValue("@ID", ID);

            try
            {
                Update.ExecuteNonQuery();
            }
            catch (SqlException Ex)
            {
                foreach (SqlError item in Ex.Errors)
                    MessageBox.Show(item.Message);

                Connection.Close();
                return Band;
            }
            Connection.Close();
            MessageBox.Show("CAMPO 'DIRECCION' ACTUALIZADO EXITOSAMENTE", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return !Band;
        }
        public int GetIDRol(int ID)
        {
            SqlConnection Connection = UsoBD.ConectaBD(Utileria.GetConnectionString());
            int Rol = 0;

            if (Connection == null)
            {
                MessageBox.Show("ERROR DE CONEXIÓN CON LA BASE DE DATOS");

                foreach (SqlError E in UsoBD.ESalida.Errors)
                    MessageBox.Show(E.Message);
                return Rol;
            }
            SqlDataReader Lector = null;

            string strComandoC = "SELECT ID_Rol FROM EMPLEADO WHERE ID=" + ID;

            Lector = UsoBD.Consulta(strComandoC, Connection);
            if (Lector == null)
            {
                MessageBox.Show("ERROR AL HACER LA CONSULTA");
                foreach (SqlError E in UsoBD.ESalida.Errors)
                    MessageBox.Show(E.Message);

                Connection.Close();
                return Rol;
            }
            if (Lector.HasRows)
            {
                while (Lector.Read())
                {
                    Rol = Convert.ToInt32(Lector.GetValue(0).ToString());
                }
            }
            Connection.Close();
            return Rol;
        }
        public string GetCelular(int ID)
        {
            SqlConnection Connection = UsoBD.ConectaBD(Utileria.GetConnectionString());
            string Cel ="";

            if (Connection == null)
            {
                MessageBox.Show("ERROR DE CONEXIÓN CON LA BASE DE DATOS");

                foreach (SqlError E in UsoBD.ESalida.Errors)
                    MessageBox.Show(E.Message);
                return Cel;
            }
            SqlDataReader Lector = null;

            string strComandoC = "SELECT Celular FROM EMPLEADO WHERE ID=" + ID;

            Lector = UsoBD.Consulta(strComandoC, Connection);
            if (Lector == null)
            {
                MessageBox.Show("ERROR AL HACER LA CONSULTA");
                foreach (SqlError E in UsoBD.ESalida.Errors)
                    MessageBox.Show(E.Message);

                Connection.Close();
                return Cel;
            }
            if (Lector.HasRows)
            {
                while (Lector.Read())
                {
                    Cel = Lector.GetValue(0).ToString();
                }
            }
            Connection.Close();
            return Cel;
        }
        public string GetDir(int ID)
        {
            SqlConnection Connection = UsoBD.ConectaBD(Utileria.GetConnectionString());
            string Dir="";

            if (Connection == null)
            {
                MessageBox.Show("ERROR DE CONEXIÓN CON LA BASE DE DATOS");

                foreach (SqlError E in UsoBD.ESalida.Errors)
                    MessageBox.Show(E.Message);
                return Dir;
            }
            SqlDataReader Lector = null;

            string strComandoC = "SELECT Direccion FROM EMPLEADO WHERE ID=" + ID;

            Lector = UsoBD.Consulta(strComandoC, Connection);
            if (Lector == null)
            {
                MessageBox.Show("ERROR AL HACER LA CONSULTA");
                foreach (SqlError E in UsoBD.ESalida.Errors)
                    MessageBox.Show(E.Message);

                Connection.Close();
                return Dir;
            }
            if (Lector.HasRows)
            {
                while (Lector.Read())
                {
                    Dir = Lector.GetValue(0).ToString();
                }
            }
            Connection.Close();
            return Dir;
        }
    }
}

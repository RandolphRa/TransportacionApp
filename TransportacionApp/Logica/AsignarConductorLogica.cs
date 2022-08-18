using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportacionApp.Modelos;

namespace TransportacionApp.Logica
{
    public class AsignarConductorLogica
    {
        private static AsignarConductorLogica _instancia = null;

        //constructor
        public static AsignarConductorLogica Instancia
        {

            get
            {
                if (_instancia == null) _instancia = new AsignarConductorLogica();
                return _instancia;
            }
        }

        public List<Conductor> Listar(out string mensaje)
        {
            mensaje = string.Empty;
            List<Conductor> oLista = new List<Conductor>();

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    conexion.Open();
                    string query = "select IdCliente,NumeroDocumento,NombreCompleto from CLIENTE;";
                    SqlCommand cmd = new SqlCommand(query, conexion);
                    cmd.CommandType = System.Data.CommandType.Text;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oLista.Add(new Conductor()
                            {
                                id = int.Parse(dr["IdCliente"].ToString()),
                                Nombre = dr["NumeroDocumento"].ToString(),
                                Apellido = dr["NombreCompleto"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                oLista = new List<Conductor>();
                mensaje = ex.Message;
            }
            return oLista;
        }

        public int Existe(string numero, int defaultid, out string mensaje)
        {
            mensaje = string.Empty;
            int respuesta = 0;
            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    conexion.Open();
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select count(*)[resultado] from CLIENTE where upper(NumeroDocumento) = upper(@pnumero) and IdCliente != @defaultid");

                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.Parameters.Add(new SqlParameter("@pnumero", numero));
                    cmd.Parameters.Add(new SqlParameter("@defaultid", defaultid));
                    cmd.CommandType = System.Data.CommandType.Text;

                    respuesta = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    if (respuesta > 0)
                        mensaje = "El numero de documento ya existe";

                }
                catch (Exception ex)
                {
                    respuesta = 0;
                    mensaje = ex.Message;
                }

            }
            return respuesta;
        }


        public int Guardar(Conductor objeto, out string mensaje)
        {
            mensaje = string.Empty;
            int respuesta = 0;

            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                try
                {

                    conexion.Open();
                    StringBuilder query = new StringBuilder();

                    query.AppendLine("insert into CLIENTE(NumeroDocumento,NombreCompleto) values (@pnumero,@pnombre);");
                    query.AppendLine("select last_insert_rowid();");

                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    //cmd.Parameters.Add(new SqlParameter("@pnumero", objeto.NumeroDocumento));
                    //cmd.Parameters.Add(new SqlParameter("@pnombre", objeto.NombreCompleto));
                    cmd.CommandType = System.Data.CommandType.Text;

                    respuesta = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    if (respuesta < 1)
                        mensaje = "No se pudo registrar el cliente";
                }
                catch (Exception ex)
                {
                    respuesta = 0;
                    mensaje = ex.Message;
                }
            }

            return respuesta;
        }


        public int Editar(Conductor objeto, out string mensaje)
        {
            mensaje = string.Empty;
            int respuesta = 0;

            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    conexion.Open();
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("update CLIENTE set NumeroDocumento = @pnumero,NombreCompleto = @pnombre where IdCliente = @pidcliente");

                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    //cmd.Parameters.Add(new SqlParameter("@pidcliente", objeto.IdCliente));
                  
                    cmd.CommandType = System.Data.CommandType.Text;

                    respuesta = cmd.ExecuteNonQuery();
                    if (respuesta < 1)
                        mensaje = "No se pudo editar el cliente";
                }
                catch (Exception ex)
                {
                    respuesta = 0;
                    mensaje = ex.Message;
                }
            }

            return respuesta;
        }


        public int Eliminar(int id)
        {
            int respuesta = 0;
            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    conexion.Open();
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("delete from CLIENTE where IdCliente= @id;");
                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    cmd.CommandType = System.Data.CommandType.Text;
                    respuesta = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                respuesta = 0;
            }

            return respuesta;
        }







    }
}

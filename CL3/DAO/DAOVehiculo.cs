using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CL3.Entidades;
using CL3.Utils;


namespace CL3.DAO
{
    public class DAOVehiculo
    {
        public int Insertar(Vehiculo obj)
        {
            int resultado = -1;
            SqlConnection cn = new BDConexion().ObtenerConexion();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_VEHICULO_INSERTAR", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Placa", obj.Placa);
                cmd.Parameters.AddWithValue("@marca", obj.Marca);
                cmd.Parameters.AddWithValue("@modelo", obj.Modelo);
                cmd.Parameters.AddWithValue("@anioFabricacion", obj.AnioFabricacion);
                cmd.Parameters.AddWithValue("@certificado", obj.Certificado);
                cmd.Parameters.AddWithValue("@pesoMaximo", obj.PesoMaximo);
                cmd.Parameters.AddWithValue("@volumenMaximo", obj.VolumenMaximo);
               
                cn.Open();
                resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception) { throw; }
            finally { cn.Close(); }
            return resultado;
        }

        public List<Vehiculo> Listar()
        {
            List<Vehiculo> lista = new List<Vehiculo>();
            SqlConnection cn = new BDConexion().ObtenerConexion();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_LISTADO", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new Vehiculo()
                    {
                        IdVehiculo = dr.GetInt32(0),
                        Placa = dr.GetString(1),
                        Marca = dr.GetString(2),
                        Modelo = dr.GetString(3),
                        AnioFabricacion = dr.GetString(4),
                        Certificado = dr.GetString(5),
                        PesoMaximo = Convert.ToDecimal(dr.GetDecimal(6)),
                        VolumenMaximo = Convert.ToDecimal(dr.GetDecimal(7))
                    });
                }
            }
            catch (Exception) { throw; }
            finally { cn.Close(); }
            return lista;
        }

        public int Actualizar(Vehiculo v)
        {
            int resultado = -1;
            SqlConnection cn = new BDConexion().ObtenerConexion();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_ACTUALIZAR_VEHICULO", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@placa", v.Placa);
                cmd.Parameters.AddWithValue("@marca", v.Marca);
                cmd.Parameters.AddWithValue("@modelo", v.Modelo);
                cmd.Parameters.AddWithValue("@anioFabricacion", v.AnioFabricacion);
                cmd.Parameters.AddWithValue("@certificado", v.Certificado);
                cmd.Parameters.AddWithValue("@pesoMaximo", v.PesoMaximo);
                cmd.Parameters.AddWithValue("@volumenMaximo", v.VolumenMaximo);
                cmd.Parameters.AddWithValue("@id", v.IdVehiculo);
                cn.Open();
                resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception) { throw; }
            finally { cn.Close(); }
            return resultado;
        }

        public int Eliminar(Vehiculo v)
        {
            int resultado = -1;
            SqlConnection cn = new BDConexion().ObtenerConexion();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_VEHICULO_ELIMINAR", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", v.IdVehiculo);
                cn.Open();
                resultado = cmd.ExecuteNonQuery();
            }
            catch (Exception) { throw; }
            finally { cn.Close(); }
            return resultado;
        }

        public Vehiculo Obtener(int id)
        {
            Vehiculo p = new Vehiculo();
            SqlConnection cn = new BDConexion().ObtenerConexion();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_VEHICULO_OBTENER", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    p = new Vehiculo()
                    {
                        IdVehiculo = dr.GetInt32(0),
                        Placa = dr.GetString(1),
                        Marca = dr.GetString(2),
                        Modelo = dr.GetString(3),
                        AnioFabricacion = dr.GetString(4),
                        Certificado = dr.GetString(5),
                        PesoMaximo = Convert.ToDecimal(dr.GetDecimal(6)),
                        VolumenMaximo = Convert.ToDecimal(dr.GetDecimal(7))
                    };
                }
            }
            catch (Exception) { throw; }
            finally { cn.Close(); }
            return p;
        }

        public List<Vehiculo> ListarXAnio(string anioInicio, string anioFinal)
        {
            List<Vehiculo> lista = new List<Vehiculo>();
            SqlConnection cn = new BDConexion().ObtenerConexion();
            try
            {
                SqlCommand cmd = new SqlCommand("SP_LISTARVEHICULO_X_AÑOS", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AnioInicial", anioInicio);
                cmd.Parameters.AddWithValue("@AnioFinal", anioFinal);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new Vehiculo()
                    {
                        IdVehiculo = dr.GetInt32(0),
                        Placa = dr.GetString(1),
                        Marca = dr.GetString(2),
                        Modelo = dr.GetString(3),
                        AnioFabricacion = dr.GetString(4),
                        Certificado = dr.GetString(5),
                        PesoMaximo = Convert.ToDecimal(dr.GetDecimal(6)),
                        VolumenMaximo = Convert.ToDecimal(dr.GetDecimal(7))
                    });
                }
            }
            catch (Exception) { throw; }
            finally { cn.Close(); }
            return lista;
        }
    }
}

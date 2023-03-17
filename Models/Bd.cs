using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using Dapper;
using System.Linq;
namespace TP1Dai.Models;
public static class BD
{
    private static string _connectionString = @"Server=A-PHZ2-AMI-015; Database=TP1Dai;Trusted_Connection=True;";
    public static List<Pizza> GetPizzas(int ID)
    {
        List<Pizza> _ListaPizzas = new List<Pizza>();
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Pizza";
            _ListaPizzas = db.Query<Pizza>(sql).ToList();
        }
        return _ListaPizzas;
    }
    public static void InsertPizza(Pizza Pizza)
    {
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "INSERT INTO Pizza(NombreProducto,FotoProducto,IdTela,IdColor,FechaDeIngreso,CantidadDisponible,Peso) VALUES (@pNombreProducto,@pFotoProducto,@pIdTela,@pIdColor,@pFechaDeIngreso,@pCantidadDisponible,@pPeso)";
            db.Execute(sql, new { pNombre = Pizza.Nombre, pLibreGluten = Pizza.LibreGluten, pImporte = Pizza.Importe, pDescripcion = Pizza.Descripcion});
        }
    }
    public static int EliminarPizza(int ID)
    {
        int Reg = 0;
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "DELETE FROM Pizza WHERE ID = @pId";
            Reg = db.Execute(sql, new { pId = ID });
        }
        return Reg;
    }
    public static int UpdatePizza(int ID, int Importe)
    {
        int NuevoImporte = 0;
        using(SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "UPDATE Pizza SET Importe = (@pImporte) WHERE ID = @pId";
            NuevoImporte = db.Execute(sql, new{pId = ID, pImporte = Importe});
            return NuevoImporte;
        }
    }
    
}
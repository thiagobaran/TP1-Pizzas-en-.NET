using System;
namespace TP1Dai.Models
{
    public class Pizza
    {
        private int _ID;
        private string _Nombre; 
        private float _LibreGluten;
        private int _Importe; 
        private string _Descripcion; 

        public Pizza(int ID, string Nombre, float LibreGluten, int Importe, string Descripcion)
        {
            _ID = ID;
            _Nombre = Nombre; 
            _LibreGluten = LibreGluten;
            _Importe = Importe;
            _Descripcion = Descripcion;
        }
        public int ID
        {
            get{return _ID;}
            set{ID = value;}
        }
        public string Nombre
        {
            get{return _Nombre;}
            set{Nombre = value;}
        }
        public float LibreGluten
        {
            get{return _LibreGluten;}
            set{LibreGluten = value;}
        }
         public int Importe
        {
            get{return _Importe;}
            set{Importe = value;}
        }
          public string Descripcion
        {
            get{return _Descripcion;}
            set{Descripcion = value;}
        }


    }

}
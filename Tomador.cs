namespace AplicacionSeguros
{
    abstract class Tomador
    {
        protected Tomador(string p_nombre, string p_id, string p_telefono)
        {
            nombre = p_nombre;
            id = p_id;
            telefono = p_telefono;
        }
        protected string nombre { get; set; }
        protected string id { get; set; }
        protected string telefono { get; set; }

        public string ObtenerNombre() => nombre;
    }
}

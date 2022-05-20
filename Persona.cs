namespace AplicacionSeguros
{
    internal class Persona : Tomador
    {
        public Persona(string p_nombre, string p_nif, string p_fecha_nacimiento, string p_telefono) : base(p_nombre, p_nif, p_telefono)
        {
            fecha_nacimiento = p_fecha_nacimiento;
        }
        string fecha_nacimiento { get; set; }

        public string ObtenerNIF()
        {
            return id;
        }
    }
}

namespace AplicacionSeguros
{
    internal class Empresa : Tomador
    {
        public Empresa(string p_nombre, string p_cif, Persona p_responsable, string p_nif_responsable, string p_telefono) : base(p_nombre, p_cif, p_telefono)
        {
            responsable = p_responsable;
            nif_responsable = p_nif_responsable;
        }
        Persona responsable { get; set; }
        string nif_responsable { get; set; }

        
    }

}

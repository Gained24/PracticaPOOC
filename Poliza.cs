namespace AplicacionSeguros
{
    internal class Poliza
    {
        public Poliza(int p_nro_poliza, Persona p_datos_tomador, string p_fecha_efecto, string p_estado_poliza)
        {
            nro_poliza = p_nro_poliza;
            datos_tomador = p_datos_tomador;
            fecha_efecto = p_fecha_efecto;
            estado_poliza = p_estado_poliza;
        }
        public Poliza(int p_nro_poliza, Empresa p_datos_tomador, string p_fecha_efecto, string p_estado_poliza)
        {
            nro_poliza = p_nro_poliza;
            datos_tomador = p_datos_tomador;
            fecha_efecto = p_fecha_efecto;
            estado_poliza = p_estado_poliza;
        }
        int nro_poliza { get; set; }
        Tomador datos_tomador { get; set; }
        string fecha_efecto { get; set; }
        string estado_poliza { get; set; }

        public int ObtenerIdetificador() { return nro_poliza; }


    }
}

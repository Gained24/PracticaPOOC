namespace AplicacionSeguros
{
    internal class DatosSiniestro
    {
        public DatosSiniestro(int p_nro_siniestro, int p_nro_poliza, string p_cia_contraria, int p_nro_poliza_contrario, 
                              string p_matricula_contrario, int p_importe_siniestro, string p_fecha_pago, string p_fecha_liquidacion)
        {
            nro_siniestro = p_nro_siniestro;
            nro_poliza = p_nro_poliza;
            cia_contraria = p_cia_contraria;
            nro_poliza_contrario = p_nro_poliza_contrario;
            matricula_contrario = p_matricula_contrario;
            importe_siniestro = p_importe_siniestro;
            fecha_pago = p_fecha_pago;
            fecha_liquidacion = p_fecha_liquidacion;
        }
        int nro_siniestro { get; set; }
        int nro_poliza { get; set; }
        string cia_contraria { get; set; }
        int nro_poliza_contrario { get; set; }
        string matricula_contrario { get; set; }
        int importe_siniestro { get; set; }
        string fecha_pago { get; set; }
        string fecha_liquidacion { get; set; }
    }
}

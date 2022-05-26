namespace AplicacionSeguros
{
    internal class DatosSiniestro
    {
        public DatosSiniestro(string p_nro_siniestro, int p_nro_poliza, string p_cia_contraria, int p_nro_poliza_contrario, 
                              bool p_poliza_propia, string p_matricula_contrario)
        {
            nro_siniestro = p_nro_siniestro;
            nro_poliza = p_nro_poliza;
            cia_contraria = p_cia_contraria;
            nro_poliza_contrario = p_nro_poliza_contrario;
            poliza_propia = p_poliza_propia;
            matricula_contrario = p_matricula_contrario;
            importe_siniestro = 0;
            fecha_pago = "";
            fecha_liquidacion = "";
        }
        string nro_siniestro { get; set; }
        int nro_poliza { get; set; }
        string cia_contraria { get; set; }
        int nro_poliza_contrario { get; set; }
        bool poliza_propia { get; set; }
        string matricula_contrario { get; set; }
        int importe_siniestro { get; set; }
        string fecha_pago { get; set; }
        string fecha_liquidacion { get; set; }

        public void AgregarFechaPago(string p_fecha_pago)
        {
            fecha_pago = p_fecha_pago;
        }

        public void AgregarFechaLiquidacion(string p_fecha_liquidacion)
        {
            fecha_liquidacion = p_fecha_liquidacion;
        }

        public void AgregarImporteSiniestro(int p_importe)
        {
            importe_siniestro = p_importe;
        }

        public int NroPoliza() => nro_poliza;

        public string NroSiniestro() => nro_siniestro;

        public string ObtenerFechaLiquidacion() => fecha_liquidacion;

        public int Importe() => importe_siniestro;

        public string ObtenerFechaPago() => fecha_pago;
    }
}

namespace AplicacionSeguros
{
    internal class DatosRecibos
    {
        public DatosRecibos(int p_nro_poliza, int p_nro_recibo, string p_fecha_emision, int p_importe_seguro, int p_comision)
        {
            nro_poliza = p_nro_poliza;
            nro_recibo = p_nro_recibo;
            fecha_emision = p_fecha_emision;
            importe_seguro = p_importe_seguro;
            estado_recibo = "pendiente";
            comision = p_comision;
            fecha_liquidacion = "";
        }
        int nro_poliza { get; set; }
        int nro_recibo { get; set; }
        string fecha_emision { get; set; }
        int importe_seguro { get; set; }
        string estado_recibo { get; set; }
        int comision { get; set; }
        string fecha_liquidacion { get; set; }

        public void CambiarEstadoADevuelto()
        {
            estado_recibo = "devuelto";
        }
        public void CambiarEstadoACobrado()
        {
            estado_recibo = "cobrado";
        }

        public void AgregarFechaLiquidacion(string p_fecha_liquidacion)
        {
            fecha_liquidacion = p_fecha_liquidacion;
        }

        public int NroPoliza() => nro_poliza;

        public int NroRecibo() => nro_recibo;

        public int Importe() => importe_seguro;

        public string ObtenerEstado() => estado_recibo;

        public int Comision() => comision;

        public string ObtenerFechaLiquidacion() => fecha_liquidacion;

    }
}

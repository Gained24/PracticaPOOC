namespace AplicacionSeguros
{
    internal class DatosRecibos
    {
        public DatosRecibos(int p_nro_poliza, int p_nro_recibo, string p_fecha_emision, int p_importe_seguro, string p_estado_recibo, int p_comision, string p_fecha_liquidacion)
        {
            nro_poliza = p_nro_poliza;
            nro_recibo = p_nro_recibo;
            fecha_emision = p_fecha_emision;
            importe_seguro = p_importe_seguro;
            estado_recibo = p_estado_recibo;
            comision = p_comision;
            fecha_liquidacion = p_fecha_liquidacion;
        }
        int nro_poliza { get; set; }
        int nro_recibo { get; set; }
        string fecha_emision { get; set; }
        int importe_seguro { get; set; }
        string estado_recibo { get; set; }
        int comision { get; set; }
        string fecha_liquidacion { get; set; }

    }
}

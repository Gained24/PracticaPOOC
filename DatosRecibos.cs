﻿namespace AplicacionSeguros
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

        public void EsDevuelto()
        {
            estado_recibo = "devuelto";
        }

        public void AgregarFechaLiquidacion(string p_fecha_liquidacion)
        {
            fecha_liquidacion = p_fecha_liquidacion;
        }

    }
}

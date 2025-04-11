namespace prueba_base.Models
{
    public class OrdenCompraDetalle
    {

        public int id {  get; set; }
        public int? id_orden { get; set; }
        public int? id_item { get; set; }
        public int? id_solicitudDetalle { get; set; }
        public int? id_solicitud { get; set; }
        public int? id_unidadMedidaCompra { get; set; }
        public decimal? cantidadAComprar { get; set; }
        public decimal? cantidadAprobada { get; set; }
        public decimal? precioCompra { get; set; }
        public decimal? baseImponible { get; set; }
        public decimal? porcientoDescuento { get; set; }
        public decimal? valorDescuento { get; set; }
        public decimal? subTotalBruto { get; set; }
        public bool? iva { get; set; }
        public decimal? porcientoIva { get; set; }
        public decimal? valorIva { get; set; }
        public bool? ice { get; set; }
        public decimal? porcientoIce { get; set; }
        public decimal? valorIce { get; set; }
        public decimal? subTotalNeto { get; set; }
        public decimal? cantidadRecibida { get; set; }
        public decimal? cantidadPendiente { get; set; }
        public decimal? cantidadDespacho { get; set; }
        public decimal? pendienteDespacho { get; set; }
        public string? observacion { get; set; }
        public int? id_centroCosto { get; set; }
        public int? id_cargoOperacional { get; set; }
        public DateTime? fechaProduccion { get; set; }
        public string? fechaHoraProduccion { get; set; }
        public string? unidadProduccion { get; set; }
        public int? id_tipoProceso { get; set; }

    }
}

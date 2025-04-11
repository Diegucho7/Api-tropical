namespace prueba_base.Models
{
    public class Comprobante
    {
        public int id {  get; set; }
       public int id_puntoEmision { get; set; }
        public int? id_tipoComprobante { get; set; }
        public int? id_comprobanteOrigen { get; set; }
        public string? fechaCreacion { get; set; }
        public string? fechaEmision { get; set; }
        public DateTime? fechaEmisionDT { get; set; }
        public string? numeroSerie { get; set; }
        public int? secuencial { get; set; }
        public string? numeroComprobante { get; set; }
        public string? referencia { get; set; }
        public string? observacion { get; set; }
        public bool? generadoAutomatico { get; set; }
        public int? id_estado { get; set; }
        public int? id_estadoTransicion { get; set; }
        public int? id_usuarioCreacion { get; set; }
        public DateTime? AudCreaFecha { get; set; }
        public int? id_usuarioModificacion { get; set; }
        public DateTime? AudModificaFecha { get; set; }
        public int? id_usuarioAsentar { get; set; }
        public DateTime? AudAsentaFecha { get; set; }
        public int? id_usuarioReversar { get; set; }
        public DateTime? AudReverseFecha { get; set; }
        public int? id_usuarioAnular { get; set; }
        public DateTime? AudAnulaFecha { get; set; }
        public string? temperatura { get; set; }
        public string? id_rubro { get; set; }
    }
}

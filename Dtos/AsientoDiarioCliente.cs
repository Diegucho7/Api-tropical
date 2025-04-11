namespace prueba_base.Dtos
{
    public class AsientoDiarioCliente
    {
        public string? CodigoPrincipal { get; set; }
        public DateTime DFxRegistro { get; set; }
        public string? CDsObservacion { get; set; }
        public string? CCiUsuario { get; set; }
        public DateTime DFxUsuario { get; set; }
        public string? CSnTipo { get; set; } // char(1)
        public string? CodigoAnulacion { get; set; }
        public string? CDsMotivoAnulacion { get; set; }
        public string? CCiCuentaContable { get; set; }
        public string? CCiCentroCosto { get; set; }
        public string? CCiTipoPiscina { get; set; }
        public string? CNuPiscina { get; set; }
        public decimal NNuDebe { get; set; }
        public decimal NNuHaber { get; set; }
        public string? CDsDetalle { get; set; }
        public bool CCeProceso { get; set; }
        public string? CNoError { get; set; }
    }
}


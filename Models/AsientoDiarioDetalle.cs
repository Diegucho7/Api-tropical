using System.ComponentModel.DataAnnotations.Schema;

namespace prueba_base.Models
{
    [Table("AsientoDiarioDetalle")]
    public class AsientoDiarioDetalle
    {
        public int id { get; set; }
        public int? id_asientoDiario { get; set; }
        public int? id_cuenta { get; set; }
        public string? nombreCuenta { get; set; }

        public int? id_centroCosto { get; set; }

        public string? nombreCentroCosto { get; set; }

        public int? id_CargoOperacional { get; set; }
        public string? nombreCargoOperacional { get; set; }

        public decimal debito {  get; set; }
        public decimal credito { get; set; }
        public decimal saldoCuenta { get; set; }
        public string? referencia { get; set; }
        public string? descripcion { get; set; }
        public int? id_tipoRegistroContable { get; set; }




    }
}

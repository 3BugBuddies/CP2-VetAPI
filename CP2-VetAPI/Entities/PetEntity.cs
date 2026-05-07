using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CP2_VetApi.Models
{
    [Table("TB_PET")]
    public class PetEntity
    {
        [Key]
        [Column("id_pet")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório: Nome")]
        [Column("nm_nome")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório: Raça")]
        [Column("rc_raca")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "")]
        public string Raca { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório: Especie")]
        [Column("es_especie")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "")]
        public string Especie { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório: Idade")]
        [Column("i_idade")]
        public int Idade{ get; set; }
    }
}

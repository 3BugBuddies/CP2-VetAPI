using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CP_dotNet.Models
{
    public class PetEntity
    {
        [Key]
        [Column("id_pet")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório: Nome")]
        [Column("nm_pet")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório: Raça")]
        [Column("raca_pet")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "")]
        public string Raca { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório: Idade")]
        [Column("idade_pet")]
        public int Idade{ get; set; }
    }
}

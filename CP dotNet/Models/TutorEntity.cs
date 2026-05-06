using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CP_dotNet.Models
{
    [Table("tb_tutor")]
    public class TutorEntity
    {
        [Key]
        [Column("id_tutor")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório: Nome")]
        [Column("nm_tutor")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório: Email")]
        [Column("em_tutor")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "")]
        [EmailAddress(ErrorMessage = "Este campo deve ser um email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório: Telefone")]
        [Column("tl_tutor")]
        [StringLength(11, ErrorMessage = "")]
        public string Telefone { get; set; }

    }
}

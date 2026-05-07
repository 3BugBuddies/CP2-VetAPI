using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CP2_VetApi.Models
{
    [Table("TB_TUTOR")]
    public class TutorEntity
    {
        [Key]
        [Column("id_tutor")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório: Nome")]
        [Column("nm_nome")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório: Email")]
        [Column("em_email")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "")]
        [EmailAddress(ErrorMessage = "Este campo deve ser um email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório: Telefone")]
        [Column("tl_telefone")]
        [StringLength(20, ErrorMessage = "Telefone inválido")]
        public string Telefone { get; set; }

    }
}

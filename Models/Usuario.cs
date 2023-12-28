using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudMvc.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        [Display]
        [Column("Id")]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Column("Nome")]
        [Required (ErrorMessage = "Digite o Nome do usuario")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o Email do usuario")]
        [EmailAddress(ErrorMessage = "O Email informado não é valido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite o Celular do usuario")]
        [Phone(ErrorMessage = "O telefone informado não é valido")]
        public string Celular { get; set; }

    }
}

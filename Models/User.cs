using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CharacterSheet.Models
{
    [Table("lista_usuarios")]
    public class User
    {
        [Key]
        [Column("id")]
        public long Id {get; set; }
        [Column("username")]
        public string Username {get; set; }
        [Column("password")]
        public string Password {get; set; }
        [Column("role")]
        public string Role {get; set; }

    }
}
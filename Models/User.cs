using System.ComponentModel.DataAnnotations.Schema;

namespace CharacterSheet.Models
{
    [Table("lista_usuarios")]
    public class User
    {
        [Column("id")]
        public long Id {get; set; }
        [Column("username")]
        public string Username {get; set; }
        [Column("password")]
        public string Password {get; set; }
        [Column("Role")]
        public string Role {get; set; }

    }
}
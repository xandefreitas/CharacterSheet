using System.ComponentModel.DataAnnotations.Schema;

namespace CharacterSheet.Models
{
    [Table("lista_personagem")]
    public class Personagem
    {
                
        [Column("id")]
        public long Id {get; set; }
        [Column("nome")]
        public string Nome {get; set; }
        [Column("criador")]
        public string Criador {get; set; }
        [Column("raça")]
        public string Raça {get; set; }
        [Column("classe")]
        public string Classe {get; set; }
        [Column("historia")]
        public string Historia{get; set; }
    }
}
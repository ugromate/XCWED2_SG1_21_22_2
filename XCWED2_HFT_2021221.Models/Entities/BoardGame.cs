using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XCWED2_HFT_2021221.Models.Entities
{
    [Table("BoardGames")]
    public class BoardGame
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string Name { get; set; }


        public int MinPlayer { get; set; }

        public int MaxPlayer { get; set; }

        public int MinAge { get; set; }


        [MaxLength(25)]
        public string Artist { get; set; }

        public int Rating { get; set; }

        [Required]
        public int DesignerID { get; set; }

        [NotMapped]
        public virtual Designer Designer { get; set; }

        [Required]
        public int PublisherID { get; set; }
        [NotMapped]
        public virtual Publisher Publisher { get; set; }

    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XCWED2_HFT_2021221.Models.Entities
{
    [Table("Publishers")]

    public class Publisher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

        [MaxLength(25)]
        public string Country { get; set; }

        [NotMapped]
        public virtual ICollection<BoardGame> BoardGames { get; set; }
    }
}

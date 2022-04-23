using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace XCWED2_SG1_21_22_2.Models.Entities
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

        [JsonIgnore]
        [NotMapped]
        public virtual ICollection<BoardGame> BoardGames { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}\nCountry: {Country}\n";
        }

    }
}

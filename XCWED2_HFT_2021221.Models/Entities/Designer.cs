using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace XCWED2_HFT_2021221.Models.Entities
{
    [Table("Designers")]
    public class Designer
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Nationality { get; set; }

        [JsonIgnore]
        [NotMapped]
        public virtual ICollection<BoardGame> BoardGames { get; set; }
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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

        public double Rating { get; set; }

        public int PriceHUF { get; set; }


        public int DesignerID { get; set; }

        [NotMapped]
        public virtual Designer Designer { get; set; }

        public int PublisherID { get; set; }

        [NotMapped]
        public virtual Publisher Publisher { get; set; }


        public override string ToString()
        {
            return $"Name: {Name}\nPublisher: {Publisher.Name}\nDesigner: {Designer.Name}\nPlayers: {MinPlayer}-{MaxPlayer}\nMinAge: {MinAge}\nRating: {Rating}\nPriceHUF: {PriceHUF}\n";
        }

    }
}

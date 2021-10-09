using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XCWED2_HFT_2021221.Models.Entities
{
    [Table("Borrowers")]
    public class Borrower
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

        [Required]
        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(4)]
        public string PostCode { get; set; }

        [Required]
        [MaxLength(20)]
        public string City { get; set; }

        [Required]
        public string Adress { get; set; }

        [Required]
        public string EMailAdress { get; set; }

        [NotMapped]
        public virtual ICollection<BoardGame> BoardGames { get; set; }

    }
}

namespace XCWED2_SG1_21_22_2.Models.DTOs
{
    public class BoardGame
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public int MinPlayer { get; set; }

        public int MaxPlayer { get; set; }

        public int MinAge { get; set; }

        public double Rating { get; set; }

        public int PriceHUF { get; set; }

        public int DesignerID { get; set; }

        public int PublisherID { get; set; }
    }
}

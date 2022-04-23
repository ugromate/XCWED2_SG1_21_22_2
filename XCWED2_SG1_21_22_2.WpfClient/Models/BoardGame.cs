using GalaSoft.MvvmLight;

namespace XCWED2_SG1_21_22_2.WpfClient.Models
{
    public class BoardGame : ObservableObject
    {
        #region Properties
        private int id;

        public int Id
        {
            get { return id; }
            set { Set(ref id, value); }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { Set(ref name, value); }
        }

        private int priceHUF;

        public int PriceHUF
        {
            get { return priceHUF; }
            set { Set(ref priceHUF, value); }
        }

        private int minPlayer;

        public int MinPlayer
        {
            get { return minPlayer; }
            set { Set(ref minPlayer, value); }
        }

        private int maxPlayer;

        public int MaxPlayer
        {
            get { return maxPlayer; }
            set { Set(ref maxPlayer, value); }
        }

        private int minAge;

        public int MinAge
        {
            get { return minAge; }
            set { Set(ref minAge, value); }
        }

        private double rating;

        public double Rating
        {
            get { return rating; }
            set { Set(ref rating, value); }
        }

        private int designerID;

        public int DesignerID
        {
            get { return designerID; }
            set { Set(ref designerID, value); }
        }

        private int publisherID;

        public int PublisherID
        {
            get { return publisherID; }
            set { Set(ref publisherID, value); }
        }
        #endregion


    }
}

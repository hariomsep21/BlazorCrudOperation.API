namespace DemoCRUD.Model.Models
{
    public class Gender
    {
        public int GenderID { get; set; }
        public string GenderName { get; set; }

        // Navigation property
        public ICollection<Students> Students { get; set; }
    }
}

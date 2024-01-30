namespace DemoCRUD.Model.Models
{
    public class State
    {
        public int StateID { get; set; }
        public string StateName { get; set; }

        // Navigation property
        public ICollection<Students> Students { get; set; }
    }
}

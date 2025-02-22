namespace CategoryService.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<int> TaskIds { get; set; } = new();
    }
}

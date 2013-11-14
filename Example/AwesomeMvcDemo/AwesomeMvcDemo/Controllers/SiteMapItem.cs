namespace AwesomeMvcDemo.Controllers
{
    public class SiteMapItem
    {
        public string Title { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public int GroupId { get; set; }

        public string GroupTitle { get; set; }

        public bool HideFromMenu { get; set; }
    }
}
using System.Collections.Generic;
using DataLayer.Model;

namespace Website.Models.Admin
{
    public class StoryViewModel : CommonViewModel
    {
        public StoryViewModel() : base()
        {
            
        }
        
        public string ID { get; set; }
        public string Message { get; set; }
        public List<Story> Stories { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
    }
}
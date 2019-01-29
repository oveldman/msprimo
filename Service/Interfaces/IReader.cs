using System.Collections.Generic;
using DataLayer.Model;

namespace Service.Interfaces
{
    public interface IReader
    {
        Story GetStory(string id);
        List<Story> GetStories(int page);
        int GetTotalPages();
    }
}
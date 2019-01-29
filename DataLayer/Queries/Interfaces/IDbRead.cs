using System.Collections.Generic;
using DataLayer.Model;

namespace DataLayer.Queries.Interfaces
{
    public interface IDbRead
    {
        Story GetStory(string id);
        List<Story> GetStories(int firstItem, int listLength);
        int GetTotalStories();
    }
}
using DataLayer.Model;

namespace DataLayer.Queries.Interfaces
{
    public interface IDbWrite
    {
        MSPResult SaveStory(Story story);
        MSPResult EditStory(Story story);
        MSPResult DeleteStory(string id);
    }
}
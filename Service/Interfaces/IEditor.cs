using DataLayer;
using DataLayer.Model;

namespace Service.Interfaces
{
    public interface IEditor
    {
        MSPResult SaveNewStory(string message);
        MSPResult EditStory(Story story);
        MSPResult DeleteStory(string id);
    }
}
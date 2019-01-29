using System;
using DataLayer;
using DataLayer.Model;
using DataLayer.Queries;
using DataLayer.Queries.Interfaces;
using Service.Interfaces;

namespace Service
{
    public class Editor : IEditor
    {
        private IDbWrite _dbWrite;
        private IDbRead _dbRead;
        
        public Editor(PrimoContext newContext)
        {
            _dbWrite = new DbWrite(newContext);
            _dbRead = new DbRead(newContext);
        }
        
        public MSPResult SaveNewStory(string message)
        {
            var newStory = new Story()
            {
                Published = DateTime.Now,
                Message = message
            };
            
            return _dbWrite.SaveStory(newStory);           
        }

        public MSPResult EditStory(Story story)
        {
            var recentStory = _dbRead.GetStory(story.ID);
            recentStory.Message = story.Message;
            return _dbWrite.EditStory(recentStory);
        }

        public MSPResult DeleteStory(string id)
        {
            return _dbWrite.DeleteStory(id);
        }
    }
}
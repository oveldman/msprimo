using System;
using System.Linq;
using DataLayer.Model;
using DataLayer.Queries.Interfaces;

namespace DataLayer.Queries
{
    public class DbWrite : IDbWrite
    {
        private PrimoContext _context;

        public DbWrite(PrimoContext newContext)
        {
            _context = newContext;
        }

        public MSPResult SaveStory(Story story)
        {
            try
            {
                _context.Stories.Add(story);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                return new MSPResult(e.Message);
            }

            return new MSPResult();
        }

        public MSPResult EditStory(Story story)
        {
            try
            {
                _context.Stories.Update(story);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                return new MSPResult(e.Message);
            }

            return new MSPResult();
        }

        public MSPResult DeleteStory(string id)
        {
            try
            {
                var story = _context.Stories.SingleOrDefault(s => s.ID.Equals(id));

                if (story != null)
                {
                    _context.Stories.Remove(story);
                    _context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                return new MSPResult(e.Message);
            }

            return new MSPResult();
        }
    }
}
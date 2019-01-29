using System.Collections.Generic;
using System.Linq;
using DataLayer.Model;
using DataLayer.Queries.Interfaces;

namespace DataLayer.Queries
{
    public class DbRead : IDbRead
    {
        private PrimoContext _context;
        public DbRead(PrimoContext newContext)
        {
            _context = newContext;
        }

        public Story GetStory(string id)
        {
            return _context.Stories.SingleOrDefault(s => s.ID.Equals(id));
        }

        public List<Story> GetStories(int firstItem, int listLength)
        {
            return _context.Stories.OrderByDescending(s => s.Published).Skip(firstItem).Take(listLength).ToList();
        }

        public int GetTotalStories()
        {
            return _context.Stories.Count();
        }
    }
}
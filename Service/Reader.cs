using System;
using System.Collections.Generic;
using DataLayer;
using DataLayer.Model;
using DataLayer.Queries;
using DataLayer.Queries.Interfaces;
using Service.Interfaces;

namespace Service
{
    public class Reader : IReader
    {
        private IDbRead _dbRead;
        private const int ItemsEachPage = 10;
        
        public Reader(PrimoContext newContext)
        {
            _dbRead = new DbRead(newContext);
        }

        public Story GetStory(string id)
        {
            return _dbRead.GetStory(id);
        }

        public List<Story> GetStories(int page)
        {
            const int ignoreOnly = 1;
            var ignoreItems = (page - ignoreOnly) * ItemsEachPage;
            return _dbRead.GetStories(ignoreItems, ItemsEachPage);
        }

        public int GetTotalPages()
        {
            int totalStories = _dbRead.GetTotalStories();
            double totalPages = (totalStories / ItemsEachPage);
            return Convert.ToInt32(Math.Ceiling(totalPages));
        }
    }
}
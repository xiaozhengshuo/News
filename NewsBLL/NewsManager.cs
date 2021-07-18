using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NewsDAL;
using NewsModels;

namespace NewsBLL
{
    public static class NewsManager
    {
        public static void DeleteNews(News news)
        {
            NewsService.DeleteNews(news);
        }
        public static IList<News> GetNewsPartFieldsByConditions(string conditions, string sortFieild, string direcion)
        {
            return NewsService.GetNewsAllFieldsByConditions(conditions, sortFieild, direcion);
        }
        public static News GetNewsById(int id)
        {
            return NewsService.GetNewsById(id);
        }
        public static void AddNews(News news)
        {
            if (news.Author == null)
                news.Author = "";
            news.PubDate = DateTime.Now;
            news.Clicks = 0;
            NewsService.AddNews(news);
        }
        public static void ModifyNews(News news)
        {
            if (news.Author == null)
                news.Author = "";
            if (news.PubDate == DateTime.MinValue)
                news.PubDate = DateTime.Now;
            NewsService.ModifyNews(news);
        }
        public static IList<News> GetNewsById()
        {
            return NewsService.GetNewsById();
        }
    }
}

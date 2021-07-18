using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewsModels
{
    [Serializable()]
    public class News
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string title = String.Empty;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        private string author = String.Empty;

        public string Author
        {
            get { return author; }
            set { author = value; }
        }
        private DateTime pubDate;

        public DateTime PubDate
        {
            get { return pubDate; }
            set { pubDate = value; }
        }
        private string contents = String.Empty;

        public string Contents
        {
            get { return contents; }
            set { contents = value; }
        }
        private int clicks;

        public int Clicks
        {
            get { return clicks; }
            set { clicks = value; }
        }
        private int newsCategoryId;

        public int NewsCategoryId
        {
            get { return newsCategoryId; }
            set { newsCategoryId = value; }
        }
        private NewsCategory newsCategory;

        public NewsCategory NewsCategory
        {
            get { return newsCategory; }
            set { newsCategory = value; }
        }

        private string image;
        public string Image
        {
            get { return image; }
            set { image = value; }
        }
        public News() { }
    }
}

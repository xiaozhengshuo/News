using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using NewsModels;

namespace NewsDAL
{
    public static class NewsService
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["NewsDBConnectionString"].ConnectionString;


        public static void AddNews(News news)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                SqlCommand cm = new SqlCommand();
                cm.Connection = cn;
                string sql =
                "INSERT News (Title, Author, PubDate, Contents, Clicks, NewsCategoryId)" +
                "VALUES (@Title, @Author, @PubDate, @Contents, @Clicks, @NewsCategoryId)";
                cm.CommandText = sql;
                cm.Parameters.AddWithValue("@Title", news.Title);
                cm.Parameters.AddWithValue("@Author", news.Author);
                cm.Parameters.AddWithValue("@PubDate", news.PubDate);
                cm.Parameters.AddWithValue("@Contents", news.Contents);
                cm.Parameters.AddWithValue("@Clicks", news.Clicks);
                cm.Parameters.AddWithValue("@NewsCategoryId", news.NewsCategoryId);
                cm.ExecuteNonQuery();
            }
        }

        public static void DeleteNews(News news)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                SqlCommand cm = new SqlCommand();
                cm.Connection = cn;
                string sql = "DELETE News WHERE Id = @Id";
                cm.CommandText = sql;
                cm.Parameters.AddWithValue("@Id", news.Id);
                cm.ExecuteNonQuery();
            }
        }

        public static void ModifyNews(News news)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                SqlCommand cm = new SqlCommand();
                cm.Connection = cn;
                string sql =
                "UPDATE News " +
                "SET " +
                    "Title = @Title, " +
                    "Author = @Author, " +
                    "PubDate = @PubDate, " +
                    "Contents = @Contents, " +
                    "Clicks = @Clicks, " +
                    "NewsCategoryId = @NewsCategoryId " +
                "WHERE Id = @Id";
                cm.CommandText = sql;
                cm.Parameters.AddWithValue("@Id", news.Id);
                cm.Parameters.AddWithValue("@Title", news.Title);
                cm.Parameters.AddWithValue("@Author", news.Author);
                cm.Parameters.AddWithValue("@PubDate", news.PubDate);
                cm.Parameters.AddWithValue("@Contents", news.Contents);
                cm.Parameters.AddWithValue("@Clicks", news.Clicks);
                cm.Parameters.AddWithValue("@NewsCategoryId", news.NewsCategoryId);
                cm.ExecuteNonQuery();
            }
        }


        public static News GetNewsById(int id)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                SqlCommand cm = new SqlCommand();
                cm.Connection = cn;
                string sql = "SELECT * FROM News WHERE Id = @Id";
                cm.CommandText = sql;
                cm.Parameters.AddWithValue("@Id", id);
                SqlDataReader dr = cm.ExecuteReader();
                if (dr.Read())
                {
                    News news = new News();
                    news.Id = (int)dr["Id"];
                    news.Title = (string)dr["Title"];
                    news.Author = (string)dr["Author"];
                    news.PubDate = (DateTime)dr["PubDate"];
                    news.Contents = (string)dr["Contents"];
                    news.Clicks = (int)dr["Clicks"];
                    news.NewsCategoryId = (int)dr["NewsCategoryId"];
                    news.Image = (string)dr["Image"];
                    news.NewsCategory = NewsCategoryService.GetNewsCategoryById((int)dr["NewsCategoryId"]);
                    dr.Close();
                    return news;
                }
                else
                {
                    dr.Close();
                    return null;
                }
            }
        }


        private static IList<News> GetNewsBySql(string sql)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                SqlCommand cm = new SqlCommand();
                cm.Connection = cn;
                cm.CommandText = sql;
                SqlDataReader dr = cm.ExecuteReader();
                List<News> list = new List<News>();
                while (dr.Read())
                {
                    News news = new News();
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        string fieldName = dr.GetName(i);
                        if (fieldName == "Id")
                            news.Id = (int)dr["Id"];
                        else if (fieldName == "Title")
                            news.Title = (string)dr["Title"];
                        else if (fieldName == "Author")
                            news.Author = (string)dr["Author"];
                        else if (fieldName == "PubDate")
                            news.PubDate = (DateTime)dr["PubDate"];
                        else if (fieldName == "Contents")
                            news.Contents = (string)dr["Contents"];
                        else if (fieldName == "Clicks")
                            news.Clicks = (int)dr["Clicks"];
                        else if (fieldName == "NewsCategoryId")
                        {
                            news.NewsCategoryId = (int)dr["NewsCategoryId"];
                            news.NewsCategory = NewsCategoryService.GetNewsCategoryById((int)dr["NewsCategoryId"]);
                        }
                        else if (fieldName == "Image")                       
                            news.Image = (string)dr["Image"];                     
                    }
                    list.Add(news);
                }
                dr.Close();
                return list;
            }
        }


        public static IList<News> GetNewsPartFieldsByConditions(string conditions, string sortField, string direction)
        {
            string sql = "SELECT Id, Title, Author, PubDate, Clicks, NewsCategoryId FROM News";
            if (conditions.Trim().Length > 0)
            {
                sql += " WHERE " + conditions;
            }
            if (sortField.Trim().Length > 0)
            {
                sql += " ORDER BY " + sortField;
            }
            if (direction.Trim().Length > 0)
            {
                sql += " " + direction;
            }
            return GetNewsBySql(sql);
        }
        public static IList<News> GetNewsById()
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                SqlDataReader dr;
                string sql = "SELECT Id, Title, Author, PubDate, Contents, Clicks,NewsCategoryId,Image From News";
                SqlCommand cm = new SqlCommand(sql.ToString(), cn);
                using (cm)
                {
                    cn.Open();
                    dr = cm.ExecuteReader();
                    List<News> list = new List<News>();
                    while (dr.Read())
                    {
                        News news = new News();
                        news.Id = (int)dr["Id"];
                        news.Title = (string)dr["Title"];
                        news.Author = Convert.ToString(dr["Author"]);
                        news.PubDate = (DateTime)dr["PubDate"];
                        news.Clicks = (int)dr["Clicks"];
                        news.Contents = (string)dr["Contents"];
                        news.NewsCategoryId = (int)dr["NewsCategoryId"];
                        news.NewsCategory = NewsCategoryService.GetNewsCategoryById((int)dr["NewsCategoryId"]);
                        news.Image = (string)dr["Image"];
                        list.Add(news);
                    }
                    dr.Close();
                    return list;
                }

            }
        }

        public static IList<News> GetNewsAllFieldsByConditions(string conditions, string sortField, string direction)
        {
            string sql = "SELECT Id, Title, Author, PubDate, Contents, Clicks, NewsCategoryId,Image FROM News";
            if (conditions.Trim().Length > 0)
            {
                sql += " WHERE " + conditions;
            }
            if (sortField.Trim().Length > 0)
            {
                sql += " ORDER BY " + sortField;
            }
            if (direction.Trim().Length > 0)
            {
                sql += " " + direction;
            }
            return GetNewsBySql(sql);
        }

        public static IList<News> GetNewsTop15()
        {
            string sql = "SELECT Top 15 Id, Title FROM News ORDER BY Id DESC";
            return GetNewsBySql(sql);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using NewsModels;

namespace NewsDAL
{
    public static class NewsCategoryService
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["NewsDBConnectionString"].ConnectionString;
        
        public static void DeleteNewsCategory(NewsCategory newsCategory)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                SqlCommand cm = new SqlCommand();
                cm.Connection = cn;
                string sql = "DELETE FROM NewsCategories WHERE Id = @Id";
                cm.CommandText = sql;
                cm.Parameters.AddWithValue("@Id", newsCategory.Id);
                cm.ExecuteNonQuery();
            }
        }

        public static void ModifyNewsCategory(NewsCategory newsCategory)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                SqlCommand cm = new SqlCommand();
                cm.Connection = cn;
                string sql = "UPDATE NewsCategories SET Name = @Name WHERE Id = @Id";
                cm.CommandText = sql;
                cm.Parameters.AddWithValue("@Id", newsCategory.Id);
                cm.Parameters.AddWithValue("@Name", newsCategory.Name);
                cm.ExecuteNonQuery();
            }
        }

        public static IList<NewsCategory> GetNewsCategories()
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                SqlCommand cm = new SqlCommand();
                cm.Connection = cn;
                string sql = "SELECT * FROM NewsCategories";
                cm.CommandText = sql;
                SqlDataReader dr = cm.ExecuteReader();
                List<NewsCategory> list = new List<NewsCategory>();
                while (dr.Read())
                {
                    NewsCategory newCategory = new NewsCategory();
                    newCategory.Id = (int)dr["Id"];
                    newCategory.Name = (string)dr["Name"];
                    list.Add(newCategory);
                }
                dr.Close();
                return list;
            }
        }


        /// <summary>
        /// 根据Id查询新闻类别
        /// </summary>
        /// <param name="id">新闻类别Id</param>
        /// <returns>新闻类别对象</returns>
        public static NewsCategory GetNewsCategoryById(int id)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                SqlCommand cm = new SqlCommand();
                cm.Connection = cn;
                string sql = "SELECT * FROM NewsCategories WHERE Id = @Id";
                cm.CommandText = sql;
                cm.Parameters.AddWithValue("@Id", id);
                SqlDataReader dr = cm.ExecuteReader();
                if (dr.Read())
                {
                    NewsCategory newsCategory = new NewsCategory();
                    newsCategory.Id = (int)dr["Id"];
                    newsCategory.Name = (string)dr["Name"];
                    dr.Close();
                    return newsCategory;
                }
                else
                {
                    dr.Close();
                    return null;
                }
            }
        }
    }
}

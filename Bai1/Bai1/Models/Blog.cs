using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace Bai1.Models
{
    public partial  class Blog
    {
        public int ID { get; set; }

        //[Required(ErrorMessage="Bạn cần nhập vào Tin")]
        //[Display(Name="Tin")]

        public string TIN { get; set; }

        //[Required(ErrorMessage = "Bạn cần nhập vào Loại")]
        //[Display(Name = "Loại")]

        public string LOAI { get; set; }

        //[Required(ErrorMessage = "Bạn cần nhập vào Trạng Thái")]
        //[Display(Name = "Trạng Thái")]

        public string TRANGTHAI { get; set; }

        //[Required(ErrorMessage = "Bạn cần nhập vào Vị Trí")]
        //[Display(Name = "Vị Trí")]

        public string VITRI { get; set; }

        //[Required(ErrorMessage = "Bạn cần nhập vào Ngày Public")]
        //[Display(Name = "Ngày Public")]
        public DateTime NGAYPUBLIC { get; set; }

    
    }
    

  public  class listBlogs
    {
        DBConnection db;
        public listBlogs()
        {
            db = new DBConnection();
        }

        // viết phương thức lấy dữ liệu từ CSDL
        public List<Blog> getBlog(string ID)
        {
            string sql;
            if(string.IsNullOrEmpty(ID))
            {
                sql = "SELECT * FROM Blog";
            }
            else 
            {
                sql = "SELECT * FROM Blog WHERE Id=" + ID;
            }

            List<Blog> strList = new List<Blog>();

            SqlConnection con = db.getConnection();
            SqlDataAdapter cmd = new SqlDataAdapter(sql, con);

            DataTable dt = new DataTable();

            //mở kết nối
            con.Open();
            // Đổ dữ liệu
            cmd.Fill(dt);

            // Đóng kết nối
            cmd.Dispose();
            con.Close();

            Blog strBlog;
            for(int i=0;i<dt.Rows.Count;i++)
            {
                strBlog = new Blog();
               
                strBlog.ID = int.Parse(dt.Rows[i]["Id"].ToString());
              //  strBlog.Tin = dt.Rows[i]["Tin"].ToString();
                strBlog.TIN = dt.Rows[i]["Tin"].ToString();
                strBlog.LOAI= dt.Rows[i]["Loai"].ToString();
                strBlog.TRANGTHAI= dt.Rows[i]["TrangThai"].ToString();
                strBlog.VITRI = dt.Rows[i]["ViTri"].ToString();
                strBlog.NGAYPUBLIC =DateTime.Parse( dt.Rows[i]["Ngaypublic"].ToString());

                strList.Add(strBlog);
            }
            return strList;

        }

      public void AddBlog(Blog blog)
        {
            string sql = "INSERT INTO Blog(Tin,Loai,TrangThai,ViTri,Ngaypublic) VALUES(N'" + blog.Tin + "',N'" + blog.Loai + "',N'" + blog.TrangThai + "',N'" + blog.ViTri + "',N'" + blog.Ngaypublic + "')";
            SqlConnection con = db.getConnection();
            SqlCommand cmd = new SqlCommand(sql, con);

          //mở kết nối
            con.Open();
            cmd.ExecuteNonQuery();

          // Đóng kết nối
            cmd.Dispose();
            con.Close();
        }

    }
}
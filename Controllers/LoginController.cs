using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using 實驗室管理.Models;

namespace 實驗室管理.Controllers
{
    public class LoginController : Controller
    {
        private Laboratoryborrow1Entities db = new Laboratoryborrow1Entities();

        // GET: Login
        public ActionResult Index()
        {
            ViewBag.Msg = "歡迎使用";
            ViewBag.IsLogin = false;
            Session["UserInfo"] = null;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        // GET: Login/Details/5
        public ActionResult Index([Bind(Include = "email,password")] User my_member)
        {
            ViewBag.Msg = "歡迎使用";
            ViewBag.IsLogin = false;
            Session["UserInfo"] = null;
            if (ModelState.IsValid)
            {
                User m = db.Users.Where(s => s.email.Equals(my_member.email) && s.password.Equals(my_member.password)).FirstOrDefault();
                if (m != null)
                {
                    Session["UserInfo"] = m;
                    ViewBag.IsLogin = true;
                    ViewBag.Msg = string.Format("登入成功 使用者: (0) ，歡迎光臨", my_member.name);
					Session["Auth"] = db.Users.Where(s => s.email.Equals(my_member.email) && s.password.Equals(my_member.password)).FirstOrDefault().auth_ID; ;
				}
                else
                {
                    ViewBag.Msg = "登入失敗";
                }
            }
            return View();
        } 
        public ActionResult Logout()
        {
            Session["UserInfo"] = null;
            ViewBag.IsLogin = false;
            return RedirectToAction("Index");
        }
        public ActionResult Register() 
        {
            return View();
        }
		//新的
		/*public ActionResult DoRegister(User inModel)
		{
			DoRegisterOut outModel = new DoRegisterOut();

			if (string.IsNullOrEmpty(inModel.password) || string.IsNullOrEmpty(inModel.name) || string.IsNullOrEmpty(inModel.email))
			{
				outModel.ErrMsg = "請輸入資料";
			}
			else
			{
				SqlConnection conn = null;
				try
				{
					// 資料庫連線
					string connStr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["LaboratoryborrowConnectionString"].ConnectionString;
					conn = new SqlConnection();
					conn.ConnectionString = connStr;
					conn.Open();

					// 檢查帳號是否存在
					string sql = "select * from Users where UserEmail = @UserEmail";
					SqlCommand cmd = new SqlCommand();
					cmd.CommandText = sql;
					cmd.Connection = conn;

					// 使用參數化填值
					cmd.Parameters.AddWithValue("@UserEmail", inModel.email);

					// 執行資料庫查詢動作
					DbDataAdapter adpt = new SqlDataAdapter();
					adpt.SelectCommand = cmd;
					DataSet ds = new DataSet();
					adpt.Fill(ds);

					if (ds.Tables[0].Rows.Count > 0)
					{
						outModel.ErrMsg = "此登入帳號已存在";
					}
					else
					{
						// 將密碼使用 SHA256 雜湊運算(不可逆)
						string salt = inModel.email.Substring(0, 1).ToLower(); //使用帳號前一碼當作密碼鹽
						SHA256 sha256 = SHA256.Create();
						byte[] bytes = Encoding.UTF8.GetBytes(salt + inModel.password); //將密碼鹽及原密碼組合
						byte[] hash = sha256.ComputeHash(bytes);
						StringBuilder result = new StringBuilder();
						for (int i = 0; i < hash.Length; i++)
						{
							result.Append(hash[i].ToString("X2"));
						}
						string NewPwd = result.ToString(); // 雜湊運算後密碼

						// 註冊資料新增至資料庫
						sql = @"INSERT INTO User (department_ID,password,name,email) VALUES (@UserDep, @UserPwd, @UserName, @UserEmail)";
						cmd = new SqlCommand();
						cmd.Connection = conn;
						cmd.CommandText = sql;

						// 使用參數化填值
						cmd.Parameters.AddWithValue("@UserDep", inModel.department_ID);
						cmd.Parameters.AddWithValue("@UserPwd", NewPwd); // 雜湊運算後密碼
						cmd.Parameters.AddWithValue("@UserName", inModel.name);
						cmd.Parameters.AddWithValue("@UserEmail", inModel.email);

						// 執行資料庫更新動作
						cmd.ExecuteNonQuery();

						outModel.ResultMsg = "註冊完成";
					}
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					if (conn != null)
					{
						//關閉資料庫連線
						conn.Close();
						conn.Dispose();
					}
				}
			}

			// 輸出json
			return Json(outModel);
		}*/

	}
}

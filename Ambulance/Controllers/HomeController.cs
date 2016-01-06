using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace Ambulance.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(ambulance_user user)
        {
            if (ModelState.IsValid)
            {
                    using (ambulanceEntities dc = new ambulanceEntities())
                    {
                        
                        string cypher;
                        using (MD5 md5Hash = MD5.Create())
                        {
                            cypher = GetMd5Hash(md5Hash, user.password.ToString());

                        }

                        ambulance_user v = dc.ambulance_user.Where(b => b.login.Equals(user.login) && b.password.Equals(cypher)).FirstOrDefault();


                        if (v != null)
                        {

                            string staffName = "";
                            int depNumb;
                            if (v.role_id == 1)
                            {
                                var staff = dc.doctors.Where(a => a.shifr.Equals(v.prof_id)).FirstOrDefault();
                                staffName = staff.d_name;
                                depNumb = (int)staff.OtdNumb;
                            }
                            else if (v.role_id == 2)
                            {
                                var staff = dc.m_sister.Where(a => a.M_id.Equals(v.prof_id)).FirstOrDefault();
                                staffName = staff.M_Name;
                                depNumb = (int)staff.OtdNumb;
                            }
                            Session["LogedUserId"] = v.id.ToString();
                            Session["LogedUserLogin"] = v.login.ToString();
                            Session["LogedUserRole"] = v.role_id.ToString();
                            Session["LogedUserPass"] = cypher;
                            Session["LogedUserName"] = staffName;
                           
                            return RedirectToAction("AfterLogin");
                        }
                    }
                }      
            return View(user);
        }
        public ActionResult AfterLogin()
        {
            //if (Session["LogedUserId"] != null)
            //{
                return View();
            //}
            //else
            //{
            //   return RedirectToAction("Index");
            //}
            
        }

        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        // Verify a hash against a string.
        static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            // Hash the input.
            string hashOfInput = GetMd5Hash(md5Hash, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
    }
        }
}

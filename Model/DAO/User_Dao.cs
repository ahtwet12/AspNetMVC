using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;


namespace Model.DAO
{
    public class User_Dao
    {
        BcaoCuoiKyDbContext db = null; 
        public User_Dao()
        {
            db = new BcaoCuoiKyDbContext();
        }

        public User getItem(string email)
        {
            return db.Users.FirstOrDefault(x => x.Email == email);
        }

        public List<User> getList()
        {
            return db.Users.ToList();
        }

        public User Add(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return user;
        }

        public User Update(User user)
        {
            var us = db.Users.FirstOrDefault(x => x.ID == user.ID);
            us.Password = user.Password;
            us.FullName = user.FullName;
            us.Email = user.Email;
            us.Phone = user.Phone;
            us.Address = user.Address;
            us.UpdateBy = user.UpdateBy;
            us.UpdateDate = user.UpdateDate;
            db.SaveChanges();
            return us;
        }

        public int Login(string email, string pass)
        {
            var user = db.Users.FirstOrDefault(x => x.Email == email);
            
            if(user == null)
            {
                return -2;//neu kh co email
            }
            else
            {
                if(user.Status == false)
                {
                    return 0;//vo hieu hoa
                }
                else
                {
                    
                    if (user.Password == pass)
                    {
                        return 1; //dnhap thanh cong
                    }
                    else
                    {
                        return -1; // sai pass
                    }
                }
            }
        }


    }
}

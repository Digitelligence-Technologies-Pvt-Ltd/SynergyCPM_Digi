using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace SynergyWebServices.DEL;


    public class AccountsEntity
    {
    public class Login
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }

    public class ForgotPassword
    {
        public string UserName { get; set; }

   
        public string Email { get; set; }

  
        public string Question { get; set; }

     
        public string Answer { get; set; }
    }

   public class ChangePassword
    {
        public string UserName { get; set; }

        public string ID { get; set; }

       
        public string OldPassword { get; set; }

       
        public string NewPassword { get; set; }

       
        public string ConfirmPassword { get; set; }

    }

    }


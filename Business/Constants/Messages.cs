using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "Ürün ismi uygun değil";
        public static string MaintenanceTime="Sistem bakımda";
        public static string ProductCountOfCategoryError="Bu üründen daha fazla ekleyemezsiniz";
        public static string ProductNameIsAlreadyExist="bu isimle bir ürün var zaten";
        public static string AuthorizationDenied="Yetkiniz yok";
        internal static string UserRegistered;
        internal static User UserNotFound;
        internal static User PasswordError;
        internal static string SuccessfulLogin;
        internal static string UserAlreadyExists;
        internal static string AccessTokenCreated;
    }
}

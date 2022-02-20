using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}

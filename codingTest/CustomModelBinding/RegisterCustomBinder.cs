using codingTest.Models;
using System;
using System.Web;
using System.Web.Mvc;

namespace codingTest.CustomModelBinding
{
    public class RegisterCustomBinder : System.Web.Mvc.IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            HttpRequestBase request = controllerContext.HttpContext.Request;

            string firstName = request.Form.Get("FirstName");
            string lastName = request.Form.Get("LastName");
            string email = request.Form.Get("Email");
            string day = request.Form.Get("Day");
            string month = request.Form.Get("Month");
            string year = request.Form.Get("Year");
            string stringDate = month + "-" + day + "-" + year;
            DateTime birthDate;

            if (day.Equals("") || month.Equals("") || year.Equals(""))
            {
                return new RegisterModel
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    BirthDate = null
                };
            }

            try
            {
                birthDate = DateTime.ParseExact(stringDate, "MM-dd-yyyy", null);
            }
            catch (Exception ex)
            {
                return new RegisterModel
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                };
            }
            
            return new RegisterModel
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                BirthDate = birthDate
            };
        }
    }
}
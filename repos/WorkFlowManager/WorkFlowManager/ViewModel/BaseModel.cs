using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace WorkFlowManager.ViewModel
{
    public abstract class BaseModel : IValidatableObject
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Throws an Error if the Object is not Valid
        /// </summary>
        public virtual void Validate()
        {
            Validator.ValidateObject(this, new ValidationContext(this, serviceProvider: null, items: null));
        }

        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext) => new ValidationResult[0];
    }
    public static class CommonExtension
    {
        public static ApiResponse<object> ToResponse(this object data, string message = "", HttpStatusCode status = HttpStatusCode.OK)
        {
            if (data is string)
            {
                message = data.ToString();
            }
            return new ApiResponse<object>() { Message = message, StatusCode = status, Data = data };
        }

    }
    public class ApiResponse<T>
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public List<string> errors { get; set; }
    }

    public static class Extensions
    {
        public static T ParseEnum<T>(this string value) where T : struct
        {
            T enumobj = default(T);
            if (Enum.TryParse(value, true, out enumobj))
            {
                return enumobj;
            }
            else
            {
                return default(T);
            }
        }
        /// <summary>
        /// Update properties with properties of the object Supplied (typically anonymous)
        /// </summary>
        /// <typeparam name="T">Type of Source Object</typeparam>
        /// <param name="destination">Object whose property you want to update</param>
        /// <param name="source">destination object (typically anonymous) you want to take values from</param>
        /// <returns>Update reference to same Object</returns>
        public static T Assign<T>(this T destination, object source, params string[] ignoredProperties)
        {
            if (ignoredProperties == null) ignoredProperties = new string[0];
            if (destination != null && source != null)
            {
                var query = from sourceProperty in source.GetType().GetProperties()
                            join destProperty in destination.GetType().GetProperties()
                            on sourceProperty.Name.ToLower() equals destProperty.Name.ToLower()             //Case Insensitive Match
                            where !ignoredProperties.Contains(sourceProperty.Name)
                            where destProperty.PropertyType.IsAssignableFrom(sourceProperty.PropertyType)   //Properties can be Assigned
                            where destProperty.GetSetMethod() != null                                       //Destination Property is not Readonly
                            select new { sourceProperty, destProperty };


                foreach (var pair in query)
                {
                    //Go ahead and Assign the value on the destination
                    pair.destProperty
                        .SetValue(destination,
                            value: pair.sourceProperty.GetValue(obj: source, index: new object[] { }),
                            index: new object[] { });
                }
            }
            return destination;
        }
    }

}

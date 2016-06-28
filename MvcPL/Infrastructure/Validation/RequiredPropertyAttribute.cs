using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcPL
{
    /// <summary>
    /// Specifies that a property of a data field value is required.
    /// </summary>
    public class RequiredPropertyAttribute : ValidationAttribute
    {
        #region Fields
        private string propertyName;
        private object propertyValue;
        #endregion

        #region Constructors
        /// <summary>
        /// Instanciates RequiredPropertyAttribute with specified parameters.
        /// </summary>
        /// <param name="propertyName"> Name or the required property.</param>
        /// <param name="propertyValue"> Value of the required property.</param>
        public RequiredPropertyAttribute(string propertyName, object propertyValue)
        {
            this.propertyName = propertyName;
            this.propertyValue = propertyValue;
        }
        #endregion

        #region ValidationAttribute Methods
        /// <summary>
        /// Checks that the value of the property of the required data field is equal to value.
        /// </summary>
        /// <param name="value"> Value of the required property.</param>
        /// <returns> True if validation is successful; otherwise, false.</returns>
        public override bool IsValid(object value)
        {
            var list = value as ICollection;
            foreach (var item in list)
            {
                if (item.GetType().GetProperty(propertyName).GetValue(item).Equals(propertyValue)) return true;
            }
            return false;
        }
        #endregion
    }
}
﻿using System;
using System.Globalization;
using System.Windows.Data;

namespace Nedeljni_I_Kristina_Garcia_Francisco.Helper
{
    /// <summary>
    /// Convertes the first name of the user to the name
    /// </summary>
    class ManagerNameConverter : IValueConverter
    {
        /// <summary>
        /// Converts the parameter value into the user name
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Service service = new Service();
            for (int i = 0; i < service.GetAllManagersInfo().Count; i++)
            {
                if (service.GetAllManagersInfo()[i].FirstName == value.ToString())
                {
                    return service.GetAllManagersInfo()[i].FirstName + " " + service.GetAllManagersInfo()[i].LastName;
                }

                else if (service.GetAllManagersInfo()[i].ManagerID == (int)value)
                {
                    return service.GetAllManagersInfo()[i].FirstName + " " + service.GetAllManagersInfo()[i].LastName;
                }
            }

            return value;
        }

        /// <summary>
        /// Converts back
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}

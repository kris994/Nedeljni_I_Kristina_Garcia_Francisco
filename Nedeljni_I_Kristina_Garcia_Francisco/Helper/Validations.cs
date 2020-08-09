using Nedeljni_I_Kristina_Garcia_Francisco.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Nedeljni_I_Kristina_Garcia_Francisco.Helper
{
    /// <summary>
    /// Validates the user inputs
    /// </summary>
    class Validations
    {
        /// <summary>
        /// Value has to be a double
        /// </summary>
        /// <param name="number">input value</param>
        /// <returns>null if the input is correct or string error message if its wrong</returns>
        public string IsDouble(string number)
        {
            if (double.TryParse(number, out double value) == false || value < 0)
            {
                return "Not a valid number";
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Checks if the degree is valid
        /// </summary>
        /// <param name="degree">degree we are checking</param>
        /// <returns>null if the input is correct or string error message if its wrong<</returns>
        public string DegreeChecker(string degree)
        {
            if (degree == null)
            {
                return "Degree cannot be empty.";
            }

            if (degree != "I" && degree != "II" && degree != "III" && degree != "IV" && degree != "V" && degree != "VI" && degree != "VII")
            {
                return "Invalid degree";
            }

            return null;
        }

        /// <summary>
        /// Checks if the responsibility is valid
        /// </summary>
        /// <param name="responsibility">responsibility we are checking</param>
        /// <returns>null if the input is correct or string error message if its wrong<</returns>
        public string ResponsibilityChecker(string responsibility)
        {
            if (responsibility == null)
            {
                return "Responsibility cannot be empty.";
            }

            if (responsibility != "1" && responsibility != "2" && responsibility != "3")
            {
                return "Invalid responsibility";
            }

            return null;
        }

        /// <summary>
        /// Checks if the marriage is valid
        /// </summary>
        /// <param name="marriage">marriage we are checking</param>
        /// <returns>null if the input is correct or string error message if its wrong<</returns>
        public string MarriageChecker(string marriage)
        {
            if (marriage == null)
            {
                return "Marriage status cannot be empty.";
            }

            if (marriage != "Unmarried" && marriage != "Married" && marriage != "Divorced")
            {
                return "Invalid marriage status";
            }

            return null;
        }

        /// <summary>
        /// Checks if the admin type is valid
        /// </summary>
        /// <param name="type">admin type we are checking</param>
        /// <returns>null if the input is correct or string error message if its wrong<</returns>
        public string AdminTypeCheker(string type)
        {
            if (type == null)
            {
                return "Admin type cannot be empty.";
            }

            if (type != "Local" && type != "System" && type != "Team")
            {
                return "Invalid admin type";
            }

            return null;
        }

        /// <summary>
        /// Checks if the Username is exists
        /// </summary>
        /// <param name="username">the username we are checking</param>
        /// <param name="id">for the specific user</param>
        /// <returns>null if the input is correct or string error message if its wrong</returns>
        public string UsernameChecker(string username, int id)
        {
            Service service = new Service();

            List<tblUser> AllUsers = service.GetAllUsers();
            string currectUsername = "";

            if (username == null)
            {
                return "Username cannot be empty.";
            }
            // Get the current users username
            for (int i = 0; i < AllUsers.Count; i++)
            {
                if (AllUsers[i].UserID == id)
                {
                    currectUsername = AllUsers[i].Username;
                    break;
                }
            }

            // Cannot be the same username as admins
            if (username == "WPFMaster")
            {
                return "This Username already exists!";
            }

            // Check if the username already exists, but it is not the current user username
            for (int i = 0; i < AllUsers.Count; i++)
            {
                if ((AllUsers[i].Username == username && currectUsername != username))
                {
                    return "This Username already exists!";
                }
            }

            return null;
        }

        /// <summary>
        /// Validates the given string if its an email or not
        /// </summary>
        /// <param name="email">string that is validated</param>
        /// <param name="id">for the specific user</param>
        /// <returns>null if the input is correct or string error message if its wrong</returns>
        public string IsValidEmailAddress(string email, int id)
        {
            Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            Service service = new Service();

            List<tblManager> AllManagers = service.GetAllManagers();
            string currentEmail = "";

            if (email == null)
            {
                return "Email cannot be empty.";
            }

            // Get the current users email
            for (int i = 0; i < AllManagers.Count; i++)
            {
                if (AllManagers[i].UserID == id)
                {
                    currentEmail = AllManagers[i].Email;
                    break;
                }
            }

            // Check if the email already exists, but it is not the current user email
            for (int i = 0; i < AllManagers.Count; i++)
            {
                if (AllManagers[i].Email == email && currentEmail != email)
                {
                    return "This Email already exists!";
                }
            }

            if (regex.IsMatch(email) == false)
            {
                return "Invalid email";
            }

            return null;
        }

        /// <summary>
        /// Calculates the date of birth for the given jmbg
        /// </summary>
        /// <param name="jmbg">given jmbg</param>
        /// <returns>the date of birth</returns>
        public DateTime CountDateOfBirth(string jmbg)
        {
            DateTime dt = default(DateTime);

            // Get the date of birth
            if (jmbg[4] == '0')
            {
                string date = jmbg.Substring(0, 2) + "/" + jmbg.Substring(2, 2) + "/" + "2" + jmbg.Substring(4, 3);
                try
                {
                    dt = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    return dt;
                }
                catch (FormatException)
                {
                    dt = default(DateTime);
                    return dt;
                }
            }
            if (jmbg[4] == '9')
            {
                string date = jmbg.Substring(0, 2) + "/" + jmbg.Substring(2, 2) + "/" + "1" + jmbg.Substring(4, 3);
                try
                {
                    dt = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    return dt;
                }
                catch (FormatException)
                {
                    dt = default(DateTime);
                    return dt;
                }
            }
            return dt;
        }

        /// <summary>
        /// Checks if the jmbg is correct
        /// </summary>
        /// <param name="jmbg">the jmbg we are checking</param>
        /// <param name="id">for the specific user</param>
        /// <returns>null if the input is correct or string error message if its wrong</returns>
        public string JMBGChecker(string jmbg, int id)
        {
            Service service = new Service();

            List<tblUser> AllUsers = service.GetAllUsers();
            DateTime dt = default(DateTime);
            string currentJbmg = "";

            if (jmbg == null)
            {
                return "JMBG cannot be empty.";
            }

            // Get the current users jmbg
            for (int i = 0; i < AllUsers.Count; i++)
            {
                if (AllUsers[i].UserID == id)
                {
                    currentJbmg = AllUsers[i].JMBG;
                    break;
                }
            }

            // Check if the jmbg already exists, but it is not the current user jmbg
            for (int i = 0; i < AllUsers.Count; i++)
            {
                if (AllUsers[i].JMBG == jmbg && currentJbmg != jmbg)
                {
                    return "This JMBG already exists!";
                }
            }

            if (!(jmbg.Length == 13))
            {
                return "Please enter a number with 13 characters.";
            }

            // Get date
            dt = CountDateOfBirth(jmbg);

            if (dt == default(DateTime))
            {
                return "Incorrect JMBG Format.";
            }

            return null;
        }

        /// <summary>
        /// Input cannot be shorter than expected
        /// </summary>
        /// <param name="name">name of the input</param>
        /// <param name="number">length of the input</param>
        /// <returns>null if the input is correct or string error message if its wrong</returns>
        public string TooShort(string name, int number)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Length < number)
            {
                return "Cannot be shorter than " + number + " characters.";
            }
            else
            {
                return null;
            }
        }
    }
}

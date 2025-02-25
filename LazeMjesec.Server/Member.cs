using System.Text.RegularExpressions;

namespace LazeMjesec.Server
{
    public class Member
    {
        public string Name { get; set; }

        private string _email;
        public string Email 
        { 
            get 
            {
                return _email;
            }
            set
            {
                string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
                Regex emailRegex = new Regex(emailPattern);
                if (!emailRegex.IsMatch(value))
                {
                    throw new ArgumentException($"Invalid email address: {value}");
                }

                _email = value;
            }
        }
        public string? PhoneNumber { get; set; }
    }
}

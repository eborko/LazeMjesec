using System.Text.RegularExpressions;

namespace LazeMjesec.Server
{
    public class Member
    {
        private string _name;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value == string.Empty)
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                _name = value;
            }
        }

        private string _email;
        public string Email 
        { 
            get 
            {
                return _email;
            }
            set
            {
                Regex emailRegex = new Regex(RegexHolder.EmailPattern);
                if (!emailRegex.IsMatch(value))
                {
                    throw new ArgumentException($"Invalid email address: {value}");
                }

                _email = value;
            }
        }
        public string? PhoneNumber { get; set; }

        public Member()
        {
        }
    }
}

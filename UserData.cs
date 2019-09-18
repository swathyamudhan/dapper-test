using System;
using System.Collections.Generic;
using System.Text;

namespace orm
{
    // Occurance
    public class UserData
    {
        // occuranceId
        public string Username { get; set; }

        // dueDetails
        public List<Credentials> CredentialsList { get; set; }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            UserData otherObject = (UserData)obj;
            bool IsUsernameSame = this.Username.Equals(otherObject.Username);
            return IsUsernameSame;
        }

        public override int GetHashCode()
        {
            HashCode hashCode = new HashCode();
            hashCode.Add(Username);
            return hashCode.ToHashCode();
        }

        public override string ToString()
        {

            StringBuilder builder = new StringBuilder();
            foreach (Credentials credential in CredentialsList)
            {
                builder.Append(credential.ToString());
            }

            return "[Username:" + Username + ",CredentialsList:" + builder.ToString() + "]";
        }


    }

    public class Credentials
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            Credentials otherObject = (Credentials)obj;
            bool isEmailSame = this.Email.Equals(otherObject.Email);
            bool isPasswordSame = this.Password.Equals(otherObject.Password);
            return isEmailSame && isPasswordSame;
        }

        public override int GetHashCode()
        {
            HashCode hashCode = new HashCode();
            hashCode.Add(Email);
            hashCode.Add(Password);
            return hashCode.ToHashCode();
        }

        public override string ToString()
        {
            return "[Email:" + Email + ",Password:" + Password + "]";
        }
    }
}
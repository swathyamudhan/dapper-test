using System;

namespace orm
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DateCreated { get; set; }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            User otherObject = (User)obj;
            bool sameId = this.Id == otherObject.Id;
            bool sameUserName = this.Username.Equals(otherObject.Username);
            bool sameEmail = this.Email.Equals(otherObject.Email);
            bool samePassword = this.Password.Equals(otherObject.Password);
            bool sameDateCreated = this.DateCreated.Equals(otherObject.DateCreated);
            return sameId && sameUserName && sameEmail && samePassword && sameDateCreated;

        }

        public override int GetHashCode()
        {
            HashCode hashCode = new HashCode();
            hashCode.Add(Id);
            hashCode.Add(Username);
            hashCode.Add(Email);
            hashCode.Add(Password);
            hashCode.Add(DateCreated);
            return hashCode.ToHashCode();
        }

        public override string ToString()
        {
            return "[Id:" + Id + ",Username:" + Username + ",Email:" + Email + ", DateCreated:" + DateCreated + "]";
        }
    }
}
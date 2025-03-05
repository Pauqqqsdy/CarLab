using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CarLibrary
{
    public class IdNumber
    {
        int id;

        public int Id
        {
            get => id;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("ID не может быть отрицательным или равным 0.");
                id = value;
            }
        }

        public IdNumber(int number = 0)
        {
            Id = number;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj is not IdNumber) return false;
            IdNumber other = (IdNumber)obj;
            return Id == other.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public override string ToString()
        {
            return $"ID: {Id}";
        }
    }
}

using OnePiecePBBG.Core.Exceptions;
using OnePiecePBBG.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnePiecePBBG.Core.Validations
{
    public class DomainValidation
    {
        public static void EnsureNotNullOrEmpty(string value, string propertyName)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new DomainException($"{propertyName} cannot be null or empty.");
        }

        public static void EnsureGreaterThan(int value, int minValue, string propertyName)
        {
            if (value <= minValue)
                throw new DomainException($"{propertyName} must be greater than {minValue}.");
        }

        public static void EnsureNotNegative(int value, string propertyName)
        {
            if (value < 0)
                throw new DomainException($"{propertyName} cannot be negative.");
        }

        public static void EnsureInRange(int value, int min, int max, string propertyName)
        {
            if (value < min || value > max)
                throw new DomainException($"{propertyName} must be between {min} and {max}.");
        }

        internal static void EnsureNotNull(object obj, string propertyName)
        {
            if (obj == null)
                throw new DomainException($"{propertyName} cannot be null.");
        }
    }
}

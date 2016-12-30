using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnapGameLogic.Internal
{
    internal static class Check
    {
        public static T NotNull<T>(T value, string parameterName) where T : class
        {
            if (value == null)
                throw new ArgumentNullException(parameterName);
            return value;
        }

        public static T? NotNull<T>(T? value, string parameterName) where T : struct
        {
            if (!value.HasValue)
                throw new ArgumentNullException(parameterName);
            return value;
        }

        public static T NotZero<T>(T value, string parameterName) where T : struct
        {
            if (value.IsNumber() && value.Equals(0))
                throw new ArgumentException(string.Format(TextResources.Exception_ArgumentCannotBeZero, parameterName));

            return value;
        }

        public static string NotEmpty(string value, string parameterName)
        {
#if NET40
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException(string.Format(TextResources.Exception_ArgumentCannotBeZero, parameterName));
#else
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException(string.Format(TextResources.Exception_ArgumentCannotBeZero, parameterName));
#endif
            return value;
        }

        public static int NotNegative(int value, string parameterName)
        {
            if (value < 0)
                throw new ArgumentException(string.Format(TextResources.Exception_ArgumentCannotBeZero, parameterName));
            return value;
        }
    }
}

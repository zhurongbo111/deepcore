using System.Runtime.CompilerServices;

namespace DeepCore
{
    public static class ArgumentValidationExtensions
    {
        public static TArgument ThrowIfNull<TArgument>(this TArgument argument, [CallerArgumentExpression(nameof(argument))] string? paramName = null)
            where TArgument : class
        {
            ArgumentNullException.ThrowIfNull(argument, paramName);

            return argument;
        }
    }
}

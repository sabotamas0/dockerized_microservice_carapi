using FluentValidation.Results;

namespace CarApi.Helpers
{
    public class ErrorHelper
    {
        public static List<string> GetErrorNames(List<ValidationFailure> errors)
        {
            List<string> errorNames = new List<string>();
            foreach (var error in errors)
            {
                errorNames.Add(error.ErrorMessage);
            }
            return errorNames;
        }
    }
}

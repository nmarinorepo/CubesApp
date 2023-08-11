using Cubes.Application.Interfaces;

namespace Cubes.Application.Services
{
    public class ValidationService : IValidationService
    {
        public bool AreInputDataValid(string[] input)
        {
            bool result = true;
            if (input.Length > 0)
            {
                foreach (string data in input)
                {
                    if (!string.IsNullOrEmpty(data.Trim()))
                    {
                        string[] coords = data.Split(',');
                        if (coords.Length > 4)
                        {
                            result = false;
                        }
                        foreach (string item in coords)
                        {
                            int value = 0;
                            if (!string.IsNullOrEmpty(item) && int.TryParse(item, out value)) continue;
                            result = false;
                            break;
                        }

                    }
                    else { result = false; }
                }
            }
            else
            {
                result = false;
            }
            return result;
        }
    }
}

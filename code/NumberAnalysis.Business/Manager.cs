namespace NumberAnalysis.Business
{
    public static class Manager
    {
        public static List<int>? AnalyzeNumber(int number, out string message)
        {
            message = string.Empty;

            #region validations
            if (number < 0)
            {
                message = "Number must be greater than 0";
                return null;
            }
            if(number == 0)
            {
                message = "Number must be greater than 0";
                return null;
            }
            #endregion

            List<int>? numbers = new();

            if (number == 1)
            {
                numbers.Add(1);
                return numbers;
            }
            
            for (int i = 2; i <= number; i++)
            {
                if(number % i == 0)
                {
                    numbers.Add(i);
                    number = number / i;
                    i = 1;
                }
            }
            
            return numbers;
        }   
    }
}
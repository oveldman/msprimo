using System.Collections.Generic;

namespace DataLayer
{
    public class MSPResult
    {
        public bool Succeed { get; set; }
        public List<string> ErrorMessages { get; set; }

        public MSPResult()
        {
            Succeed = true;
            ErrorMessages = new List<string>();
        }

        public MSPResult(string errorMessage)
        {
            Succeed = false;
            ErrorMessages = new List<string> {errorMessage};
        }

        public MSPResult(List<string> errorMessages)
        {
            Succeed = false;
            ErrorMessages = errorMessages;
        }
    }
}
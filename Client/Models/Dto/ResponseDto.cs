using System.Collections.Generic;

namespace Client.Models
{
    public class ResponseDto
    {
        #region Properties

        public bool IsSuccess { get; set; } = true;
        public object Result { get; set; }
        public string DisplayMessage { get; set; }
        public List<string> ErrorMessages { get; set; }

        #endregion
    }
}

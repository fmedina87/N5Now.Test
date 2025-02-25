namespace N5Now.Test.Domain.Common.Reponses
{
    public class ApiReponse<T>
    {
        public ApiReponse() { }

        public string? ErrorMessage { get; set; }
        public T? Result { get; set; } = default;
        public PagedResult<T>? Data { get; set; } = null;
        public ApiReponse(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
        
    }
}

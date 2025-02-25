namespace N5Now.Test.Domain.Dto
{
    public class KafkaDtoMessage(string operation)
    {
        public string OperationName { get; } = operation;
        public Guid Id { get; } = Guid.NewGuid();
    }
}

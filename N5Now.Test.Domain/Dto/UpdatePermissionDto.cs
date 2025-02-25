namespace N5Now.Test.Domain.Dto
{
    public class UpdatePermissionDto:BasicPermissionDto
    {      
        public int Id { get; set; }
        public bool IsActive { get; set; }
    }
}

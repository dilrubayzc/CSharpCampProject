using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    [Table("UserOperationClaim", Schema = "dbo")]
    public class UserOperationClaim : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
    }
}

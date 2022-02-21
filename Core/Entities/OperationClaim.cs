using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    [Table("OperationClaim", Schema = "dbo")]
    public class OperationClaim : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

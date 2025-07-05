using System.ComponentModel.DataAnnotations.Schema;

namespace KidycareBackend.Profiles.Domain.Model.Aggregates;

public partial class Babysitter
{
    [Column("CreatedAt")] public DateTimeOffset? CreatedDate { get; set; }
    [Column("UpdatedAt")] public DateTimeOffset? UpdatedDate { get; set; }
}
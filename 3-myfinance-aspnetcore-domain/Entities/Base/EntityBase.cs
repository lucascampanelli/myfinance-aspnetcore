using System.ComponentModel.DataAnnotations;



namespace myfinance_aspnetcore_infra;

public class EntityBase
{
    [Key]
    public int? Id { get; set; }
}
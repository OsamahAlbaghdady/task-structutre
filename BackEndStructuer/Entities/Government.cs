namespace BackEndStructuer.Entities;

public class Government : BaseEntity<int>
{
    public string? Name { get; set; }

    public ICollection<Storage>? Storages { get; set; }
}
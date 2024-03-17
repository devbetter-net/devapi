namespace Dev.Core.Specification;

public interface IEntity<TId>
{
    TId Id { get; set; }
}

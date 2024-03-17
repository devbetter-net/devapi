namespace Dev.Core.Specification.Builder;

public interface IOrderedSpecificationBuilder<T> : ISpecificationBuilder<T>
{
    bool IsChainDiscarded { get; set; }
}

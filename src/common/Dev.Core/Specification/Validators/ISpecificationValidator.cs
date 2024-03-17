namespace Dev.Core.Specification.Validators;

public interface ISpecificationValidator
{
    bool IsValid<T>(T entity, ISpecification<T> specification);
}

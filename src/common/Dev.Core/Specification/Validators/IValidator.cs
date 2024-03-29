﻿namespace Dev.Core.Specification.Validators;

public interface IValidator
{
    bool IsValid<T>(T entity, ISpecification<T> specification);
}

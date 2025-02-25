﻿namespace RepositoryPatternUoW.Domain;

public class Department
{
    public Guid Id { get; set; }
    public string Description { get; set; }

    public ICollection<Employee> Employees { get; set; }
}
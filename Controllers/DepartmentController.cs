using Microsoft.AspNetCore.Mvc;
using RepositoryPatternUoW.Data.Repositories.Interfaces;

namespace RepositoryPatternUoW.Controllers;

public class DepartmentController : ControllerBase
{
    private readonly IDepartmentRepository _repository;
    private readonly ILogger<DepartmentController> _logger;

    public DepartmentController(ILogger<DepartmentController> logger, IDepartmentRepository repository)
    {
        _logger = logger;
        _repository = repository;
    }

    [HttpGet("[action]/{id}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var response = await _repository.GetByIdAsync(id);
        return Ok(response);
    }
}
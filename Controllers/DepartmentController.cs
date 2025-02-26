using Microsoft.AspNetCore.Mvc;
using RepositoryPatternUoW.Data.Repositories.Interfaces;

namespace RepositoryPatternUoW.Controllers;

public class DepartmentController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    //private readonly IDepartmentRepository _repository;
    private readonly ILogger<DepartmentController> _logger;

    public DepartmentController(ILogger<DepartmentController> logger,/*IDepartmentRepository repository,*/ IUnitOfWork unitOfWork)
    {
        _logger = logger;
        //_repository = repository;
        _unitOfWork = unitOfWork;
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> RegisterAsync(Domain.Department department)
    {
        //await _repository.AddAsync(department);
        await _unitOfWork.DepartmentRepository.AddAsync(department);
        await _unitOfWork.CommitAsync();
        return Ok(department);
    }

    [HttpGet("[action]/{id}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        //var response = await _repository.GetByIdAsync(id);
        var response = await _unitOfWork.DepartmentRepository.GetByIdAsync(id);
        return Ok(response);
    }
}
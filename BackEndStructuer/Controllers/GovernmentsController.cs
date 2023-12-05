using BackEndStructuer.DATA.DTOs;
using BackEndStructuer.DATA.DTOs.Category;
using BackEndStructuer.Entities;
using BackEndStructuer.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackEndStructuer.Controllers;


public class GovernmentsController : BaseController
{
    private readonly IGovernmentService _governmentService;

    public GovernmentsController(IGovernmentService governmentService)
    {
        _governmentService = governmentService;
    }


    [HttpGet]
    public async Task<ActionResult<List<GovernmentDto>>> GetAll([FromQuery] GovernmentFilter filter) => Ok(await _governmentService.GetAll(filter) , filter.PageNumber);

    [HttpPost]
    public async Task<ActionResult<Government>> Create([FromBody] GovernmentForm governmentForm  ) => Ok(await _governmentService.add(governmentForm ));

    [HttpPut("{id}")]
    public async Task<ActionResult<Government>> Update([FromBody] GovernmentFormUpdate governmentFormUpdate, int id) => Ok(await _governmentService.update(governmentFormUpdate,id));

    [HttpDelete("{id}")]
    public async Task<ActionResult<Government>> Delete(int id) => Ok(await _governmentService.delete(id));
    
    
 
}
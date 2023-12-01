using BackEndStructuer.DATA.DTOs;
using BackEndStructuer.DATA.DTOs.Category;
using BackEndStructuer.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackEndStructuer.Controllers;


public class FeaturesController : BaseController
{
    private readonly IFeatureService _featureService;

    public FeaturesController(IFeatureService featureService)
    {
        _featureService = featureService;
    }


    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] BaseFilter filter) => Ok(await _featureService.GetAll(filter.PageNumber) , filter.PageNumber);

    [HttpPost]
    public async Task<IActionResult> Create([FromForm] FeatureForm featureForm  , IFormFile Image) => Ok(await _featureService.add(featureForm , Image));

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromForm] FeatureFormUpdate featureFormUpdate, int id) => Ok(await _featureService.update(featureFormUpdate,id));

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id) => Ok(await _featureService.delete(id));
    
}
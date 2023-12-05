using BackEndStructuer.DATA.DTOs;
using BackEndStructuer.DATA.DTOs.Category;
using BackEndStructuer.Entities;
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
    public async Task<ActionResult<List<FeatureDto>>> GetAll([FromQuery] FeatureFilter filter) => Ok(await _featureService.GetAll(filter) , filter.PageNumber);

    [HttpPost]
    public async Task<ActionResult<Feature>> Create([FromBody] FeatureForm featureForm ) => Ok(await _featureService.add(featureForm));

    [HttpPut("{id}")]
    public async Task<ActionResult<Feature>> Update([FromBody] FeatureFormUpdate featureFormUpdate, int id) => Ok(await _featureService.update(featureFormUpdate,id));

    [HttpDelete("{id}")]
    public async Task<ActionResult<Feature>> Delete(int id) => Ok(await _featureService.delete(id));
    
}
using BackEndStructuer.DATA.DTOs;
using BackEndStructuer.Helpers;
using BackEndStructuer.Properties;
using BackEndStructuer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackEndStructuer.Controllers
{
    
    [ServiceFilter(typeof(AuthorizeActionFilter))]
    public class ArticlesController : BaseController
    {
        private readonly IArticleServices _articleServices;

        public ArticlesController(IArticleServices articleServices)
        {
            _articleServices = articleServices;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] BaseFilter filter)=> Ok(await _articleServices.GetAll(filter.PageNumber),filter.PageSize);
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById()
        {
           
            return Ok("hi");
        }
        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ArticleForm articleForm) => Ok(await _articleServices.add(articleForm));

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] ArticleUpdate articleUpdate, int id)
        {
            var result = await _articleServices.update(articleUpdate, id);
            return Ok(result);
        }
        
        [Authorize]
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _articleServices.Delete(id);
            return Ok(result);
        }
        
    }
}
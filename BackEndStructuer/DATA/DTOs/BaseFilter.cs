using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BackEndStructuer.DATA.DTOs
{
    public class BaseFilter
    {
        
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }


}
using BackEndStructuer.Entities;

namespace BackEndStructuer.DATA.DTOs.Category;

public class FeatureDto
{
    public int Id { get; set; }
    
    public string Name { get; set; }

    private string _image;
    
    public string Image 
    {
        get
        {
            return _image != null?  Utils.Util.Url+'/'+_image.Replace("\\" , "/") : null; }
        set { _image = value; } 
    }
}
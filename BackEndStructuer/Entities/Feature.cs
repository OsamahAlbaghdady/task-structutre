namespace BackEndStructuer.Entities;

public class Feature : BaseEntity<int>
{
    public string? Name { get; set; }
    
    private string? _image;
    
    public string? Image 
    {
        get { return _image == null ? null : Utils.Util.Url+'/'+_image.Replace("\\" , "/") ; }
        set { _image = value; } 
    }
}

namespace BackEndStructuer.Entities;

public class Category : BaseEntity<int>
{
    public string? Name { get; set; }
    
    public ICollection<Storage>? Storages { get; set; }

    private string? _image;
    
    public string? Image 
    {
        get { return _image == null ? null : Utils.Util.Url+'/'+_image.Replace("\\" , "/") ; }
        set { _image = value; } 
    }
}
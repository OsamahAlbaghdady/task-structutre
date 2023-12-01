namespace BackEndStructuer.Entities;

public class StorageFile : BaseEntity<int>
{
    private string? _file;

    public StorageFile(string file)
    {
        _file = file;
    }

    public string? File
    {
        get { return _file == null ? null : Utils.Util.Url+'/'+_file.Replace("\\" , "/") ; }
        set { _file = value; }
    }
}
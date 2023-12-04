
using AutoMapper;
using BackEndStructuer.DATA;
using BackEndStructuer.Interface;
using BackEndStructuer.Interface;

namespace BackEndStructuer.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        private IUserRepository _user;  
        private IArticleRespository _articles;
        private IPermissionRepository _permission;
        private IRoleRepository _role;
        private ICategoryRepository _category;
        private IFeatureRepository _feature;
        private IGovernmentRepository _government;
        private IStorageRepository _storage;
        private IStorageFileRepository _storageFile;
        private IBookMarkRepository _bookMark;

        private IReservedStorage _reservedStorage;


        private IRatingStorageRepository _ratingStorage; 

        
        
        public IRatingStorageRepository RatingStorage {  get {
            if(_ratingStorage == null)
            {
                _ratingStorage = new RatingStorageRepository(_context,_mapper);
            }
            return _ratingStorage;
        } }
        
        public IReservedStorage ReservedStorage {  get {
            if(_reservedStorage == null)
            {
                _reservedStorage = new ReservedStorageRepository(_context,_mapper);
            }
            return _reservedStorage;
        } }


        public IBookMarkRepository BookMark {  get {
            if(_bookMark == null)
            {
                _bookMark = new BookMarkRepository(_context,_mapper);
            }
            return _bookMark;
        } }


        public IStorageFileRepository StorageFile {  get {
            if(_storageFile == null)
            {
                _storageFile = new StorageFileRepository(_context,_mapper);
            }
            return _storageFile;
        } }



        public IStorageRepository Storage {  get {
            if(_storage == null)
            {
                _storage = new StorageRepository(_context,_mapper);
            }
            return _storage;
        } }

        public IGovernmentRepository Government {  get {
                    if(_government == null)
                    {
                        _government = new GovernmentRepository(_context,_mapper);
                    }
                    return _government;
                } }
         
        public IFeatureRepository Feature {  get {
            if(_feature == null)
            {
                _feature = new FeatureRepository(_context,_mapper);
            }
            return _feature;
        } }

        public ICategoryRepository Category {  get {
            if(_category == null)
            {
                _category = new CategoryRepository(_context,_mapper);
            }
            return _category;
        } }


        public IRoleRepository Role {  get {
            if(_role == null)
            {
                _role = new RoleRepository(_context,_mapper);
            }
            return _role;
        } }
        
        public IPermissionRepository Permission {  get {
            if(_permission == null)
            {
                _permission = new PermissionRepository(_context,_mapper);
            }
            return _permission;
        } }


        public IArticleRespository Article {  get {
            if(_articles == null)
            {
                _articles = new ArticleRepository(_context,_mapper);
            }
            return _articles;
        } }

        
        public IUserRepository User {  get {
            if(_user == null)
            {
                _user = new UserRepository(_context,_mapper);
            }
            return _user;
        } }

       

        public RepositoryWrapper(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
    }
}
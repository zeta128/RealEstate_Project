using PropertiesApi.Domain.Entities;
using PropertiesApi.Domain.Interfaces;

namespace PropertiesApi.Infraestructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RealEstateDBContext _realEstateDBContext;
        public IRepository<Property> _propertyRepository { get; private set; }

        public IRepository<OwnerProperty> _ownerPropertyRepository { get; private set; }

        public IRepository<PropertyImage> _propertyImageRepository { get; private set; }

        public IRepository<PropertyTrace> _propertyTraceRepository { get; private set; }

        public UnitOfWork(
            RealEstateDBContext realEstateDBContext,
            IRepository<Property> propertyRepository,
            IRepository<OwnerProperty> ownerPropertyRepository,
            IRepository<PropertyImage> propertyImageRepository,
            IRepository<PropertyTrace> propertyTraceRepository)
        {
            _realEstateDBContext = realEstateDBContext;
            _propertyRepository = propertyRepository;
            _ownerPropertyRepository = ownerPropertyRepository;
            _propertyImageRepository = propertyImageRepository;
            _propertyTraceRepository = propertyTraceRepository;
        }
        public void Dispose()
        {
            _realEstateDBContext.Dispose();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _realEstateDBContext.SaveChangesAsync();
        }
       
    }
}

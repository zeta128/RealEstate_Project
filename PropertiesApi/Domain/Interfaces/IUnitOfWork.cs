using PropertiesApi.Domain.Entities;

namespace PropertiesApi.Domain.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        public IRepository<Property> _propertyRepository { get; }
        public IRepository<OwnerProperty> _ownerPropertyRepository { get; }
        public IRepository<PropertyImage> _propertyImageRepository { get; }
        public IRepository<PropertyTrace> _propertyTraceRepository { get; }

        Task<int> SaveChangesAsync();
    }
}

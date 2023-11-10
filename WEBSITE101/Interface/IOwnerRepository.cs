using WEBSITE101.DTO;

namespace WEBSITE101.Interface
{
    public interface IOwnerRepository
    {
        bool AddOwner(OwnerDto owner);
        OwnerDto GetOwner(int ownerId);
        bool UpdateOwner(OwnerDto owner);
        bool DeleteOwner(int ownerId);
        
        bool OwnerExists(int ownerId);


    }
}

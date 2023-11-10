using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using WEBSITE101.Data;
using WEBSITE101.DTO;
using WEBSITE101.Interface;
using WEBSITE101.Model;

namespace WEBSITE101.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private DataContext _context;
           
            public OwnerRepository(DataContext context)
        {
            _context = context;
        }

        public bool AddOwner(OwnerDto owner)
        {
            Owner owner1 = new Owner()
            {
                FirstName = owner.FirstName,
                LastName = owner.LastName,
                Gym = owner.Gym,
              //  Country = owner.Country,
            };
            _context.Owners.Add(owner1);
            var rowsAffected = _context.SaveChanges();
            if (rowsAffected > 0)
                return true;
            return false;
        }

        public bool DeleteOwner(int ownerId)
        {
            var owner = _context.Owners.Where(x => x.Id == ownerId).FirstOrDefault();
            _context.Remove(owner);
            var rowsAffected = _context.SaveChanges();
            if(rowsAffected > 0) 
                return true;

            return false;
        }

        public OwnerDto GetOwner(int ownerId)
        {
            var owner = _context.Owners.Where(x => x.Id == ownerId).FirstOrDefault();
            OwnerDto ownerObj = new OwnerDto();
            ownerObj.FirstName = owner.FirstName;
            ownerObj.LastName = owner.LastName;
            ownerObj.Country = owner.Country;
            return (ownerObj);
            
        }

        public bool UpdateOwner(OwnerDto owner)
        {

            var data = _context.Owners.Where(x=>x.Id == owner.Id).FirstOrDefault();
            data.FirstName = owner.FirstName;
            data.LastName = owner.LastName;
            data.Country = owner.Country;

            var rowsAffected = _context.SaveChanges();

            if (rowsAffected < 0)
                return false;
            return true;
        
            
        }

        public bool OwnerExists(int ownerId)
        {
            var owner = _context.Owners.Where(x=>x.Id == ownerId).FirstOrDefault();
            if (owner == null)
                return false;
            return true;
        }

  
    }
}

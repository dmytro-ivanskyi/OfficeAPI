using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data.Entities;

namespace WebAPI.Services
{
    public class OfficeService : IOfficeService
    {
        private readonly List<Office> offices;

        public OfficeService()
        {
            offices = new List<Office>();
            for (int i = 0; i < 5; i++)
            {
                offices.Add(new Office 
                { 
                    Id = Guid.NewGuid(), 
                    Name = "office" + i 
                });
            }
        }
        public Office GetOfficeById(Guid officeId)
        {
            return offices.SingleOrDefault(x => x.Id == officeId);
        }

        public List<Office> GetOffices()
        {
            return offices;
        }

        public bool UpdateOffice(Office officeToUpdate)
        {
            var exists = GetOfficeById(officeToUpdate.Id) != null;

            if (!exists)
                return false;

            int index = offices.FindIndex(x => x.Id == officeToUpdate.Id);
            offices[index] = officeToUpdate;

            return true;
        }

        public bool DeleteOffice(Guid officeId)
        {
            var office = GetOfficeById(officeId);

            if (office == null)
                return false;

            offices.Remove(office);

            return true;
        }
    }
}

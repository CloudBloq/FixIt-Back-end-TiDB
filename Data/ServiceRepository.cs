
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using fixit.Models;


namespace fixit.Data
{
    public class ServiceRepository : IRepository<Service>
    {
        private readonly DataContext _context;
        public ServiceRepository(DataContext context)
        {
            _context = context;
        }
        // Delete Service objects
        public async Task<bool> DeleteData(Service service)
        {
            Console.WriteLine("Delete method invoked");
            _context.Service.Remove(service);
            await _context.SaveChangesAsync();
            return true;
        }


        // Get all service objects
        public async Task<List<Service>> GetData()
        {
            //    Getting database data here
            var model = await _context.Service.ToListAsync();
            return model;

        }
        // Get Service by  id
        public async Task<Service> GetDataById(int id)
        {
            return await _context.Service.FirstOrDefaultAsync(x => x.ServiceId == id);
        }


        // 
        // Get data by constraint
        //  public async Task<Service> GetDataByConstraint(int pageNumber,string orderBy,string search)
            // {
                // console.WriteLine("These are the comming constrants");
                // console.WriteLine(pageNumber);
                // console.WriteLine(orderBy);
                // console.WriteLine(search);
                // if(search ==''){
                    // There will not be search in this case
                // }else{
                    // There will be search call
                    // 
                // }

                // return await _context.Service.FirstOrDefaultAsync(x => x.ServiceId == id);
            // }
        // 

        public Task<Service> PutJob(Service job)
        {
            throw new NotImplementedException();
        }

        // Update and crete new service objects
        public async Task<Service> InsertData(Service service)
        {

            Console.WriteLine("Create data  method invoked");
            _context.Service.Add(service);

            await _context.SaveChangesAsync();
            return service;
        }

        public async Task<Service> UpdateData(Service service)
        {




            Console.WriteLine("Update method  invoked");



            _context.Update(service).Property(x => x.ServiceId).IsModified = false;
            _context.SaveChanges();












            // _context.Service.Add(service);
            // 
            // _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Fixit_DB.Service ON;");
            // await _context.SaveChangesAsync();
            // _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Fixit_DB.Service OFF");
            return service;
        }
    }
}
using Microsoft.EntityFrameworkCore;
using WebApiCodingTest.Data.Models;

namespace WebApiCodingTest.Data.BL
{
    public interface IAddOperationsBL
    {
        Task<AddOperations> AddAsync(AddOperations addOperation);
    }

    public class AddOperationsBL : IAddOperationsBL
    {
        private readonly AppDbContext context;

        public AddOperationsBL(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<AddOperations> AddAsync(AddOperations addOperation)
        {
            context.AddOperations.Add(addOperation);
            await context.SaveChangesAsync();
            return addOperation;
        }

    }
}

using Microsoft.EntityFrameworkCore;
using RESTfulBookingAPI.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RESTfulBookingAPI.Models
{
    public class GUIDRepository<entity> : IRepository<entity> where entity : class
    {
        protected readonly BookingContext Context;
        DbSet<entity> Table { get; set; }

        public GUIDRepository(BookingContext context)
        {
            Table = context.Set<entity>();
            Context = context;
        }

        /// <summary>
        /// This Method Support Async Method For Add Entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task Add(entity entity) => await Table.AddAsync(entity);


        /// <summary>
        /// This Method For Delete  Entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public void Delete(entity entity) => Table.Remove(entity);


        /// <summary>
        /// This Method For Update  Entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public void Update(entity entity) => Table.Update(entity);


        /// <summary>
        /// This Method Support Async Method For Get All form Entity
        /// and NoTracking 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<entity>> All() => await Table.AsNoTracking().ToArrayAsync();

        /// <summary>
        /// This Method Support Async Method For Get One Entity Call a FindAsync Method
        /// </summary>
        /// <returns></returns>
        public async Task<entity> GetId(int Id) => await Table.FindAsync(Id);

        /// <summary>
        /// This Method For Search By Expression by Entity
        /// </summary>
        /// <param name="expression"></param>
        /// <returns>Boolean</returns>
        public IQueryable<entity> Where(Expression<Func<entity, bool>> expression) => Table.Where<entity>(expression);

    }
}

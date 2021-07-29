using Microsoft.EntityFrameworkCore;
using RESTfulBookingAPI.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RESTfulBookingAPI.Models
{
    public class GUIDRepository<T> : IRepository<T> where T : class
    {
        protected readonly BookingContext Context;
        DbSet<T> Table { get; set; }

        public GUIDRepository(BookingContext context)
        {
            Table = context.Set<T>();
            Context = context;
        }

        /// <summary>
        /// This Method Support Async Method For Add Entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task Add(T entity) => await Table.AddAsync(entity);


        /// <summary>
        /// This Method For Delete  Entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public void Delete(T entity) => Table.Remove(entity);


        /// <summary>
        /// This Method For Update  Entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public void Update(T entity) => Table.Update(entity);


        /// <summary>
        /// This Method Support Async Method For Get All form Entity
        /// and NoTracking 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<T>> All() => await Table.AsNoTracking().ToArrayAsync();

        /// <summary>
        /// This Method Support Async Method For Get One Entity Call a FindAsync Method
        /// </summary>
        /// <returns></returns>
        public async Task<T> GetId(int Id) => await Table.FindAsync(Id);

        /// <summary>
        /// This Method For Search By Expression by Entity
        /// </summary>
        /// <param name="expression"></param>
        /// <returns>Boolean</returns>
        public IQueryable<T> Where(Expression<Func<T, bool>> expression) => Table.Where<T>(expression);

    }
}

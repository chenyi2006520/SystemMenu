using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace SystemMenuSample
{
    public class SystemMenuDbContext : DbContext
    {
        public SystemMenuDbContext()
        {
        }
         
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseMySql(@"server=localhost;port=3306;database=qygame;user id=root;password=123456;");

        /// <summary>
        /// 数据字典
        /// </summary>
        public DbSet<SystemMenuEntity> SystemMenus { get; set; }
    }
}

using DB.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Context {
	public partial class AppDbContext {
		public DbSet<Button> Buttons { get; set; }
	}
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Context {
	public partial class AppDbContext {
		protected override void OnModelCreating(ModelBuilder builder) {
			base.OnModelCreating(builder);
		}
	}
}

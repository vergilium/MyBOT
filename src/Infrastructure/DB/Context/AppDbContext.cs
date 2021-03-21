﻿using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace DB.Context {
	public partial class AppDbContext : ApiAuthorizationDbContext<IdentityUser> {
		public AppDbContext(
			DbContextOptions options, 
			IOptions<OperationalStoreOptions> operationalStoreOptions
			):base(options, operationalStoreOptions) {}
	}
}

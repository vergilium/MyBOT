using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyBOT.Middleware.Session;

namespace MyBOT {

	public class Test {
		public int id{ get; set; }
		public List<int> arr = new List<int>() {1, 2, 3, 4, 5};
	}
	public class Program {
		public static void Main(string[] args) {
			CreateHostBuilder(args).Build().Run();
		}
		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder => {
					webBuilder.UseStartup<Startup>();
				});
	}
}

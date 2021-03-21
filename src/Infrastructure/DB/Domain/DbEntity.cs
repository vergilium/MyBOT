﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Domain {
	public class DbEntity : IDbEntity {
		[Key]
		[Column("id")]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid Id { get; set; }
	}
}

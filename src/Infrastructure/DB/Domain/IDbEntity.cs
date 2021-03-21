using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Domain {
	public interface IDbEntity {
		[Key]
		[Column("id")]
		Guid Id { get; set; }
	}
}

﻿using System;
using System.Collections.Generic;

namespace Models.Db.Entities
{
	public partial class FilmCategory
	{
		public short FilmId { get; set; }
		public byte CategoryId { get; set; }
		public DateTimeOffset LastUpdate { get; set; }

		public virtual Category Category { get; set; }
		public virtual Film Film { get; set; }
	}
}

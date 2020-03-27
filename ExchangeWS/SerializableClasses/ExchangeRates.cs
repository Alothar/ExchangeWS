using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace ExchangeWS.SerializableClasses
{
	public class ExchangeRates
	{
		public string table { get; set; }
		public string currency { get; set; }
		public string code { get; set; }
		public List<Rate> rates { get; set; }
	}

	public class Rate
	{
		public string no { get; set; }
		public string effectiveDate { get; set; }
		public double mid { get; set; }
	}
}
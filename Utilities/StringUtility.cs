using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeacherWork.Utilities
{
	public static class StringUtility
	{
		public static int ParsePeriod(string pstr)
		{
			int period = 0;
			try
			{
				period = int.Parse(pstr);
			}
			catch (FormatException)
			{
				Regex regex = new Regex(@"^(?<weeks>\d+)周$");
				if(regex.IsMatch(pstr))
				{
					Match matchWeeks = regex.Match(pstr);
					period = int.Parse(matchWeeks.Groups["weeks"].Value) * 5 * 8;
				}
			}
			catch (Exception)
			{
				period = 0;
			}
			return period;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using NHibernate.Engine;
using NHibernate.SqlTypes;
using NHibernate.UserTypes;

namespace NHibernate.Type
{
	/// <summary>
	/// Maps the Year, Month, and Day of a <see cref="System.DateTime"/> Property to a 
	/// <see cref="DbType.Date"/> column
	/// </summary>
	[Serializable]
	public class DateType : PrimitiveType, IIdentifierType, ILiteralType, IParameterizedType
	{
		private static readonly IInternalLogger _log = LoggerProvider.LoggerFor(typeof(DateType));
		// Since v5.0
		[Obsolete("Explicitly affect your values to your entities properties instead.")]
		public const string BaseValueParameterName = "BaseValue";
		// Since v5.0
		[Obsolete("Use DateTime.MinValue.")]
		public static readonly DateTime BaseDateValue = _baseDateValue;
		private DateTime customBaseDate = _baseDateValue;

		private static readonly DateTime _baseDateValue = DateTime.MinValue;

		/// <summary></summary>
		public DateType() : base(SqlTypeFactory.Date)
		{
		}

		/// <summary></summary>
		public override string Name
		{
			get { return "Date"; }
		}

		public override object Get(DbDataReader rs, int index, ISessionImplementor session)
		{
			try
			{
				DateTime dbValue = Convert.ToDateTime(rs[index]);
				return dbValue.Date;
			}
			catch (Exception ex)
			{
				throw new FormatException(string.Format("Input string '{0}' was not in the correct format.", rs[index]), ex);
			}
		}

		public override object Get(DbDataReader rs, string name, ISessionImplementor session)
		{
			return Get(rs, rs.GetOrdinal(name), session);
		}

		public override System.Type ReturnedClass
		{
			get { return typeof(DateTime); }
		}

		public override void Set(DbCommand st, object value, int index, ISessionImplementor session)
		{
			var parm = st.Parameters[index];
			var dateTime = (DateTime)value;
			parm.Value = dateTime.Date;
		}

		public override bool IsEqual(object x, object y)
		{
			if (x == y)
			{
				return true;
			}
			if (x == null || y == null)
			{
				return false;
			}

			DateTime date1 = (DateTime)x;
			DateTime date2 = (DateTime)y;
			if (date1.Equals(date2))
				return true;

			return date1.Day == date2.Day
						 && date1.Month == date2.Month
						 && date1.Year == date2.Year;
		}

		public override int GetHashCode(object x)
		{
			DateTime date = (DateTime)x;
			int hashCode = 1;
			unchecked
			{
				hashCode = 31 * hashCode + date.Day;
				hashCode = 31 * hashCode + date.Month;
				hashCode = 31 * hashCode + date.Year;
			}
			return hashCode;
		}

		public override string ToString(object val)
		{
			return ((DateTime) val).ToShortDateString();
		}

		public override object FromStringValue(string xml)
		{
			return DateTime.Parse(xml);
		}

		public object StringToObject(string xml)
		{
			return string.IsNullOrEmpty(xml) ? null : FromStringValue(xml);
		}

		public override System.Type PrimitiveClass
		{
			get { return typeof(DateTime); }
		}

		public override object DefaultValue
		{
			get { return customBaseDate; }
		}

		public override string ObjectToSQLString(object value, Dialect.Dialect dialect)
		{
			return "\'" + ((DateTime)value).ToShortDateString() + "\'";
		}

		// Since v5
		[Obsolete("Its only parameter, BaseValue, is obsolete.")]
		public void SetParameterValues(IDictionary<string, string> parameters)
		{
			if(parameters == null)
			{
				return;
			}
			string value;
			if (parameters.TryGetValue(BaseValueParameterName, out value))
			{
				_log.WarnFormat(
					"Parameter {0} is obsolete and will be remove in a future version. Explicitly affect your values to your entities properties instead.",
					BaseValueParameterName);
				customBaseDate = DateTime.Parse(value);
			}
		}
	}
}

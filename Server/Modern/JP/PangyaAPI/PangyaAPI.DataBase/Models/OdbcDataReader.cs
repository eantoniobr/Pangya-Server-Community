using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Text;

namespace PangyaAPI.DataBase.Models
{
    public sealed class OdbcDataReaderEx : IDisposable
    {
        private readonly OdbcDataReader _reader;

        public OdbcDataReaderEx(OdbcDataReader reader)
        {
            _reader = reader ?? throw new ArgumentNullException(nameof(reader));
        }

        public int FieldCount => _reader.FieldCount;

        public bool Read() => _reader.Read();

        public string GetName(int i) => _reader.GetName(i);

        public object GetSafeValue(int i)
        {
            if (_reader.GetDataTypeName(i) == null)
            {
                if (_reader.GetValue(i) != null)
                    return _reader.GetValue(i);
                else if (_reader.GetValue(i) == null)
                    return DBNull.Value;
            }

            string sqlType;

            try
            {
                sqlType = _reader.GetDataTypeName(i);
            }
            catch
            {
                return DBNull.Value;
            }


            if (sqlType.Equals("timestamp", StringComparison.OrdinalIgnoreCase))
            {
                return _reader.GetString(i);
            }

            if (sqlType.Equals("time", StringComparison.OrdinalIgnoreCase))
            {
                try
                {
                    return TimeSpan.Parse(_reader.GetString(i));
                }
                catch
                {
                    return DBNull.Value;
                }
            }

            // datetimeoffset costuma dar dor também
            if (sqlType.Equals("datetimeoffset", StringComparison.OrdinalIgnoreCase))
            {
                try
                {
                    return DateTimeOffset.Parse(_reader.GetString(i));
                }
                catch
                {
                    return DBNull.Value;
                }
            }

            try
            {
                return _reader.GetValue(i);
            }
            catch
            {
                try
                {
                    return _reader.GetString(i);
                }
                catch
                {
                    return DBNull.Value;
                }
            }
        }

        public void Dispose()
        {
            _reader?.Dispose();
        }
    }
}

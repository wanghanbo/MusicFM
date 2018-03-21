using DevExpress.Data.Filtering;
using DevExpress.Xpo;
using MusicFM.Module.BusinessObjects.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicFM.Module.Methods
{
    public static class DBKeyValueHelper
    {
        public static void SetValue(Session ss, string key, string val)
        {
            KeyValue kv = ss.FindObject<KeyValue>(CriteriaOperator.Parse(String.Format("Key = '{0}'", key)));

            if (kv != null)
            {
                kv.Value = val;
                kv.Save();
            }
            else
            {
                kv = new KeyValue(ss)
                {
                    Key = key,
                    Value = val
                };
                kv.Save();
            }

            ss.CommitTransaction();
        }

        public static string GetValue(Session ss, string key)
        {
            KeyValue kv = ss.FindObject<KeyValue>(CriteriaOperator.Parse(String.Format("Key == '{0}'", key)));

            if (kv != null) return kv.Value;

            return null;
        }
    }
}

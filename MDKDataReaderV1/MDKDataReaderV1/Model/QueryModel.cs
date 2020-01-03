using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MDKDataReaderV1.Model
{
    public class QueryModel
    {
        public QueryModel()
        {
            CheckType = new List<string>();
        }
        public List<string> CheckType { set; get; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleWebAPI.BLL.Generic;
using SimpleWebAPI.Entities;

namespace SimpleWebAPI.BLL
{
    public class ValuesBusiness : GenericBusiness<Values>
    {
        public IEnumerable<Values> ValuesByValue(string value)
        {
            string query = @"SELECT c.id,c.value
                              FROM dbo.Values c
                              where c.value = @value";
            IList<Values> values = this.FindQuery(query, value).ToList();
            
            return values;
        }
    }
}

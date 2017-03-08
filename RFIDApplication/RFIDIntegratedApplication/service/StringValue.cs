using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFIDIntegratedApplication.service
{
    public class StringValue : System.Attribute
    {
        private string _value;
        public StringValue(string value)
        {
            this._value = value;
        }

        public string Value
        {
            get { return _value; }
        }

    }
}

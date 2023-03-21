using System;
using System.Collections.Generic;
using System.Text;

namespace SDETAPI_CSharp.Features.NasaOpenAPI
{
    public class Response
    {
        private string _url;
        private string _explanation;
        private string _copyright;
        private string _date;

        public string url
        {
            get
            {
                return _url;
            }
            set
            {
                _url = value;
            }
        }
        public string explanation
        {
            get { return _explanation; }
            set
            {
                _explanation = value;

            }
        }

        public string copyright
        {
            get { return _copyright; }
            set
            {
                _copyright = value;

            }
        }
        public string date
        {
            get { return _date; }
            set
            {
                _date = value;

            }
        }

    }
}

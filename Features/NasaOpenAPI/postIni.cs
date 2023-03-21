using System;
using System.Collections.Generic;
using System.Text;

namespace SDETAPI_CSharp.Features.NasaOpenAPI
{
    public class postIni
    {
        private int _id;
        private string _name;
        private string _lastName;
        public int id 
        { 
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            } 
        }
        public string name 
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public string lastName 
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
            }
        }

    }
}

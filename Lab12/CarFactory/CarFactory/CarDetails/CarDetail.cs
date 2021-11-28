using System;
using System.Collections.Generic;
using System.Text;

namespace CarFactory
{
    public abstract class CarDetail
    {
        protected string _model;
        public string Model
        {
            get
            {
                return _model;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace km.client
{
    abstract class KmDataobject
    {
        protected KmConnection con;

        public KmDataobject(KmConnection con)
        {
            this.con = con;
        }


        public abstract void load();
    }
}

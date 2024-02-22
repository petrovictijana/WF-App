using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekat
{
    public class CustomDeleteButton : Button
    {
        public int packageId;
        public CustomDeleteButton(int packageId) : base(){ 
            this.packageId = packageId;
        }
    }
}

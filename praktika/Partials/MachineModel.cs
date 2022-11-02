using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace praktika
{
    public partial class MachineModel
    {
        public static MachineModel machineModel;
        public static MachineModel GetContext()
        {
            if(machineModel == null)
                machineModel = new MachineModel();
            return machineModel;
        }
    }
}

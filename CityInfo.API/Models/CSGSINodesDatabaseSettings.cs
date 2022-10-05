using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSGSI_FrontEnd.Models
{

        public class CSGSINodesDatabaseSettings :
    ICSGSINodesDatabaseSettings
        {
            public string CSGSICollectionName { get; set; }
            public string ConnectionString { get; set; }
            public string DatabaseName { get; set; }
        }

        public class ICSGSINodesDatabaseSettings
        {
            public string CSGSICollectionName { get; set; }
            public string ConnectionString { get; set; }
            public string DatabaseName { get; set; }
        }
  
}

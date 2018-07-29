using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everlight.POM.Model
{
    public class ComputerDetail
    {
        public string ComputerName { get; private set; }
        public string Introduced { get; private set; }
        public string Discontinued { get; private set; }
        public string Company { get; private set; }

        public ComputerDetail(string computerName, string introduced, string discontinued, string company)
        {
            this.ComputerName = computerName;
            this.Introduced = introduced;
            this.Discontinued = discontinued;
            this.Company = company;
        }
    }
}

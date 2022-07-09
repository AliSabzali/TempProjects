using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebServiceTest
{
    [WebService]
    public class ship : System.Web.Services.WebService
    {

        [WebMethod]
        public Input[] HelloWorld(Input[] data)
        {
            foreach (var item in data)
            {
                item.Number++;
                item.FirstName = item.FirstName?.ToUpper();
                item.LastName = item.LastName?.ToUpper();
            }
            return data;
        }

        [WebMethod]
        public Input2[] HelloWorld2(Input2[] data)
        {
            foreach (var item in data)
            {
                item.Number += 10;
                item.FirstName = item.FirstName.ToLower();
                item.LastName = item.LastName.ToLower();
                item.ID = Guid.NewGuid();
                item._count *= 3;
            }
            return data;
        }
    }

    public class Input
    {
        public int Number { get; set; }
        public string FirstName;
        public string LastName { get; set; }
    }

    public class Input2
    {
        internal int _count = 45;
        public int Count { get { return _count; } set{ } }
        public bool ISOk { get; set; } = false;
        public string FirstName { get; set; }
        public string FullName { get { return $"{FirstName} {LastName}"; } set { } }
        public int Number { get; set; }
        internal Guid ID { get; set; }
        public string LastName { get; set; }
    }
}

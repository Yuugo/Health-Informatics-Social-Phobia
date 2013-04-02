using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NijnCoach.XMLclasses
{
    public class MCQuestion : Entry
    {
        String value { get; set; }
        List<Option> options { get; set; }
        Answer theAnswer { get; set; }
    }
}

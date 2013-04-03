﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace NijnCoach.XMLclasses
{
    class Comment
    {
        [XmlAttribute("value")]
        String value { get; set; }

        [XmlAttribute("emotion")]
        String emotion { get; set; }
    }
}

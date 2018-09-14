using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    [ProtoContract]
    public class Chart
    {
        [ProtoMember(1)]
        public string ChartName { get; set; }

        [ProtoMember(2)]
        public List<Point> Points { get; set; }
    }

    [ProtoContract]
    public class Point
    {
        [ProtoMember(1)]
        public DateTime PointTime { get; set; }

        [ProtoMember(2)]
        public int TotalNum { get; set; }
    }
}

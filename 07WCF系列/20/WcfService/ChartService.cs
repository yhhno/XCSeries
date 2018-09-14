using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.MsmqIntegration;
using System.Text;
using Lib;

namespace WcfService
{
    public class ChartService : IChartService
    {
        public Chart DoWork(string msg)
        {
            var chart = new Chart()
            {
                ChartName = "总交易人数报表",
                Points = Enumerable.Repeat(1, 1000).Select(m => new Point()
                {
                    PointTime = DateTime.Now.AddDays(-m),
                    TotalNum = m
                }).ToList()
            };

            return chart;
        }
    }
}

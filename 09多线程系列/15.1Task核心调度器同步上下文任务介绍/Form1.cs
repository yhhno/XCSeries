using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _15._1Task核心调度器同步上下文任务介绍
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Task task = new Task(() =>//新开的工作线程.
            //{
            //    try
            //    {
            //        label1.Text = "你好";//工作线程操作label1, 非ui线程
            //        MessageBox.Show(TaskScheduler.Current.ToString()); //方法体内的TaskScheduler为SynchronizationContextScheduler
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //});//此时的task相当于 invoke,会进入队列排队,ui线程会获取,并执行, 如果task是一个耗时任务,ui照样被卡死.友好性就不好

            //task.Start(TaskScheduler.FromCurrentSynchronizationContext());//此时要使用同步上下文的TaskScheduler
            //MessageBox.Show(TaskScheduler.Current.ToString());//方法体外的TaskScheduler为ThreadPoolScheduler



            //更友好的做法, 避免之前的invoke做法. 这样更好编码,友好性更好.
            var task = Task.Factory.StartNew(() =>
            {
                //模拟耗时操作
                Thread.Sleep(1000 * 10);
            });////耗时的操作我们要放到threadpool
            task.ContinueWith(t =>
            {
                label1.Text = "你好";
            }, TaskScheduler.FromCurrentSynchronizationContext());//更新操作放到同步上下文中

        }
    }
}

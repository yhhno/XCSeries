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

namespace _02._1Thread实例方法介绍之生命周期管理的Start_Suspend_Resume_Join_Interrupt_Abort五大方法介绍
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Thread thread = null;
        int index = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            thread = new Thread(new ThreadStart(() => {
                while (true)
                {
                    try
                    {
                        //定时的效果(结合一个线程和Thread.Sleep)
                        Thread.Sleep(1000);
                        textBox1.Invoke(new Action(() =>
                        {
                            textBox1.AppendText(string.Format("{0},", index++));
                        }));
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(string.Format("{0} ,{1}", ex.Message, index));
                    }
                    finally
                    {
                        ////定时的效果(结合一个线程和Thread.Sleep)
                        //Thread.Sleep(1000);
                    }
                }
            }));
            thread.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //这个方法是弃用的,也就是说你可以用,但不建议你用
            //逻辑严谨性
            //只有在线程运行时和线程休眠的时候,才可以挂起.
            if(thread.ThreadState==ThreadState.Running||thread.ThreadState==ThreadState.WaitSleepJoin)
            {
                thread.Suspend();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(thread.ThreadState==ThreadState.Suspended)
            thread.Resume();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            thread.Interrupt();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            thread.Abort();
        }
    }
}

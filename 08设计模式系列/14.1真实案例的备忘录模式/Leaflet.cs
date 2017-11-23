using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication22
{
    public class Leaflet
    {
        public List<int> CustomerList
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public int LeafletID
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public int SendType
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public int ExecuteTime
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public Memento CreateMemento()
        {
            Memento memento = new Memento()
            {
                CustomerList = this.CustomerList,
                LeafletID = this.LeafletID
            };

            return memento;
        }

        public void RecoveryMemento()
        {
            throw new System.NotImplementedException();
        }
    }
}
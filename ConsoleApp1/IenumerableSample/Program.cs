using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace IenumerableSample
{
    class Hardware { }

    class Usb
    {
        string name;

        public Usb(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return name;
        }
    }

    class Notebook : Hardware, IEnumerable
    {
        Usb[] usbList = new Usb[] { new Usb("USB1"), new Usb("USB2") };

        public IEnumerator GetEnumerator()
        {
            return new UsbEnumerator(usbList);
        }
    }

    class UsbEnumerator : IEnumerator
    {
        int pos = -1;
        int length = 0;
        object[] list;

        public UsbEnumerator(Usb[] usb)
        {
            list = usb;
            length = list.Length;
        }

        public object Current
        {
            get
            {
                return list[pos];
            }
        }

        public bool MoveNext()
        {
            if(pos >= length - 1)
            {
                return false;
            }

            pos++;
            return true;
        }

        public void Reset()
        {
            pos = -1;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Notebook notebook = new Notebook();
            foreach(var item in notebook)
            {
                Console.WriteLine(item);
            }
        }
    }
}

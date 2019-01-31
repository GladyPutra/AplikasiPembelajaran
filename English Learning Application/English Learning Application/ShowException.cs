using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace English_Learning_Application
{
    class ShowException
    {
        public ShowException() { }
        public void ShowMessage(string message, string type)
        {
            string[] temp = message.Split((char)13);
            MessageBox.Show(temp[0], type);
        }

       /* public void pilihCustomer()
        {
            MessageBox.Show("Silahkan Pilih Customer", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void notFound()
        {
            MessageBox.Show("Data Yang Dicari Tidak Ditemukan", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }*/
    }
}

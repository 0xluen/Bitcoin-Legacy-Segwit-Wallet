using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NBitcoin;
using NBitcoin.Crypto;
using NBitcoin.DataEncoders;

namespace BTC_Wallet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

      
        List<Key> keys = new List<Key>();
        public int walletCount = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            var key = new Key();
            keys.Add(key);
            listBox1.Items.Add(keys[walletCount].GetAddress(ScriptPubKeyType.Segwit, Network.Main).ToString());
            MessageBox.Show(keys[walletCount].GetAddress(ScriptPubKeyType.Segwit, Network.Main).ToString());
            walletCount++;

            if (walletCount == 1)
            {
                listBox1.SelectedIndex = 0;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        string legacy;
        string taproot;
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bitcoinAddress = keys[listBox1.SelectedIndex].GetAddress(ScriptPubKeyType.Legacy, Network.Main).ToString();
            label10.Text = bitcoinAddress.Substring(0, Math.Min(bitcoinAddress.Length, 22)) + "...";
            legacy = bitcoinAddress;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            var privateKey = keys[listBox1.SelectedIndex].GetBitcoinSecret(Network.Main).ToString();
            Clipboard.SetText(privateKey);
            MessageBox.Show("Secret key : " + privateKey);
            MessageBox.Show("Copy To Clipboard !");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(legacy);
            MessageBox.Show("Copy To Clipboard !");
        }
    }
}

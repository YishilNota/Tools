using MessagingToolkit.QRCode.Codec;
using MessagingToolkit.QRCode.Codec.Data;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TENLEON.CHAT
{
    /// <summary>
    /// Interaction logic for FrameScanQR.xaml
    /// </summary>
    public partial class FrameScanQR : System.Windows.Controls.UserControl
    {

        QRCodeDecoder decoder = new QRCodeDecoder();
        OpenFileDialog openFile = new OpenFileDialog();

        public FrameScanQR()
        {
            InitializeComponent();
        }

        private void btnScanQR_Click(object sender, RoutedEventArgs e)
        {
            if (openFile.ShowDialog() == true)
            {
                imgQR.Source = new BitmapImage(new Uri(openFile.FileName));
                textQR.Text = decoder.Decode(new QRCodeBitmapImage(new Bitmap(openFile.FileName)));
            }
        }
    }
}

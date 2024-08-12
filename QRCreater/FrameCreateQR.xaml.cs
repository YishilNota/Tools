using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Controls;
using MessagingToolkit.QRCode;
using MessagingToolkit.QRCode.Codec;
using Microsoft.Win32;
using static System.Net.Mime.MediaTypeNames;

namespace TENLEON.CHAT
{
    /// <summary>
    /// Interaction logic for FrameCreateQR.xaml
    /// </summary>
    public partial class FrameCreateQR : System.Windows.Controls.UserControl
    {
        QRCodeEncoder encoder  = new QRCodeEncoder();
        Bitmap? bitmap;
        SaveFileDialog saveFile = new SaveFileDialog();
        
        public FrameCreateQR()
        {
            InitializeComponent();
            encoder.QRCodeScale = 8;
            encoder.CharacterSet = "UTF-8";
        }

        private void btnCreateQR_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            textHint.Visibility = System.Windows.Visibility.Hidden;
            try
            {
                bitmap = encoder.Encode(textQR.Text.Trim());
                imgQR.Source = bitmap.ToBitmapImage();
            }
            catch (Exception)
            {
                textHint.Visibility = System.Windows.Visibility.Visible;
            }
            
        }

        private void btnSaveQR_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            textHint.Visibility = System.Windows.Visibility.Hidden;
            if (imgQR.Source == null) return;  
            saveFile.Filter = "PNG|*.png";
            saveFile.FileName = textQR.Text;
            if (saveFile.ShowDialog() == true)
            {
                if(bitmap != null)
                {
                    string fullFileName = saveFile.FileName.EndsWith(".png") ? saveFile.FileName
                        : string.Concat(saveFile.FileName, ".png");
                    bitmap.Save(fullFileName, ImageFormat.Png);

                }
            }
        }

        private void textQR_TextChanged(object sender, TextChangedEventArgs e)
        {
            textHint.Visibility = System.Windows.Visibility.Hidden;
        }
    }
}

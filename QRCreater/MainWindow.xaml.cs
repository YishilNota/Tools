using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace TENLEON.CHAT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void ListView_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            int index = ListViewMenu.SelectedIndex;
            MoveCursor(index);
            switch (index) 
            { 
                case 0:
                    GridContent.Children.Clear();
                    GridContent.Children.Add(new FrameCreateQR());
                    break;

                case 1:
                    GridContent.Children.Clear();
                    GridContent.Children.Add(new FrameScanQR());   
                    break; 
            }
        }


        private void MoveCursor(int index)
        {
            TransitioningContentSlide.OnApplyTemplate();
            TransitionGrid.Margin = new Thickness(0, index * 60 + 70, 0, 0);
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            GridContent.Children.Clear();
            GridContent.Children.Add(new FrameCreateQR());
        }

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {

            string url = "https://github.com/YishilNota";
            Process.Start(new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
        }
    }
}
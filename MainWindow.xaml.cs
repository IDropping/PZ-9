using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace Kraski
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            mcolor = new ColorRGB();
            mcolor.red = 0;
            mcolor.green = 0;
            mcolor.blue = 0;
            this.lbl1.Background = new SolidColorBrush(Color.FromRgb(mcolor.red, mcolor.green, mcolor.blue));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.inkCanvas1.Strokes.Clear();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        public class ColorRGB
        {
            public byte red { get; set; }
            public byte green { get; set; }
            public byte blue { get; set; }
        }
        public ColorRGB mcolor { get; set; }
        public Color clr { get; set; }

        private void sld_Color_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var slider = sender as Slider;
            string crlName = slider.Name; 
            double value = slider.Value; 
            if (crlName.Equals("sld_RedColor"))
            {
                mcolor.red = Convert.ToByte(value);
            }
            if (crlName.Equals("sld_GreenColor"))
            {
                mcolor.green = Convert.ToByte(value);
            }
            if (crlName.Equals("sld_BlueColor"))
            {
                mcolor.blue = Convert.ToByte(value);
            }
 
            clr = Color.FromRgb(mcolor.red, mcolor.green, mcolor.blue);
            this.lbl1.Background = new SolidColorBrush(Color.FromRgb(mcolor.red, mcolor.green, mcolor.blue));
            this.inkCanvas1.DefaultDrawingAttributes.Color = clr;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                lbl1.Background = new SolidColorBrush(Color.FromRgb(dialog.Color.R, dialog.Color.G, dialog.Color.B));
            }
            clr = Color.FromRgb(dialog.Color.R, dialog.Color.G, dialog.Color.B);
           
            this.inkCanvas1.DefaultDrawingAttributes.Color = clr; 
        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            this.inkCanvas1.DefaultDrawingAttributes.Width = 15;
            this.inkCanvas1.DefaultDrawingAttributes.Height = 15;
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            this.inkCanvas1.DefaultDrawingAttributes.Width = 10;
            this.inkCanvas1.DefaultDrawingAttributes.Height = 10;
        }

        private void RadioButton_Checked_3(object sender, RoutedEventArgs e)
        {
            this.inkCanvas1.DefaultDrawingAttributes.Width = 20;
            this.inkCanvas1.DefaultDrawingAttributes.Height = 20;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            this.inkCanvas1.DefaultDrawingAttributes.Width = 1;
            this.inkCanvas1.DefaultDrawingAttributes.Height = 1;
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            this.inkCanvas1.Strokes.Clear();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.inkCanvas1.EditingMode = InkCanvasEditingMode.None;
            string imgPath = @"D:\file.png";
            MemoryStream ms = new MemoryStream();
            FileStream fs = new FileStream(imgPath, FileMode.Create);

            //rtb - объект класса RenderTargetBitmap
            RenderTargetBitmap rtb = new RenderTargetBitmap((int)inkCanvas1.Width, (int)inkCanvas1.Height, 96, 96, PixelFormats.Default);
            rtb.Render(inkCanvas1);

            GifBitmapEncoder gifEnc = new GifBitmapEncoder();
            gifEnc.Frames.Add(BitmapFrame.Create(rtb));
            gifEnc.Save(fs);
            fs.Close();
            this.inkCanvas1.EditingMode = InkCanvasEditingMode.Ink;
        }



        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            this.inkCanvas1.DefaultDrawingAttributes.Width = 5;
            this.inkCanvas1.DefaultDrawingAttributes.Height = 5;
            this.lbl1.Background = new SolidColorBrush(Color.FromRgb(mcolor.red, mcolor.green, mcolor.blue));
            this.inkCanvas1.DefaultDrawingAttributes.Color = clr;
        }
    }
}

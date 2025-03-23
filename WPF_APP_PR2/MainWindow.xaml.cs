using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WPF_APP_PR2;


public partial class MainWindow : Window
{
    private double angle1 = 0;
    private double angle2 = 0;
    private double angle2Circle = 0;
    private DispatcherTimer timer;

    public MainWindow()
    {
        InitializeComponent();
        timer = new DispatcherTimer();
        timer.Interval = TimeSpan.FromMilliseconds(30); // iнтервал 
        timer.Tick += Timer_Tick;
    }

    private void Timer_Tick(object sender, EventArgs e)
    {
        double plane1Y = 0.5 * Math.Sin(angle1 * Math.PI / 180); // рух по синусоїді
        Plane1Translate.OffsetY = plane1Y; // оновлення позиції літака 
        angle1 += 5;

        double plane2X = 2 * Math.Cos(angle2Circle * Math.PI / 180); // x по рiвняння кола
        double plane2Z = 2 * Math.Sin(angle2Circle * Math.PI / 180); // z по колу
        Plane2Translate.OffsetX = plane2X;
        Plane2Translate.OffsetZ = plane2Z;
        angle2Circle += 2; // збільшення кута 
        Plane2Rotate.CenterX = 0;
        Plane2Rotate.CenterY = 0;
        Plane2Rotate.CenterZ = 0;
        Plane2Rotate.Rotation = new AxisAngleRotation3D(new Vector3D(0, 1, 0), angle2);
        angle2 += 5;
    }

    private void StartAnimation_Click(object sender, RoutedEventArgs e)
    {
        timer.Start();
    }

    private void ResetAnimation_Click(object sender, RoutedEventArgs e)
    {
        Plane1Translate.OffsetY = 0; // скидання  1
        angle1 = 0;

        Plane2Translate.OffsetX = 0; // скидання 2 
        Plane2Translate.OffsetZ = 0;
        angle2Circle = 0;
        angle2 = 0;
        Plane2Rotate.Rotation = new AxisAngleRotation3D(new Vector3D(0, 1, 0), 0); // Скидання обертання літака 2
    }

        private void StopAnimation_Click(object sender, RoutedEventArgs e)
    {
        timer.Stop();
    }
}



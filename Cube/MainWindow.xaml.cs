using System;
using System.Collections.Generic;
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
using System.Windows.Media.Media3D;

namespace Cube
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AxisAngleRotation3D ax3d_iso = new AxisAngleRotation3D(new Vector3D(1, 1, 1), 1);
        AxisAngleRotation3D ax3d_X = new AxisAngleRotation3D(new Vector3D(1, 1, 1), 1);
        AxisAngleRotation3D ax3d_Y = new AxisAngleRotation3D(new Vector3D(1, 1, 1), 1);
        AxisAngleRotation3D ax3d_Z = new AxisAngleRotation3D(new Vector3D(1, 1, 1), 1);

        double tmpRoll;
        double tmpPitch;
        double tmpYaw;

        public MainWindow()
        {
            InitializeComponent();

            
            //Rotation Transform
            RotateTransform3D myRotateTransform_ISO = new RotateTransform3D(ax3d_iso);
            IMU_Model_Iso.Transform = myRotateTransform_ISO;
            RotateTransform3D myRotateTransform_X = new RotateTransform3D(ax3d_X);
            IMU_Model_X.Transform = myRotateTransform_X;
            RotateTransform3D myRotateTransform_Y = new RotateTransform3D(ax3d_Y);
            IMU_Model_Y.Transform = myRotateTransform_Y;
            RotateTransform3D myRotateTransform_Z = new RotateTransform3D(ax3d_Z);
            IMU_Model_Z.Transform = myRotateTransform_Z;

        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

            tmpPitch = PitchSlider.Value;
            tmpRoll = RollSlider.Value;
            tmpYaw = YawSlider.Value;

            if (tmpPitch < 0)
            {
                tmpPitch = tmpPitch + 360;
            }

            if (tmpRoll < 0)
            {
                tmpRoll = tmpRoll + 360;
            }

            if (tmpYaw < 0)
            {
                tmpYaw = tmpYaw + 360;
            }

            ax3d_iso.Axis = new Vector3D(tmpRoll, tmpPitch, tmpYaw);
            ax3d_iso.Angle = tmpRoll + tmpPitch + tmpYaw;

            ax3d_X.Axis = new Vector3D(tmpRoll, 0, 0);
            ax3d_X.Angle = RollSlider.Value; 
                       
            ax3d_Y.Axis = new Vector3D(0, tmpPitch, 0);
            ax3d_Y.Angle = PitchSlider.Value;
           
            ax3d_Z.Axis = new Vector3D(0, 0, tmpYaw);
            ax3d_Z.Angle = YawSlider.Value;

        }
    }
}


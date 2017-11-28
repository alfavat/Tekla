using System;
using System.Windows.Forms;
using Tekla.Structures.Drawing;
using Tekla.Structures.Model;

namespace Tekla
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            var model = new Model();  //получаем доступ к модели
            var CurrentDrawingHandler = new DrawingHandler();  //получаем доступ к чертежам

            //если подключение прошло успешно
            if (model.GetConnectionStatus() &&
                CurrentDrawingHandler.GetConnectionStatus())
            {
                InitializeComponent();
            }
            else
                MessageBox.Show("Tekla Structures must be opened!");
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
           


            Model m = new Model();
            Beam b = new Beam();

            b.Class = "4";
            b.Name = "myBeam";
            b.Profile.ProfileString = "UB406*140*46";
            b.StartPoint = new Structures.Geometry3d.Point(0,0,0);
            b.EndPoint = new Structures.Geometry3d.Point(10000,0,0);
            b.Material.MaterialString = "S275";
            b.Position.Depth = Position.DepthEnum.MIDDLE;
            b.Position.Rotation = Position.RotationEnum.TOP;
            b.Position.Plane = Position.PlaneEnum.MIDDLE;

            b.Insert();

            m.CommitChanges();

            label1.Text = "hello";
        }
    }
}

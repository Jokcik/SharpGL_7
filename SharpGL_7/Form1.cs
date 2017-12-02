using System.Windows.Forms;
using SharpGL;

namespace SharpGL_7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        

        private void openGLControl1_OpenGLDraw_1(object sender, RenderEventArgs args)
        {

            var gl = openGLControl1.OpenGL;

//            gl.Enable(OpenGL.GL_BLEND);           // Разрешить прозрачность.
//            gl.Enable(OpenGL.GL_POINT_SMOOTH);   // Разрешить сглаживание точек.
//            gl.Enable(OpenGL.GL_COLOR_MATERIAL); // Отключить перелевание цвета.
//            gl.PointSize(16);             // Размер точки.
//            gl.LineWidth(2);              // Толщина линий.


//            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
//            gl.ClearColor(1f, 1f, 1f, 1f);
//            gl.LoadIdentity();

            gl.End();

//            FormatOpenGL(gl);
//            _figureToilet.Draw(gl, 8f, 0f, -25f, _angle1, _angle1, _scale1, z, lines, fill, true);
//            FormatOpenGL(gl);
//            _figureHummer.Draw(gl, -3f, 0.5f, -10f, _angle2, _angle2, _scale2, z, lines, fill, true);
//            FormatOpenGL(gl);
//            _figureKub.Draw(gl, -1.3f, -1.8f, -6f, _angle3, _angle3, _scale3, z, lines, fill, true);
//            FormatOpenGL(gl);
//            _figureParallelepiped.Draw(gl, 1.2f, -1.8f, -6f, _angle4, _angle4, _scale4, z, lines, fill, true);
//            FormatOpenGL(gl);
//            _figureTriangle.Draw(gl, 0f, 1.8f, -6f, _angle5, _angle5, _scale5, z, lines, fill, true);
        }

    }
}

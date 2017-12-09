using System;
using System.Drawing;
using System.Windows.Forms;
using SharpGL;
using SharpGL.SceneGraph.Primitives;
using SharpGL_6.figures;
using SharpGL_7.figures;

namespace SharpGL_7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private readonly FigureParallelepiped _figureKub = new FigureParallelepiped();
        private readonly FigureHummer _figureHummer1 = new FigureHummer();
        private readonly FigureHummer _figureHummer2 = new FigureHummer();
        private readonly FigureHummer _figureHummer3 = new FigureHummer();

        private float _angleX;
        private float _angleY;

        private static float x1 = 0;
        private static float y1 = 0;
        
        private static float x2 = 0;
        private static float y2 = 0;
        
        private static float x3 = 0;
        private static float y3 = 0;
        
        private static float z1 = 0;
        private static float z2 = 0;
        
        
        private Point _currentLocation = new Point(0, 0);

        private readonly float[] _globalAmbient = {0.0f, 0.0f, 0.0f, 1f};
        
        private float[] _light0Scpecular = {1.0f, 1.0f, 1.0f, 1.0f};
        private float[] _light0Ambient = {0.8f, 0.8f, 0.8f, 1f};
        private float[] _light1Ambient = {0.4f, 0.4f, 0.4f, 1f};
        private float[] _light2Ambient = {0.1f, 0.1f, 0.1f, 1f};
        private float[] _light0Diffuse = {0.5f, 0.5f, 0.5f, 0.5f};
        private float[] _light1Diffuse = {1.0f, 1.0f, 1.0f, 1.0f};
        
        private float[] _l0pos = {-0.1f + x1, 0f + y1, -4.0f, 1.0f};
        private float[] _l1pos = {0.2f + x2, 0f + y2, -4.0f, 1.0f};
        private float[] _l2pos = {0.2f + x2, 0f + y2, -4.0f, 1.0f};
        
        
        private float[] _sRef = {1.0f, 1.0f, 1.0f, 1.0f};
        private float[] _s0pos = {-0.1f + x1, 0f + y1, -4.0f, 1.0f};
        private float[] _black = {0f, 0f, 0f, 1f};

        public void Init()
        {
            try
            {
                var tbR = int.Parse(textBoxR.Text);
                var tbG = int.Parse(textBoxR.Text);
                var tbB = int.Parse(textBoxR.Text);

                _l0pos = new[] {-0.1f + x1, 0f + y1, -4.0f + z1, 1.0f};
                _l1pos = new[] {0.2f + x2, 0f + y2, -4.0f + z2, 1.0f};
                _l2pos = new[] {0.1f + x3, 0.2f + y3, -4.0f, 1.0f};

                _sRef = new[] {tbR / 255f, tbG / 255f, tbB / 255f, 1f};
            }
            catch (Exception e)
            {
                // ignored
            }
        }
        
        private void openGLControl1_OpenGLDraw_1(object sender, RenderEventArgs args)
        {
            Init();
            var gl = openGLControl1.OpenGL;
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

            gl.Enable(OpenGL.GL_LIGHTING);
            gl.ClearColor(0.5f, 0.5f, 0.5f, 0.5f);
            
            gl.Enable(OpenGL.GL_COLOR_MATERIAL);
            gl.Enable(OpenGL.GL_DEPTH_TEST);
            gl.Enable(OpenGL.GL_TEXTURE_2D);
            
            gl.Enable(OpenGL.GL_BLEND);           // Разрешить прозрачность.
            gl.Enable(OpenGL.GL_POINT_SMOOTH);   // Разрешить сглаживание точек.
            gl.Enable(OpenGL.GL_COLOR_MATERIAL); // Отключить перелевание цвета.
            
            gl.LoadIdentity();
            gl.Light(OpenGL.GL_LIGHT1, OpenGL.GL_POSITION, _l0pos);
            _figureHummer1.Draw(gl, _l0pos[0], _l0pos[1], _l0pos[2], 0, 0, 1f, 0);
            gl.LoadIdentity();
            
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_POSITION, _l1pos);
            _figureHummer2.Draw(gl, _l1pos[0], _l1pos[1], _l1pos[2], 0, 0, 1f, 0);
            gl.LoadIdentity();
            
            gl.Light(OpenGL.GL_LIGHT2, OpenGL.GL_POSITION, _l2pos);
            _figureHummer3.Draw(gl, _l2pos[0], _l2pos[1], _l2pos[2], 0, 0, 1f, 0);
            gl.LoadIdentity();
            
            gl.Enable(OpenGL.GL_LIGHT0);
            gl.Enable(OpenGL.GL_LIGHT1);
            gl.Enable(OpenGL.GL_LIGHT2);

            gl.LightModel(OpenGL.GL_LIGHT_MODEL_AMBIENT, _black);
            
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_DIFFUSE, _light0Diffuse);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_AMBIENT, _light0Ambient);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_SPECULAR, _light0Scpecular);
            gl.Light(OpenGL.GL_LIGHT1, OpenGL.GL_DIFFUSE, _light0Diffuse);
            gl.Light(OpenGL.GL_LIGHT1, OpenGL.GL_AMBIENT, _light1Ambient);
            gl.Light(OpenGL.GL_LIGHT1, OpenGL.GL_SPECULAR, _light0Scpecular);
            gl.Light(OpenGL.GL_LIGHT2, OpenGL.GL_DIFFUSE, _light0Diffuse);
            gl.Light(OpenGL.GL_LIGHT2, OpenGL.GL_AMBIENT, _light2Ambient);
            gl.Light(OpenGL.GL_LIGHT2, OpenGL.GL_SPECULAR, _light0Scpecular);

            
            gl.LoadIdentity();
//            _figureKub.Draw(gl, 0, 0, -7f);
            
            gl.Translate(0, 0, -5f);
            var teapot = new Teapot();
//            gl.Rotate(_angleX, 1f, 0f, 0f);
//            gl.Rotate(_angleY, 0f, 1f, 0f);
            gl.Color(0.5f, 0.5f, 0.1f);
            teapot.Draw(gl, 14, 1, OpenGL.GL_FILL);
            gl.ColorMaterial(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_AMBIENT_AND_DIFFUSE);
            gl.Material(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_SPECULAR, _sRef);
            gl.Material(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_SHININESS, 64);
        
            gl.ShadeModel(OpenGL.GL_SMOOTH);
        }

        private void openGLControl1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            _angleY += (e.Location.X - _currentLocation.X) / 1.0f;
            _angleX += (e.Location.Y - _currentLocation.Y) / 1.0f;
            _currentLocation = e.Location;
        }

        private void openGLControl1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            _currentLocation = e.Location;
        }
        
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            z1 += e.Delta > 0 ? 0.01f : -0.01f;
//            z2 += e.Delta > 0 ? 0.01f : -0.01f;
            base.OnMouseWheel(e);
        }
        
        private void openGLControl1_KeyDown(object sender, KeyEventArgs e)
        { 
            switch (e.KeyCode)
            {
                case Keys.Q:
                    if (e.Shift)
                    {
                        x1 += 0.05f;
                    }
                    else 
                    {
                        x1 -= 0.05f;
                    }
                    break;
                case Keys.W:
                    if (e.Shift)
                    {
                        y1 += 0.05f;
                    }
                    else
                    {
                        y1 -= 0.05f;
                    }
                    break;
                case Keys.A:
                    if (e.Shift)
                    {
                        x2 += 0.05f;
                    }
                    else
                    {
                        x2 -= 0.05f;
                    }
                    break;
                case Keys.S:
                    if (e.Shift)
                    {
                        y2 += 0.05f;
                    }
                    else
                    {
                        y2 -= 0.05f;
                    }
                    break;
                case Keys.Z:
                    if (e.Shift)
                    {
                        x3 += 0.05f;
                    }
                    else
                    {
                        x3 -= 0.05f;
                    }
                    break;
                case Keys.X:
                    if (e.Shift)
                    {
                        y3 += 0.05f;
                    }
                    else
                    {
                        y3 -= 0.05f;
                    }
                    break;
            }
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {

        }
    }
}
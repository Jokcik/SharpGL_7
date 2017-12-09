using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using SharpGL;
using SharpGL.SceneGraph.Assets;
using SharpGL.SceneGraph.Primitives;

namespace SharpGL_6.figures
{
    public class FigureParallelepiped
    {
        private float a = 1, b = 1, c = 1;

        public FigureParallelepiped(float a, float b, float c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public FigureParallelepiped()
        {
        }
        
        private Texture _texture = new Texture();
        
        public void Draw(OpenGL gl, float ta, float ty, float tz)
        {
            _texture.Create(gl, "C:\\Users\\User\\RiderProjects\\SharpGL_7\\SharpGL_7\\files\\12387996.jpg");
            var scale = 0.6f * 1;
            
            gl.Translate(ta, ty, tz);
//            gl.LookAt(0, 0, z, 0, 0, z + 10, 0 , 1, 0);
            gl.Scale(scale, scale, scale);

                gl.Normal(0f, 0f, 1f);
                gl.Begin(OpenGL.GL_QUAD_STRIP);
                gl.Color(1f, 1f, 1f);                
                _texture.Bind(gl);
                gl.TexCoord(0f, 0f); gl.Vertex(-a / 2, -b / 2, -c / 2);
                gl.TexCoord(1f, 0f); gl.Vertex(-a / 2, -b / 2, c / 2);
                gl.TexCoord(1f, 1f); gl.Vertex(-a / 2, b / 2, -c / 2);
                gl.TexCoord(0f, 1f); gl.Vertex(-a / 2, b / 2, c / 2);

                gl.TexCoord(0f, 0f); gl.Vertex(a / 2, b / 2, -c / 2);
                gl.TexCoord(1f, 0f); gl.Vertex(a / 2, b / 2, c / 2);
                gl.TexCoord(1f, 1f);
                gl.TexCoord(0f, 1f);

                gl.TexCoord(0f, 0f); 
                gl.TexCoord(1f, 0f); gl.Vertex(a / 2, -b / 2, -c / 2);
                gl.TexCoord(1f, 1f); gl.Vertex(a / 2, -b / 2, c / 2);
                gl.TexCoord(0f, 1f); 
                
                gl.TexCoord(0f, 0f); 
                gl.TexCoord(1f, 0f); 
                gl.TexCoord(1f, 1f); gl.Vertex(-a / 2, -b / 2, -c / 2);
                gl.TexCoord(0f, 1f); gl.Vertex(-a / 2, -b / 2, c / 2);
                gl.End(); 

                gl.Begin(OpenGL.GL_QUADS);

                gl.TexCoord(0f, 0f); gl.Vertex(-a / 2, -b / 2, c / 2);
                gl.TexCoord(1f, 0f); gl.Vertex(-a / 2, b / 2, c / 2);
                gl.TexCoord(1f, 1f); gl.Vertex(a / 2, b / 2, c / 2);
                gl.TexCoord(0f, 1f); gl.Vertex(a / 2, -b / 2, c / 2);

                gl.TexCoord(0f, 0f); gl.Vertex(-a / 2, -b / 2, -c / 2);
                gl.TexCoord(1f, 0f); gl.Vertex(-a / 2, b / 2, -c / 2);
                gl.TexCoord(1f, 1f); gl.Vertex(a / 2, b / 2, -c / 2);
                gl.TexCoord(0f, 1f); gl.Vertex(a / 2, -b / 2, -c / 2);
                

                gl.End();

        }
    }
}
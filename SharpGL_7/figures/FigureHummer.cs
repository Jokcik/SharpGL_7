using System.Collections.Generic;
using SharpGL;
using SharpGL.SceneGraph.Assets;
using SharpGL_6.figures;

namespace SharpGL_7.figures
{
    public class FigureHummer
    {
        private readonly List<Polygon> _polygons;

        public FigureHummer()
        {
            _polygons = LoadPrimitive.Load(
                "C:\\Users\\User\\RiderProjects\\SharpGL_7\\SharpGL_7\\obj_files\\sphere.obj");
        }

        private Texture _texture = new Texture();

        public void Draw(OpenGL gl, float ta, float ty, float tz, float angleX, float angleY, float scale, float z)
        {
            _texture.Create(gl, "C:\\Users\\User\\RiderProjects\\SharpGL_7\\SharpGL_7\\files\\ahorn maser.bmp");
            scale = 0.1f * scale;

            gl.Translate(ta, ty, tz);
            gl.Scale(scale, scale, scale);
            _texture.Bind(gl);
            foreach (var polygon in _polygons)
            {
                gl.Begin(OpenGL.GL_POLYGON);
                gl.Color(polygon.color.R, polygon.color.G, polygon.color.B);
                var i = 0;
                foreach (var points in polygon.list)
                {
                    gl.TexCoord(i == 0 || i == 4 ? 0f : 1f, i == 0 || i == 1 ? 0f : 1f);        
                    gl.Vertex(points.Item1, points.Item2, points.Item3);
                    i += 1;
                }
                gl.End();
            }
            _texture.Destroy(gl);
        }
    }
}
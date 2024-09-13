using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafico
{
    class Circulo : Ponto
    {
        int raio;

        public int Raio
        {
            get { return raio; }
            set { raio = value; }
        }

        public Circulo(int xCentro, int yCentro, int novoRaio, Color novaCor) : base(xCentro, yCentro, novaCor)
        {
            raio = novoRaio;
        }

        public override void Desenhar(Color cor, Graphics g)
        {
            Pen pen = new Pen(cor);
            g.DrawEllipse(pen, base.X - raio, base.Y - raio, 2 * raio, 2 * raio);
        }
    }
}

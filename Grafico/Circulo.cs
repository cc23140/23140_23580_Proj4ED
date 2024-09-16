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

        public override string ToString()
        {
            return transformaString("c", 5) +
                transformaString(base.X, 5) +
                transformaString(base.Y, 5) +
                transformaString(raio, 5) +
                transformaString(Cor.R, 5) +
                transformaString(Cor.G, 5) +
                transformaString(Cor.B, 5);
        }
    }
}

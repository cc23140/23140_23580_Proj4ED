using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafico
{
    class Reta : Ponto
    {
        private Ponto pontoFinal;

        public Reta(int x1, int y1, int x2, int y2, Color novaCor) : base(x1, y1, novaCor)
        {
            pontoFinal = new Ponto(x2, y2, novaCor);
        }

        public override void Desenhar(Color cor, Graphics g)
        {
            Pen pen = new Pen(cor);
            g.DrawLine(pen, base.X, base.Y, pontoFinal.X, pontoFinal.Y);
        }

        public override string ToString()
        {
            return transformaString("l", 5) +
                transformaString(base.X, 5) +
                transformaString(base.Y, 5) +
                transformaString(pontoFinal.X, 5) +
                transformaString(pontoFinal.Y, 5) +
                transformaString(Cor.R, 5) +
                transformaString(Cor.G, 5) +
                transformaString(Cor.B, 5);
        }
    }
}

//João Pedro Valderrama dos Santos - 23140
//Maria Eduarda Martins Costa - 23580

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafico.FigurasGeometricas
{
    class Reta : Ponto
    {
        private Ponto pontoFinal;

        public Reta(int x1, int y1, int x2, int y2, Color novaCor) : base(x1, y1, novaCor)
        {
            pontoFinal = new Ponto(x2, y2, novaCor);
        }

        public override void Desenhar(Color cor, Graphics g, int espessura = 1)
        {
            Pen pen = new Pen(cor, espessura);
            g.DrawLine(pen, X, Y, pontoFinal.X, pontoFinal.Y);
        }

        public override string ToString()
        {
            return transformaString("l", 5) +
                transformaString(X, 5) +
                transformaString(Y, 5) +
                transformaString(Cor.R, 5) +
                transformaString(Cor.G, 5) +
                transformaString(Cor.B, 5) +
                transformaString(pontoFinal.X, 5) +
                transformaString(pontoFinal.Y, 5);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafico.FigurasGeometricas
{
    class Elipse:Ponto
    {
        int altura, largura;
        public Elipse(int x, int y, int largura, int altura, Color cor):base(x, y, cor)
        {
            this.altura = altura;
            this.largura = largura;
        }

        public override void Desenhar(Color cor, Graphics g)
        {
            Pen pen = new Pen(cor);
            g.DrawEllipse(pen, base.X, base.Y, largura, altura);
        }

        public override string ToString()
        {
            return transformaString("e", 5) +
                transformaString(base.X, 5) +
                transformaString(base.Y, 5) +
                transformaString(Cor.R, 5) +
                transformaString(Cor.G, 5) +
                transformaString(Cor.B, 5) +
                transformaString(largura, 5) +
                transformaString(altura, 5);
        }

        public int Altura
        {
            get { return altura; }
        }

        public int Largura
        {
            get { return largura; }
        }
    }
}

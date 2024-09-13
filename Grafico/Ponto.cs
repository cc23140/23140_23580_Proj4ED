using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafico
{
    class Ponto : IComparable<Ponto>
    {
        private int x, y;
        private Color cor;

        public Ponto(int x, int y, Color cor)
        {
            this.x = x;
            this.y = y;
            this.cor = cor;
        }

        public virtual void Desenhar(Color cor, Graphics g) //É colocado virtual para que o método seja sobrescrito depois
        {
            Pen pen = new Pen(cor);
            g.DrawLine(pen, x, y, x, y);
        }


        public String transformaString(int valor, int qntasPosicoes)
        {
            String cadeia = valor + "";
            while (cadeia.Length < qntasPosicoes)
                cadeia = "0" + cadeia;
            return cadeia.Substring(0, qntasPosicoes);
        }

        public String transformaString(String valor, int qntasPosicoes)
        {
            String cadeia = valor;
            while (cadeia.Length < qntasPosicoes)
                cadeia = cadeia + " ";
            return cadeia.Substring(0, qntasPosicoes);
        }



        public override string ToString()
        {
            return transformaString("p", 5) +
                transformaString(X, 5) +
                transformaString(Y, 5) +
                transformaString(Cor.R, 5) +
                transformaString(Cor.G, 5) +
                transformaString(Cor.B, 5);
        }

        public int CompareTo(Ponto outroPonto)
        {
            int diferencaX = x - outroPonto.x;
            if (diferencaX == 0)
                return Y - outroPonto.Y;
            return diferencaX - outroPonto.x;
        }

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public Color Cor
        {
            get { return cor; }
            set { cor = value; }
        }

    }
}

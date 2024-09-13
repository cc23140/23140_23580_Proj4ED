using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafico
{
    class Ponto
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

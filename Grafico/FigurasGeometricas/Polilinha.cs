//João Pedro Valderrama dos Santos - 23140
//Maria Eduarda Martins Costa - 23580

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafico.FigurasGeometricas
{
    class Polilinha:Ponto
    {
        ListaSimples<Ponto> listaDePontos;

        public Polilinha(int x, int y, Color cor):base(x, y, cor)
        {
            listaDePontos = new ListaSimples<Ponto>();
            listaDePontos.InserirAposFim(new Ponto(x, y, cor));
        }
        public void AdicionarPontoAposFim(Ponto ponto)
        {
            listaDePontos.InserirAposFim(ponto);
        }

        public override void Desenhar(Color cor, Graphics g, int espessura = 1)
        {
            if (listaDePontos.EstaVazia) 
                return;
            Pen pen = new Pen(cor, espessura);
            listaDePontos.IniciarPercursoSequencial();
            Ponto p1 = listaDePontos.Atual.Info;
            listaDePontos.PercorrerUmElementoLista();

            //Enquanto ainda haver pontos a percorrer, desenhar a linha gerada
            while (listaDePontos.PodePercorrer())
            {
                Ponto p2 = listaDePontos.Atual.Info;
                g.DrawLine(pen, p1.X, p1.Y, p2.X, p2.Y);
                listaDePontos.PercorrerUmElementoLista();

                p1 = p2;
            }
        }

        public override string ToString()
        {
            if (listaDePontos.EstaVazia)
                return "";
            listaDePontos.IniciarPercursoSequencial();
            string res = transformaString("pl", 5) + transformaString(listaDePontos.Atual.Info.X, 5) + transformaString(listaDePontos.Atual.Info.Y, 5);
            res += transformaString(Cor.R, 5) +
                    transformaString(Cor.G, 5) +
                    transformaString(Cor.B, 5);
            listaDePontos.PercorrerUmElementoLista();
            res += transformaString(listaDePontos.QuantosNos, 5);
            while (listaDePontos.PodePercorrer())
            {
                res += transformaString(listaDePontos.Atual.Info.X, 5);
                res += transformaString(listaDePontos.Atual.Info.Y, 5);
                listaDePontos.PercorrerUmElementoLista();
            }

            return res;
        }
    }
}

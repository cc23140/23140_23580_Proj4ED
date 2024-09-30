using System.Security.Cryptography.Pkcs;
using Grafico.FigurasGeometricas;

namespace Grafico
{
    public partial class Form1 : Form
    {

        //Ponto
        bool esperaPonto = false;

        //Reta
        bool esperaInicioReta = false;
        bool esperaFimReta = false;

        //Círculo
        bool esperaInicioCirculo = false;
        bool esperaFimCirculo = false;

        //Elipse
        bool esperaInicioElipse = false;
        bool esperaFimElipse = false;

        //Retângulo
        bool esperaInicioRetangulo = false;
        bool esperaFimRetangulo = false;

        //Polilinha
        bool esperaInicioPolilinha = false;
        bool esperaFimPolilinha = false;


        private ListaSimples<Ponto> figuras = new ListaSimples<Ponto>();
        Polilinha polilinha;

        Color corAtual = Color.Black;
        private static Ponto p1 = new Ponto(0, 0, Color.Black);
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            if (dlgAbrir.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamReader arqFiguras = new StreamReader(dlgAbrir.FileName);
                    String linha = arqFiguras.ReadLine();

                    if (linha != null)
                    {
                        //Informações do quadro no momento que foi salvo é mostrado!
                        double xInfEsq = Convert.ToDouble(linha.Substring(0, 5).Trim());
                        double yInfEsq = Convert.ToDouble(linha.Substring(5, 5).Trim());
                        double xSupDir = Convert.ToDouble(linha.Substring(10, 5).Trim());
                        double ySupDir = Convert.ToDouble(linha.Substring(15, 5).Trim());

                        while ((linha = arqFiguras.ReadLine()) != null)
                        {
                            String tipo = linha.Substring(0, 5).Trim();
                            int xBase = Convert.ToInt32(linha.Substring(5, 5).Trim());
                            int yBase = Convert.ToInt32(linha.Substring(10, 5).Trim());
                            int corR = Convert.ToInt32(linha.Substring(15, 5).Trim());
                            int corG = Convert.ToInt32(linha.Substring(20, 5).Trim());
                            int corB = Convert.ToInt32(linha.Substring(25, 5).Trim());
                            Color cor = new Color();
                            cor = Color.FromArgb(corR, corG, corB);


                            switch (tipo[0])
                            {
                                case 'p': //figura é um ponto
                                    figuras.InserirAposFim(new Ponto(xBase, yBase, cor));
                                    break;

                                case 'l': //figura é uma reta
                                    int xFinal = Convert.ToInt32(linha.Substring(30, 5).Trim());
                                    int yFinal = Convert.ToInt32(linha.Substring(35, 5).Trim());
                                    figuras.InserirAposFim(new Reta(xBase, yBase, xFinal, yFinal, cor));
                                    break;

                                case 'c': //figura é um círculo
                                    int raio = Convert.ToInt32(linha.Substring(30, 5).Trim());
                                    figuras.InserirAposFim(new Circulo(xBase, yBase, raio, cor));
                                    break;

                                case 'e': //figura é uma elipse
                                          //TODO
                                    break;
                            }

                        }

                    }
                    arqFiguras.Close();
                    this.Text = dlgAbrir.FileName;
                    pbAreaDesenho.Invalidate();
                }
                catch (IOException)
                {
                    Console.WriteLine("Erro de leitura no arquivo");
                }
            }
        }

        private void pbAreaDesenho_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;


            if (figuras.EstaVazia)
                return;

            figuras.IniciarPercursoSequencial();

            while (figuras.PodePercorrer())
            {
                Ponto figuraAtual = figuras.Atual.Info;

                figuraAtual.Desenhar(figuraAtual.Cor, g);
                figuras.PercorrerUmElementoLista();
            }
        }

        private void limparEsperas()
        {
            esperaPonto = false;

            esperaInicioReta = false;
            esperaFimReta = false;

            esperaInicioCirculo = false;
            esperaFimCirculo = false;

            esperaInicioElipse = false;
            esperaFimElipse = false;

            esperaInicioRetangulo = false;
            esperaFimRetangulo = false;

            esperaInicioPolilinha = false;
            esperaFimPolilinha = false;


        }

        private void pbAreaDesenho_MouseMove(object sender, MouseEventArgs e)
        {
            stMensagem.Items[3].Text = "(" + e.X + ", " + e.Y + ")";
        }

        private void btnPonto_Click_1(object sender, EventArgs e)
        {
            stMensagem.Items[1].Text = "Clique no local do ponto desejado";
            limparEsperas();
            esperaPonto = true;
        }

        private void pbAreaDesenho_MouseClick(object sender, MouseEventArgs e)
        {
            if (esperaPonto)
            {
                Ponto novoPonto = new Ponto(e.X, e.Y, corAtual);
                figuras.InserirAposFim(novoPonto);
                novoPonto.Desenhar(novoPonto.Cor, pbAreaDesenho.CreateGraphics());
                esperaPonto = false;
                stMensagem.Items[1].Text = "";
            }
            else if (esperaInicioReta)
            {
                p1 = new Ponto(e.X, e.Y, corAtual);
                esperaInicioReta = false;
                esperaFimReta = true;
                stMensagem.Items[1].Text = "Clique no local do ponto final da reta";
            }
            else if (esperaFimReta)
            {
                esperaFimReta = false;
                Reta reta = new Reta(e.X, e.Y, p1.X, p1.Y, p1.Cor);
                reta.Desenhar(reta.Cor, pbAreaDesenho.CreateGraphics());
                figuras.InserirAposFim(reta);
                stMensagem.Items[1].Text = "";
            }
            else if (esperaInicioCirculo)
            {
                esperaInicioCirculo = false;
                p1 = new Ponto(e.X, e.Y, corAtual);
                stMensagem.Items[1].Text = "Clique no local da circunferência do círculo paralelo a reta X";
                esperaFimCirculo = true;
            }
            else if (esperaFimCirculo)
            {
                esperaFimCirculo = false;
                Circulo circulo = new Circulo(p1.X, p1.Y, e.X - p1.X, p1.Cor);
                circulo.Desenhar(circulo.Cor, pbAreaDesenho.CreateGraphics());
                figuras.InserirAposFim(circulo);
                stMensagem.Items[1].Text = "";
            }
            else if (esperaInicioElipse)
            {
                esperaInicioElipse = false;
                p1 = new Ponto(e.X, e.Y, corAtual);
                stMensagem.Items[1].Text = "Clique no local do canto inferior direito da elipse";
                esperaFimElipse = true;
            }
            else if (esperaFimElipse)
            {
                esperaFimElipse = false;
                Elipse elipse = new Elipse(p1.X, p1.Y, e.X - p1.X, e.Y - p1.Y, p1.Cor);
                elipse.Desenhar(elipse.Cor, pbAreaDesenho.CreateGraphics());
                figuras.InserirAposFim(elipse);
                stMensagem.Items[1].Text = "";
            }
            else if (esperaInicioRetangulo)
            {
                esperaInicioRetangulo = false;
                p1 = new Ponto(e.X, e.Y, corAtual);
                stMensagem.Items[1].Text = "Clique no local do canto inferior direito do retângulo";
                esperaFimRetangulo = true;
            }
            else if (esperaFimRetangulo)
            {
                esperaFimRetangulo = false;
                Retangulo retangulo = new Retangulo(p1.X, p1.Y, e.X - p1.X, e.Y - p1.Y, p1.Cor);
                retangulo.Desenhar(retangulo.Cor, pbAreaDesenho.CreateGraphics());
                figuras.InserirAposFim(retangulo);
                stMensagem.Items[1].Text = "";
            }
        }

        private void btnReta_Click(object sender, EventArgs e)
        {
            stMensagem.Items[1].Text = "Clique no local do ponto inicial da reta";
            limparEsperas();
            esperaInicioReta = true;
        }

        private void btnCirculo_Click(object sender, EventArgs e)
        {
            stMensagem.Items[1].Text = "Clique no local do centro do círculo";
            limparEsperas();
            esperaInicioCirculo = true;

        }

        private void btnElipse_Click(object sender, EventArgs e)
        {
            stMensagem.Items[1].Text = "Clique no local do canto superior esquerdo da elipse";
            limparEsperas();
            esperaInicioElipse = true;
        }

        private void btnApagarTudo_Click(object sender, EventArgs e)
        {
            figuras = new ListaSimples<Ponto>();
            pbAreaDesenho.Image = null;
            limparEsperas();
            stMensagem.Items[1].Text = "";
        }

        private void btnRetangulo_Click(object sender, EventArgs e)
        {
            stMensagem.Items[1].Text = "Clique no local do canto superior esquerdo do retângulo";
            limparEsperas();
            esperaInicioRetangulo = true;
        }

        private void btnCor_Click(object sender, EventArgs e)
        {
            if (cdlgSelecionarCor.ShowDialog() == DialogResult.OK)
            {
                corAtual = cdlgSelecionarCor.Color;
            }
            limparEsperas();
        }

        private void btnPolilinha_Click(object sender, EventArgs e)
        {
            stMensagem.Items[1].Text = "Clique no local do ponto inicial do polilinha";
            limparEsperas();
            esperaInicioPolilinha = true;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            StreamWriter arqFiguras = new StreamWriter(this.Text);
            if (!figuras.EstaVazia)
            {
                arqFiguras.WriteLine("0".PadLeft(5, ' ')+"0".PadLeft(5, ' ')+pbAreaDesenho.Width.ToString().PadLeft(5, ' ')+pbAreaDesenho.Height.ToString().PadLeft(5, ' '));
                figuras.IniciarPercursoSequencial();
                while (figuras.PodePercorrer())
                {
                    arqFiguras.WriteLine(figuras.Atual.Info.ToString());
                    figuras.PercorrerUmElementoLista();

                }
                arqFiguras.Close();
            }
            Close();

                
        }
    }
}

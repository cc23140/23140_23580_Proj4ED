namespace Grafico
{
    public partial class Form1 : Form
    {
        bool esperaPonto = false;
        bool esperaInicioReta = false;
        bool esperaFimReta = false;
        private ListaSimples<Ponto> figuras = new ListaSimples<Ponto>();
        Color corAtual = Color.Black;
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

            figuras.iniciarPercursoSequencial();

            do
            {
                Ponto figuraAtual = figuras.Atual.Info;
                figuraAtual.Desenhar(figuraAtual.Cor, g);
            } while (figuras.podePercorrer());
        }

        private void limparEsperas()
        {
            esperaPonto = false;
            esperaInicioReta = false;
            esperaFimReta = false;
        }

        private void pbAreaDesenho_MouseMove(object sender, MouseEventArgs e)
        {
            stMensagem.Items[3].Text = "(" + e.X + ", " + e.Y + ")";
        }

        private void btnPonto_Click(object sender, EventArgs e){
            stMensagem.Items[1].Text = "Clique no local do ponto desejado";
            limparEsperas();
            esperaPonto = true;


         }

    }
}

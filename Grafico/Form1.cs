//João Pedro Valderrama dos Santos - 23140
//Maria Eduarda Martins Costa - 23580
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
        bool continuarPolilinha = false;

        //Arquivo
        bool arquivoFoiSelecionado = false;

        //ListaSimples de figuras
        private ListaSimples<Ponto> figuras = new ListaSimples<Ponto>();

        //ListaSimples de índices das figuras selecionadas
        private ListaSimples<int> indicesFigSelecionadas = new ListaSimples<int>();

        //Variável criada para gerenciar o progresso de todas as polilinhas a serem criadas pelo usuário
        Polilinha polilinha;


        //Cor atual inserida
        Color corAtual = Color.Black;


        private static Ponto p1 = new Ponto(0, 0, Color.Black);
        public Form1()
        {
            InitializeComponent();
        }


        //Método acionado quando btnAbrir é clicado
        private void btnAbrir_Click(object sender, EventArgs e)
        {
            //Se der tudo certo na seleção do arquivo...
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

                            //Cada figura possui seu tipo de criação que é encaixada dentro do switch
                            switch (tipo)
                            {
                                case "p": //figura é um ponto
                                    figuras.InserirAposFim(new Ponto(xBase, yBase, cor));
                                    break;

                                case "l": //figura é uma reta
                                    int xFinal = Convert.ToInt32(linha.Substring(30, 5).Trim());
                                    int yFinal = Convert.ToInt32(linha.Substring(35, 5).Trim());
                                    figuras.InserirAposFim(new Reta(xBase, yBase, xFinal, yFinal, cor));
                                    break;

                                case "c": //figura é um círculo
                                    int raio = Convert.ToInt32(linha.Substring(30, 5).Trim());
                                    figuras.InserirAposFim(new Circulo(xBase, yBase, raio, cor));
                                    break;

                                case "e": //figura é uma elipse
                                    int largura = Convert.ToInt32(linha.Substring(30, 5).Trim());
                                    int altura = Convert.ToInt32(linha.Substring(35, 5).Trim());
                                    figuras.InserirAposFim(new Elipse(xBase, yBase, largura, altura, cor));
                                    break;

                                case "r": //figura é um retângulo
                                    int larg = Convert.ToInt32(linha.Substring(30, 5).Trim());
                                    int alt = Convert.ToInt32(linha.Substring(35, 5).Trim());
                                    figuras.InserirAposFim(new Retangulo(xBase, yBase, larg, alt, cor));
                                    break;

                                case "pl": //figura é um polilinha
                                    polilinha = new Polilinha(xBase, yBase, cor);

                                    //Pega quantos pontos, ou seja, quantos loops necessários dentro do while para pegar todos os pontos do 
                                    //polilinha
                                    //Obs.: É subtraído -1 porque o xBase e o yBase já são pegos logo no começo
                                    int quantasVoltas = Convert.ToInt32(linha.Substring(30, 5).Trim()) - 1;
                                    int voltaSoma = 5;
                                    while (quantasVoltas > 0)
                                    {
                                        int xPonto = Convert.ToInt32(linha.Substring(30 + voltaSoma, 5).Trim());
                                        int yPonto = Convert.ToInt32(linha.Substring(35 + voltaSoma, 5).Trim());
                                        polilinha.AdicionarPontoAposFim(new Ponto(xPonto, yPonto, polilinha.Cor));
                                        voltaSoma += 10;
                                        quantasVoltas--;
                                    }
                                    figuras.InserirAposFim(polilinha);
                                    break;
                            }

                        }

                    }
                    //Arquivo é fechado, ListBox é atualizado e o PictureBox também
                    arqFiguras.Close();
                    this.Text = dlgAbrir.FileName;
                    arquivoFoiSelecionado = true;
                    AtualizarListBox();
                    pbAreaDesenho.Invalidate();
                }
                catch (IOException)
                {//Em caso de exceção...
                    Console.WriteLine("Erro de leitura no arquivo");
                }
            }
        }

        //Método acionado quando pbAreaDesenho.Invalidate() é chamado
        private void pbAreaDesenho_Paint(object sender, PaintEventArgs e)
        {
            //Se o arquivo não foi selecionado...
            //retornar
            if (!arquivoFoiSelecionado)
                return;

            //Senão,
            //Desenhar cada figura presente no ListaSimples figuras...
         
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

            //E, se há figuras selecionadas,
            //Criá-las com cor vermelha e uma espessura mais grossa
            if (indicesFigSelecionadas.EstaVazia)
                return;
            indicesFigSelecionadas.IniciarPercursoSequencial();
            while (indicesFigSelecionadas.PodePercorrer())
            {
                Ponto figuraAtual = figuras.PegarElementoPeloIndice(indicesFigSelecionadas.Atual.Info);
                figuraAtual.Desenhar(Color.Red, g, 3);
                indicesFigSelecionadas.PercorrerUmElementoLista();
            }
        }


        //Método que limpa todos os tipos de esperas do programa
        //(Caso o arquivo tenha sido selecionado)
        private void limparEsperas()
        {
            if (!arquivoFoiSelecionado)
                return;
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
            continuarPolilinha = false;


        }


        //Método acionado quando o mouse é movido dentro 
        //da PictureBox
        private void pbAreaDesenho_MouseMove(object sender, MouseEventArgs e)
        {
            if (!arquivoFoiSelecionado)
                return;
            stMensagem.Items[3].Text = "(" + e.X + ", " + e.Y + ")";
        }


        //Método acionado quando btnPonto é clicado
        private void btnPonto_Click_1(object sender, EventArgs e)
        {
            //Muda a mensagem do stMensagem e espera pelo ponto
            stMensagem.Items[1].Text = "Clique no local do ponto desejado";
            limparEsperas();
            esperaPonto = true;
        }

        //Método acionado quando há um clique do mouse dentro da área
        //do PictureBox
        private void pbAreaDesenho_MouseClick(object sender, MouseEventArgs e)
        {
            //Verifica se o arquivo foi selecionado anteriormente...
            if (!arquivoFoiSelecionado)
                return;

            //Se foi, é tratado cada tipo de espera para uma continuação
            //de uma possível figura
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
                //Primeiro clique do círculo é feito e é esperado o segundo clique do círculo
                esperaInicioCirculo = false;
                p1 = new Ponto(e.X, e.Y, corAtual);
                stMensagem.Items[1].Text = "Clique no local da circunferência do círculo paralelo a reta X";
                esperaFimCirculo = true;
            }
            else if (esperaFimCirculo)
            {
                //Segundo clique do círculo é feito e o círculo é adicionado
                //na ListaSimples figuras
                esperaFimCirculo = false;
                Circulo circulo = new Circulo(p1.X, p1.Y, e.X - p1.X, p1.Cor);
                circulo.Desenhar(circulo.Cor, pbAreaDesenho.CreateGraphics());
                figuras.InserirAposFim(circulo);
                stMensagem.Items[1].Text = "";
            }
            else if (esperaInicioElipse)
            {
                //Primeiro clique da elipse é feito e é esperado o segundo clique da elipse
                esperaInicioElipse = false;
                p1 = new Ponto(e.X, e.Y, corAtual);
                stMensagem.Items[1].Text = "Clique no local do canto inferior direito da elipse";
                esperaFimElipse = true;
            }
            else if (esperaFimElipse)
            {
                //Segundo clique da elipse é feito e a elipse é adicionada
                //na ListaSimples figuras
                esperaFimElipse = false;
                Elipse elipse = new Elipse(p1.X, p1.Y, e.X - p1.X, e.Y - p1.Y, p1.Cor);
                elipse.Desenhar(elipse.Cor, pbAreaDesenho.CreateGraphics());
                figuras.InserirAposFim(elipse);
                stMensagem.Items[1].Text = "";
            }
            else if (esperaInicioRetangulo)
            {
                //Primeiro clique do retângulo é feito e é esperado o segundo clique do retângulo
                esperaInicioRetangulo = false;
                p1 = new Ponto(e.X, e.Y, corAtual);
                stMensagem.Items[1].Text = "Clique no local do canto inferior direito do retângulo";
                esperaFimRetangulo = true;
            }
            else if (esperaFimRetangulo)
            {
                //Segundo clique do retângulo é feito e o retângulo é adicionado
                //na ListaSimples figuras
                esperaFimRetangulo = false;
                Retangulo retangulo = new Retangulo(p1.X, p1.Y, e.X - p1.X, e.Y - p1.Y, p1.Cor);
                retangulo.Desenhar(retangulo.Cor, pbAreaDesenho.CreateGraphics());
                figuras.InserirAposFim(retangulo);
                stMensagem.Items[1].Text = "";
            }
            else if (esperaInicioPolilinha)
            {
                //Primeiro clique da polilinha é feito e é esperado a continuação da polilinha
                esperaInicioPolilinha = false;
                polilinha = new Polilinha(e.X, e.Y, corAtual);
                stMensagem.Items[1].Text = "Clique com o clique esquerdo do mouse para continuar o polilinha";
                continuarPolilinha = true;
            }
            else if (e.Button == MouseButtons.Right) //Termina o polilinha se o usuário clicar com o clique direito do mouse
            {
                //Último clique da polilinha é feito e a polilinha é adicionada
                //na ListaSimples figuras
                continuarPolilinha = false;
                polilinha.Desenhar(polilinha.Cor, pbAreaDesenho.CreateGraphics());
                figuras.InserirAposFim(polilinha);
            }
            else if (continuarPolilinha) 
            {
                //Continua o polilinha se o usuário não clicar com o clique direito do mouse e 
                //a polilinha gerada neste instante é desenhada (para fins de visualização)
                polilinha.AdicionarPontoAposFim(new Ponto(e.X, e.Y, corAtual));
                polilinha.Desenhar(polilinha.Cor, pbAreaDesenho.CreateGraphics());
                stMensagem.Items[1].Text = "Clique com o clique direito para parar com o polilinha";
            }

            //ListBox é atualizado com o número de elementos da ListaSimples figuras
            AtualizarListBox();

        }


        //Método acionado quanto btnReta é clicado
        private void btnReta_Click(object sender, EventArgs e)
        {
            //Verifica se o arquivo foi selecionado ...
           
            if (!arquivoFoiSelecionado)
                return;

            //E se foi, espera pelo início da reta
            stMensagem.Items[1].Text = "Clique no local do ponto inicial da reta";
            limparEsperas();
            esperaInicioReta = true;
        }


        //Método acionado quando btnCirculo é clicado
        private void btnCirculo_Click(object sender, EventArgs e)
        {
            //Verifica se o arquivo foi selecionado anteriormente...
            if (!arquivoFoiSelecionado)
                return;

            //Se foi, espera pelo início do círculo
            stMensagem.Items[1].Text = "Clique no local do centro do círculo";
            limparEsperas();
            esperaInicioCirculo = true;

        }

        //Método acionado quando btnElipse é clicado
        private void btnElipse_Click(object sender, EventArgs e)
        {
            //Verifica se o arquivo foi selecionado anteriormente...
            if (!arquivoFoiSelecionado)
                return;

            //E se foi, espera pelo início da elipse
            stMensagem.Items[1].Text = "Clique no local do canto superior esquerdo da elipse";
            limparEsperas();
            esperaInicioElipse = true;
        }

        //Método acionado quando btnApagarTudo é clicado
        private void btnApagarTudo_Click(object sender, EventArgs e)
        {
            //Verifica se o arquivo foi anteriormente selecionado
            if (!arquivoFoiSelecionado)
                return;

            //Se não há figuras selecionadas, remover todas as figuras!
            if (indicesFigSelecionadas.EstaVazia)
            {
                figuras = new ListaSimples<Ponto>();
                pbAreaDesenho.Image = null;
                limparEsperas();
                stMensagem.Items[1].Text = "";
            }
            else //Se há figuras selecionadas...
            {
                //Remover somente as figuras selecionadas!
                indicesFigSelecionadas.IniciarPercursoSequencial();
                ListaSimples<Ponto> figurasASeremDeletadas = new ListaSimples<Ponto>();
                while(indicesFigSelecionadas.PodePercorrer())
                {
                    Ponto figuraAtual = figuras.PegarElementoPeloIndice(indicesFigSelecionadas.Atual.Info);
                    figurasASeremDeletadas.InserirAntesDoInicio(figuraAtual);
                    indicesFigSelecionadas.PercorrerUmElementoLista();
                }

                figurasASeremDeletadas.IniciarPercursoSequencial();
                while (figurasASeremDeletadas.PodePercorrer())
                {
                    figuras.Remover(figurasASeremDeletadas.Atual.Info);
                    figurasASeremDeletadas.PercorrerUmElementoLista();
                }

                indicesFigSelecionadas = new ListaSimples<int>();

                
            }

            //ListBox é atualizado junto com o PictureBox
            AtualizarListBox();
            pbAreaDesenho.Invalidate();

        }

        //Método acionado quando btnRetangulo é clicado
        private void btnRetangulo_Click(object sender, EventArgs e)
        {
            //Verifica se o arquivo foi selecionado
            if (!arquivoFoiSelecionado)
                return;

            //Espera pelo início do retângulo
            stMensagem.Items[1].Text = "Clique no local do canto superior esquerdo do retângulo";
            limparEsperas();
            esperaInicioRetangulo = true;
        }


        //Método acionado quando btnCor é clicado
        private void btnCor_Click(object sender, EventArgs e)
        {
            if (!arquivoFoiSelecionado)
                return;

            //corAtual recebe a cor selecionada se tudo ocorrer bem no ColorDialog
            if (cdlgSelecionarCor.ShowDialog() == DialogResult.OK)
            {
                corAtual = cdlgSelecionarCor.Color;
            }
            limparEsperas();
        }


        //Método acionado quando btnPolilinha é clicado
        private void btnPolilinha_Click(object sender, EventArgs e)
        {
            if (!arquivoFoiSelecionado)
                return;
            //Espera pelo início da polilinha
            stMensagem.Items[1].Text = "Clique no local do ponto inicial do polilinha";
            limparEsperas();
            esperaInicioPolilinha = true;
        }


        //Método acionada quando btnSair é clicado
        private void btnSair_Click(object sender, EventArgs e)
        {
            StreamWriter arqFiguras = new StreamWriter(this.Text);


            //Se há figuras para salvar...
            if (!figuras.EstaVazia)
            {
                //Salvá-las no arquivo e fechar o programa
                arqFiguras.WriteLine("0".PadLeft(5, ' ') + "0".PadLeft(5, ' ') + pbAreaDesenho.Width.ToString().PadLeft(5, ' ') + pbAreaDesenho.Height.ToString().PadLeft(5, ' '));
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

        //Método que atualiza o ListBox com o número de nós
        //da ListaSimples figuras
        private void AtualizarListBox()
        {
            if (!arquivoFoiSelecionado)
                return;
            lbFiguraSelecionada.Items.Clear();
            for (int i = 1; i <= figuras.QuantosNos; i++)
            {
                lbFiguraSelecionada.Items.Add(i.ToString());

            }
        }


        //Método acionado quando btnUnicaSelecao é clicado
        private void btnUnicaSelecao_Click(object sender, EventArgs e)
        {
            if (!arquivoFoiSelecionado)
                return;
            if (lbFiguraSelecionada.SelectedItem == null)
                return;

            //Se a figura não está selecionada, selecioná-la. Senão, removê-la da seleção
            int indiceSelecionado = Convert.ToInt32(lbFiguraSelecionada.SelectedItem!.ToString()) - 1;
            if (!indicesFigSelecionadas.Existe(indiceSelecionado))
                indicesFigSelecionadas.InserirAntesDoInicio(indiceSelecionado);
            else
            {
                indicesFigSelecionadas.Remover(indiceSelecionado);
            }
            pbAreaDesenho.Invalidate();
        }


        //Método acionado quando btnTodasSelecoes é clicado
        private void btnTodasSelecoes_Click(object sender, EventArgs e)
        {
            if (!arquivoFoiSelecionado)
                return;

            //Se não há figuras selecionadas, selecionar todas as figuras
            if (indicesFigSelecionadas.EstaVazia)
            {
                for(int i = 0; i < figuras.QuantosNos; i++)
                {
                    indicesFigSelecionadas.InserirAntesDoInicio(i);
                }
            }
            //Senão, remover todas as figuras selecionadas da seleção 
            else
            {
                indicesFigSelecionadas = new ListaSimples<int>();
            }
            pbAreaDesenho.Invalidate();
        }


    }
}

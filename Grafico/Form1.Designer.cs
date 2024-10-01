namespace Grafico
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            toolStrip1 = new ToolStrip();
            btnAbrir = new ToolStripButton();
            btnSalvar = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            btnPonto = new ToolStripButton();
            btnReta = new ToolStripButton();
            btnCirculo = new ToolStripButton();
            btnElipse = new ToolStripButton();
            btnRetangulo = new ToolStripButton();
            btnPolilinha = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            btnCor = new ToolStripButton();
            toolStripSeparator3 = new ToolStripSeparator();
            btnSair = new ToolStripButton();
            toolStripSeparator4 = new ToolStripSeparator();
            btnApagarTudo = new ToolStripButton();
            stMensagem = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            statusLabelMensagem = new ToolStripStatusLabel();
            toolStripStatusLabel3 = new ToolStripStatusLabel();
            statusLabel = new ToolStripStatusLabel();
            dlgAbrir = new OpenFileDialog();
            dlgSalvar = new SaveFileDialog();
            pbAreaDesenho = new PictureBox();
            cdlgSelecionarCor = new ColorDialog();
            label1 = new Label();
            btnUnicaSelecao = new Button();
            btnTodasSelecoes = new Button();
            lbFiguraSelecionada = new ListBox();
            toolStrip1.SuspendLayout();
            stMensagem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbAreaDesenho).BeginInit();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Dock = DockStyle.None;
            toolStrip1.ImageScalingSize = new Size(25, 25);
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnAbrir, btnSalvar, toolStripSeparator1, btnPonto, btnReta, btnCirculo, btnElipse, btnRetangulo, btnPolilinha, toolStripSeparator2, btnCor, toolStripSeparator3, btnSair, toolStripSeparator4, btnApagarTudo });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(355, 32);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // btnAbrir
            // 
            btnAbrir.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnAbrir.Image = Properties.Resources.arquivo;
            btnAbrir.ImageTransparentColor = Color.Magenta;
            btnAbrir.Name = "btnAbrir";
            btnAbrir.Size = new Size(29, 29);
            btnAbrir.Text = "toolStripButton1";
            btnAbrir.Click += btnAbrir_Click;
            // 
            // btnSalvar
            // 
            btnSalvar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnSalvar.Image = Properties.Resources.editar;
            btnSalvar.ImageTransparentColor = Color.Magenta;
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(29, 29);
            btnSalvar.Text = "toolStripButton2";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 32);
            // 
            // btnPonto
            // 
            btnPonto.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnPonto.Image = Properties.Resources.ponto_final;
            btnPonto.ImageTransparentColor = Color.Magenta;
            btnPonto.Name = "btnPonto";
            btnPonto.Size = new Size(29, 29);
            btnPonto.Text = "toolStripButton3";
            btnPonto.Click += btnPonto_Click_1;
            // 
            // btnReta
            // 
            btnReta.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnReta.Image = Properties.Resources.linha_diagonal__1_;
            btnReta.ImageTransparentColor = Color.Magenta;
            btnReta.Name = "btnReta";
            btnReta.Size = new Size(29, 29);
            btnReta.Text = "toolStripButton4";
            btnReta.Click += btnReta_Click;
            // 
            // btnCirculo
            // 
            btnCirculo.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnCirculo.Image = Properties.Resources.circulo;
            btnCirculo.ImageTransparentColor = Color.Magenta;
            btnCirculo.Name = "btnCirculo";
            btnCirculo.Size = new Size(29, 29);
            btnCirculo.Text = "toolStripButton5";
            btnCirculo.Click += btnCirculo_Click;
            // 
            // btnElipse
            // 
            btnElipse.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnElipse.Image = Properties.Resources.variante_de_forma_de_contorno_de_elipse;
            btnElipse.ImageTransparentColor = Color.Magenta;
            btnElipse.Name = "btnElipse";
            btnElipse.Size = new Size(29, 29);
            btnElipse.Text = "toolStripButton1";
            btnElipse.Click += btnElipse_Click;
            // 
            // btnRetangulo
            // 
            btnRetangulo.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnRetangulo.Image = Properties.Resources.contorno_de_forma_retangular;
            btnRetangulo.ImageTransparentColor = Color.Magenta;
            btnRetangulo.Name = "btnRetangulo";
            btnRetangulo.Size = new Size(29, 29);
            btnRetangulo.Text = "toolStripButton6";
            btnRetangulo.Click += btnRetangulo_Click;
            // 
            // btnPolilinha
            // 
            btnPolilinha.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnPolilinha.Image = Properties.Resources.cadeia_poligonal;
            btnPolilinha.ImageTransparentColor = Color.Magenta;
            btnPolilinha.Name = "btnPolilinha";
            btnPolilinha.Size = new Size(29, 29);
            btnPolilinha.Text = "toolStripButton7";
            btnPolilinha.Click += btnPolilinha_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 32);
            // 
            // btnCor
            // 
            btnCor.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnCor.Image = Properties.Resources.paleta_de_cores;
            btnCor.ImageTransparentColor = Color.Magenta;
            btnCor.Name = "btnCor";
            btnCor.Size = new Size(29, 29);
            btnCor.Text = "toolStripButton8";
            btnCor.Click += btnCor_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 32);
            // 
            // btnSair
            // 
            btnSair.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnSair.Image = Properties.Resources.log_out__1_;
            btnSair.ImageTransparentColor = Color.Magenta;
            btnSair.Name = "btnSair";
            btnSair.Size = new Size(29, 29);
            btnSair.Text = "toolStripButton9";
            btnSair.Click += btnSair_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(6, 32);
            // 
            // btnApagarTudo
            // 
            btnApagarTudo.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnApagarTudo.Image = (Image)resources.GetObject("btnApagarTudo.Image");
            btnApagarTudo.ImageTransparentColor = Color.Magenta;
            btnApagarTudo.Name = "btnApagarTudo";
            btnApagarTudo.Size = new Size(29, 29);
            btnApagarTudo.Text = "toolStripButton1";
            btnApagarTudo.Click += btnApagarTudo_Click;
            // 
            // stMensagem
            // 
            stMensagem.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            stMensagem.Dock = DockStyle.None;
            stMensagem.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, statusLabelMensagem, toolStripStatusLabel3, statusLabel });
            stMensagem.Location = new Point(0, 539);
            stMensagem.Name = "stMensagem";
            stMensagem.Size = new Size(290, 22);
            stMensagem.TabIndex = 1;
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(71, 17);
            toolStripStatusLabel1.Text = "Mensagem:";
            // 
            // statusLabelMensagem
            // 
            statusLabelMensagem.Name = "statusLabelMensagem";
            statusLabelMensagem.Size = new Size(93, 17);
            statusLabelMensagem.Text = "Sem Mensagens";
            // 
            // toolStripStatusLabel3
            // 
            toolStripStatusLabel3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            toolStripStatusLabel3.Size = new Size(76, 17);
            toolStripStatusLabel3.Text = "Coordenada:";
            // 
            // statusLabel
            // 
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(33, 17);
            statusLabel.Text = "(0, 0)";
            // 
            // dlgAbrir
            // 
            dlgAbrir.FileName = "dlgAbrir";
            // 
            // pbAreaDesenho
            // 
            pbAreaDesenho.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pbAreaDesenho.Location = new Point(0, 35);
            pbAreaDesenho.Name = "pbAreaDesenho";
            pbAreaDesenho.Size = new Size(800, 501);
            pbAreaDesenho.TabIndex = 2;
            pbAreaDesenho.TabStop = false;
            pbAreaDesenho.Paint += pbAreaDesenho_Paint;
            pbAreaDesenho.MouseClick += pbAreaDesenho_MouseClick;
            pbAreaDesenho.MouseMove += pbAreaDesenho_MouseMove;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(368, 9);
            label1.Name = "label1";
            label1.Size = new Size(64, 15);
            label1.TabIndex = 4;
            label1.Text = "Selecionar:";
            // 
            // btnUnicaSelecao
            // 
            btnUnicaSelecao.Location = new Point(564, 6);
            btnUnicaSelecao.Name = "btnUnicaSelecao";
            btnUnicaSelecao.Size = new Size(108, 23);
            btnUnicaSelecao.TabIndex = 5;
            btnUnicaSelecao.Text = "Única Seleção";
            btnUnicaSelecao.UseVisualStyleBackColor = true;
            btnUnicaSelecao.Click += btnUnicaSelecao_Click;
            // 
            // btnTodasSelecoes
            // 
            btnTodasSelecoes.Location = new Point(678, 6);
            btnTodasSelecoes.Name = "btnTodasSelecoes";
            btnTodasSelecoes.Size = new Size(117, 23);
            btnTodasSelecoes.TabIndex = 6;
            btnTodasSelecoes.Text = "Todas as Seleções";
            btnTodasSelecoes.UseVisualStyleBackColor = true;
            btnTodasSelecoes.Click += btnTodasSelecoes_Click;
            // 
            // lbFiguraSelecionada
            // 
            lbFiguraSelecionada.FormattingEnabled = true;
            lbFiguraSelecionada.ItemHeight = 15;
            lbFiguraSelecionada.Location = new Point(438, 9);
            lbFiguraSelecionada.Name = "lbFiguraSelecionada";
            lbFiguraSelecionada.Size = new Size(120, 19);
            lbFiguraSelecionada.TabIndex = 7;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 561);
            Controls.Add(lbFiguraSelecionada);
            Controls.Add(btnTodasSelecoes);
            Controls.Add(btnUnicaSelecao);
            Controls.Add(label1);
            Controls.Add(pbAreaDesenho);
            Controls.Add(stMensagem);
            Controls.Add(toolStrip1);
            MinimumSize = new Size(600, 600);
            Name = "Form1";
            Text = "Desenho Gráfico";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            stMensagem.ResumeLayout(false);
            stMensagem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbAreaDesenho).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton btnAbrir;
        private ToolStripButton btnSalvar;
        private ToolStripButton btnPonto;
        private ToolStripButton btnReta;
        private ToolStripButton btnCirculo;
        private StatusStrip stMensagem;
        private OpenFileDialog dlgAbrir;
        private SaveFileDialog dlgSalvar;
        private ToolStripButton btnRetangulo;
        private ToolStripButton btnPolilinha;
        private ToolStripButton btnCor;
        private ToolStripButton btnSair;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripButton btnElipse;
        private PictureBox pbAreaDesenho;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel statusLabelMensagem;
        private ToolStripStatusLabel toolStripStatusLabel3;
        private ToolStripStatusLabel statusLabel;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripButton btnApagarTudo;
        private ColorDialog cdlgSelecionarCor;
        private Label label1;
        private Button btnUnicaSelecao;
        private Button btnTodasSelecoes;
        private ListBox lbFiguraSelecionada;
    }
}

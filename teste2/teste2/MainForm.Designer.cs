namespace LoginCadastroApp.WinForms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnCadastro = new System.Windows.Forms.Button();
            this.btnProdutos = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(341, 94);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(118, 23);
            this.btnLogin.TabIndex = 0;
            this.btnLogin.Text = "Fazer Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            // 
            // btnCadastro
            // 
            this.btnCadastro.Location = new System.Drawing.Point(341, 151);
            this.btnCadastro.Name = "btnCadastro";
            this.btnCadastro.Size = new System.Drawing.Size(118, 23);
            this.btnCadastro.TabIndex = 1;
            this.btnCadastro.Text = "Cadastrar Usuário";
            this.btnCadastro.UseVisualStyleBackColor = true;
            // 
            // btnProdutos
            // 
            this.btnProdutos.Location = new System.Drawing.Point(341, 215);
            this.btnProdutos.Name = "btnProdutos";
            this.btnProdutos.Size = new System.Drawing.Size(118, 23);
            this.btnProdutos.TabIndex = 2;
            this.btnProdutos.Text = "Ver Produtos";
            this.btnProdutos.UseVisualStyleBackColor = true;
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(341, 281);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(118, 23);
            this.btnSair.TabIndex = 3;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::teste2.Properties.Resources.c158bcf6_2fea_4c47_bb3b_45970bf17b7d;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnProdutos);
            this.Controls.Add(this.btnCadastro);
            this.Controls.Add(this.btnLogin);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnCadastro;
        private System.Windows.Forms.Button btnProdutos;
        private System.Windows.Forms.Button btnSair;
    }
}
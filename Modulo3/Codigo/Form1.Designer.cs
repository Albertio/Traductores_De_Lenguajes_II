
namespace AbyssC
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.console = new System.Windows.Forms.TextBox();
            this.Archivo = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Open = new System.Windows.Forms.ToolStripButton();
            this.Save = new System.Windows.Forms.ToolStripButton();
            this.Close = new System.Windows.Forms.ToolStripButton();
            this.Compile = new System.Windows.Forms.ToolStripButton();
            this.Run = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.Results = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Results_Sintactico = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Results_Console = new System.Windows.Forms.TextBox();
            this.Results_Semantico = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Archivo.SuspendLayout();
            this.SuspendLayout();
            // 
            // console
            // 
            this.console.AllowDrop = true;
            this.console.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.console.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.console.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.console.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.console.ForeColor = System.Drawing.Color.White;
            this.console.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.console.Location = new System.Drawing.Point(14, 57);
            this.console.Multiline = true;
            this.console.Name = "console";
            this.console.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.console.Size = new System.Drawing.Size(438, 309);
            this.console.TabIndex = 0;
            this.console.TabStop = false;
            this.console.WordWrap = false;
            // 
            // Archivo
            // 
            this.Archivo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Archivo.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Archivo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.Open,
            this.Save,
            this.Close,
            this.Compile,
            this.Run});
            this.Archivo.Location = new System.Drawing.Point(0, 0);
            this.Archivo.Name = "Archivo";
            this.Archivo.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.Archivo.Size = new System.Drawing.Size(1160, 25);
            this.Archivo.TabIndex = 1;
            this.Archivo.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // Open
            // 
            this.Open.AutoSize = false;
            this.Open.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Open.Image = ((System.Drawing.Image)(resources.GetObject("Open.Image")));
            this.Open.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Open.Margin = new System.Windows.Forms.Padding(0, 1, 10, 2);
            this.Open.Name = "Open";
            this.Open.Size = new System.Drawing.Size(20, 20);
            this.Open.Text = "Open";
            // 
            // Save
            // 
            this.Save.AutoSize = false;
            this.Save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Save.Image = ((System.Drawing.Image)(resources.GetObject("Save.Image")));
            this.Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Save.Margin = new System.Windows.Forms.Padding(0, 1, 10, 2);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(20, 20);
            this.Save.Text = "Save";
            // 
            // Close
            // 
            this.Close.AutoSize = false;
            this.Close.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Close.Image = ((System.Drawing.Image)(resources.GetObject("Close.Image")));
            this.Close.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Close.Margin = new System.Windows.Forms.Padding(0, 1, 30, 2);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(20, 20);
            this.Close.Text = "Close";
            // 
            // Compile
            // 
            this.Compile.AutoSize = false;
            this.Compile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Compile.Image = ((System.Drawing.Image)(resources.GetObject("Compile.Image")));
            this.Compile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Compile.Margin = new System.Windows.Forms.Padding(0, 1, 20, 2);
            this.Compile.Name = "Compile";
            this.Compile.Size = new System.Drawing.Size(20, 20);
            this.Compile.Text = "Compile";
            this.Compile.Click += new System.EventHandler(this.Compile_Click);
            // 
            // Run
            // 
            this.Run.AutoSize = false;
            this.Run.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Run.Image = ((System.Drawing.Image)(resources.GetObject("Run.Image")));
            this.Run.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Run.Name = "Run";
            this.Run.Size = new System.Drawing.Size(20, 20);
            this.Run.Text = "Run";
            this.Run.Click += new System.EventHandler(this.Run_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("p5hatty", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Console";
            // 
            // Results
            // 
            this.Results.AllowDrop = true;
            this.Results.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Results.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Results.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Results.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Results.ForeColor = System.Drawing.Color.White;
            this.Results.Location = new System.Drawing.Point(787, 57);
            this.Results.Multiline = true;
            this.Results.Name = "Results";
            this.Results.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Results.Size = new System.Drawing.Size(361, 142);
            this.Results.TabIndex = 3;
            this.Results.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("p5hatty", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(783, 202);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "Sintactico";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("p5hatty", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(783, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Lexico";
            // 
            // Results_Sintactico
            // 
            this.Results_Sintactico.AllowDrop = true;
            this.Results_Sintactico.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Results_Sintactico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Results_Sintactico.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Results_Sintactico.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Results_Sintactico.ForeColor = System.Drawing.Color.White;
            this.Results_Sintactico.Location = new System.Drawing.Point(787, 224);
            this.Results_Sintactico.Multiline = true;
            this.Results_Sintactico.Name = "Results_Sintactico";
            this.Results_Sintactico.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Results_Sintactico.Size = new System.Drawing.Size(361, 258);
            this.Results_Sintactico.TabIndex = 3;
            this.Results_Sintactico.TabStop = false;
            this.Results_Sintactico.WordWrap = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("p5hatty", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(12, 369);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 19);
            this.label4.TabIndex = 5;
            this.label4.Text = "Consola";
            // 
            // Results_Console
            // 
            this.Results_Console.AllowDrop = true;
            this.Results_Console.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Results_Console.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Results_Console.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Results_Console.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Results_Console.ForeColor = System.Drawing.Color.White;
            this.Results_Console.Location = new System.Drawing.Point(16, 391);
            this.Results_Console.Multiline = true;
            this.Results_Console.Name = "Results_Console";
            this.Results_Console.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Results_Console.Size = new System.Drawing.Size(436, 92);
            this.Results_Console.TabIndex = 6;
            this.Results_Console.TabStop = false;
            this.Results_Console.WordWrap = false;
            // 
            // Results_Semantico
            // 
            this.Results_Semantico.AllowDrop = true;
            this.Results_Semantico.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Results_Semantico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Results_Semantico.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Results_Semantico.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Results_Semantico.ForeColor = System.Drawing.Color.White;
            this.Results_Semantico.Location = new System.Drawing.Point(462, 57);
            this.Results_Semantico.Multiline = true;
            this.Results_Semantico.Name = "Results_Semantico";
            this.Results_Semantico.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Results_Semantico.Size = new System.Drawing.Size(315, 164);
            this.Results_Semantico.TabIndex = 7;
            this.Results_Semantico.TabStop = false;
            this.Results_Semantico.WordWrap = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("p5hatty", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(458, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 19);
            this.label5.TabIndex = 8;
            this.label5.Text = "Semantico";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("p5hatty", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(458, 226);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(160, 19);
            this.label6.TabIndex = 9;
            this.label6.Text = "Tabla de Simbolos";
            // 
            // textBox1
            // 
            this.textBox1.AllowDrop = true;
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox1.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(462, 248);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(315, 235);
            this.textBox1.TabIndex = 10;
            this.textBox1.TabStop = false;
            this.textBox1.WordWrap = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(1160, 494);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Results_Semantico);
            this.Controls.Add(this.Results_Console);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Results_Sintactico);
            this.Controls.Add(this.Results);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Archivo);
            this.Controls.Add(this.console);
            this.Font = new System.Drawing.Font("p5hatty", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.Window;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "AbyssC";
            this.Archivo.ResumeLayout(false);
            this.Archivo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox console;
        private System.Windows.Forms.ToolStrip Archivo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton Open;
        private System.Windows.Forms.ToolStripButton Save;
#pragma warning disable CS0108 // El miembro oculta el miembro heredado. Falta una contraseña nueva
        private System.Windows.Forms.ToolStripButton Close;
#pragma warning restore CS0108 // El miembro oculta el miembro heredado. Falta una contraseña nueva
        private System.Windows.Forms.ToolStripButton Compile;
        private System.Windows.Forms.ToolStripButton Run;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Results;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Results_Sintactico;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Results_Console;
        private System.Windows.Forms.TextBox Results_Semantico;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox1;
    }
}


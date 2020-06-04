namespace Quadratic_Solver
{
    partial class Form1
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
            this.a = new System.Windows.Forms.TextBox();
            this.b = new System.Windows.Forms.TextBox();
            this.c = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.output = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.round = new System.Windows.Forms.TextBox();
            this.graph = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.graph)).BeginInit();
            this.SuspendLayout();
            // 
            // a
            // 
            this.a.Location = new System.Drawing.Point(12, 12);
            this.a.Name = "a";
            this.a.Size = new System.Drawing.Size(53, 20);
            this.a.TabIndex = 0;
            this.a.Text = "0";
            this.a.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.a.TextChanged += new System.EventHandler(this.a_TextChanged);
            // 
            // b
            // 
            this.b.Location = new System.Drawing.Point(12, 39);
            this.b.Name = "b";
            this.b.Size = new System.Drawing.Size(53, 20);
            this.b.TabIndex = 1;
            this.b.Text = "0";
            this.b.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.b.TextChanged += new System.EventHandler(this.b_TextChanged);
            // 
            // c
            // 
            this.c.Location = new System.Drawing.Point(12, 65);
            this.c.Name = "c";
            this.c.Size = new System.Drawing.Size(53, 20);
            this.c.TabIndex = 2;
            this.c.Text = "0";
            this.c.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.c.TextChanged += new System.EventHandler(this.c_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "C";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "B";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(71, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "A";
            // 
            // output
            // 
            this.output.Location = new System.Drawing.Point(91, 38);
            this.output.Multiline = true;
            this.output.Name = "output";
            this.output.ReadOnly = true;
            this.output.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.output.Size = new System.Drawing.Size(257, 92);
            this.output.TabIndex = 6;
            this.output.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox5
            // 
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox5.Enabled = false;
            this.textBox5.Location = new System.Drawing.Point(91, 12);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(257, 20);
            this.textBox5.TabIndex = 7;
            this.textBox5.Text = "Answer:";
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Round To:";
            // 
            // round
            // 
            this.round.Location = new System.Drawing.Point(12, 110);
            this.round.Name = "round";
            this.round.Size = new System.Drawing.Size(53, 20);
            this.round.TabIndex = 4;
            this.round.Text = "2";
            this.round.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.round.TextChanged += new System.EventHandler(this.round_TextChanged);
            // 
            // graph
            // 
            this.graph.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.graph.Location = new System.Drawing.Point(12, 136);
            this.graph.Name = "graph";
            this.graph.Size = new System.Drawing.Size(336, 336);
            this.graph.TabIndex = 10;
            this.graph.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 484);
            this.Controls.Add(this.graph);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.round);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.output);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.c);
            this.Controls.Add(this.b);
            this.Controls.Add(this.a);
            this.Name = "Form1";
            this.Text = "Quadratic Solver";
            ((System.ComponentModel.ISupportInitialize)(this.graph)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox a;
        private System.Windows.Forms.TextBox b;
        private System.Windows.Forms.TextBox c;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox output;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox round;
        private System.Windows.Forms.PictureBox graph;
    }
}


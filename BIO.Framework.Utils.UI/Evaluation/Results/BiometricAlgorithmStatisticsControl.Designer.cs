namespace BIO.Framework.Utils.UI.Evaluation.Results {
    public partial class EvaluationStatisticsControl {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.radioButtonLower = new System.Windows.Forms.RadioButton();
            this.radioButtonHigher = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.labelTA = new System.Windows.Forms.Label();
            this.labelFA = new System.Windows.Forms.Label();
            this.labelTR = new System.Windows.Forms.Label();
            this.labelFR = new System.Windows.Forms.Label();
            this.labelIEa = new System.Windows.Forms.Label();
            this.labelGE = new System.Windows.Forms.Label();
            this.labelIE = new System.Windows.Forms.Label();
            this.labelE = new System.Windows.Forms.Label();
            this.labelFRR = new System.Windows.Forms.Label();
            this.labelFAR = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Statistics:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Extremes:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Genuine extremes";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Thresh:";
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(72, 127);
            this.trackBar1.Maximum = 1000;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(175, 45);
            this.trackBar1.TabIndex = 6;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(72, 101);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 7;
            // 
            // radioButtonLower
            // 
            this.radioButtonLower.AutoSize = true;
            this.radioButtonLower.Checked = true;
            this.radioButtonLower.Location = new System.Drawing.Point(72, 178);
            this.radioButtonLower.Name = "radioButtonLower";
            this.radioButtonLower.Size = new System.Drawing.Size(142, 17);
            this.radioButtonLower.TabIndex = 8;
            this.radioButtonLower.TabStop = true;
            this.radioButtonLower.Text = "accept lower then thresh";
            this.radioButtonLower.UseVisualStyleBackColor = true;
            this.radioButtonLower.CheckedChanged += new System.EventHandler(this.radioButtonLower_CheckedChanged);
            // 
            // radioButtonHigher
            // 
            this.radioButtonHigher.AutoSize = true;
            this.radioButtonHigher.Location = new System.Drawing.Point(72, 201);
            this.radioButtonHigher.Name = "radioButtonHigher";
            this.radioButtonHigher.Size = new System.Drawing.Size(146, 17);
            this.radioButtonHigher.TabIndex = 9;
            this.radioButtonHigher.Text = "accept higher then thresh";
            this.radioButtonHigher.UseVisualStyleBackColor = true;
            this.radioButtonHigher.CheckedChanged += new System.EventHandler(this.radioButtonHigher_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 233);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "TrueAcceptance:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 256);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "FalseAcceptance:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 278);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "TrueRejection:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 301);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "FalseRejection:";
            // 
            // labelTA
            // 
            this.labelTA.AutoSize = true;
            this.labelTA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.labelTA.Location = new System.Drawing.Point(99, 233);
            this.labelTA.Name = "labelTA";
            this.labelTA.Size = new System.Drawing.Size(43, 13);
            this.labelTA.TabIndex = 14;
            this.labelTA.Text = "labelTA";
            // 
            // labelFA
            // 
            this.labelFA.AutoSize = true;
            this.labelFA.ForeColor = System.Drawing.Color.Red;
            this.labelFA.Location = new System.Drawing.Point(99, 256);
            this.labelFA.Name = "labelFA";
            this.labelFA.Size = new System.Drawing.Size(35, 13);
            this.labelFA.TabIndex = 15;
            this.labelFA.Text = "label9";
            // 
            // labelTR
            // 
            this.labelTR.AutoSize = true;
            this.labelTR.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.labelTR.Location = new System.Drawing.Point(99, 278);
            this.labelTR.Name = "labelTR";
            this.labelTR.Size = new System.Drawing.Size(35, 13);
            this.labelTR.TabIndex = 16;
            this.labelTR.Text = "label9";
            // 
            // labelFR
            // 
            this.labelFR.AutoSize = true;
            this.labelFR.ForeColor = System.Drawing.Color.Red;
            this.labelFR.Location = new System.Drawing.Point(99, 301);
            this.labelFR.Name = "labelFR";
            this.labelFR.Size = new System.Drawing.Size(35, 13);
            this.labelFR.TabIndex = 17;
            this.labelFR.Text = "label9";
            // 
            // labelIEa
            // 
            this.labelIEa.AutoSize = true;
            this.labelIEa.Location = new System.Drawing.Point(4, 77);
            this.labelIEa.Name = "labelIEa";
            this.labelIEa.Size = new System.Drawing.Size(90, 13);
            this.labelIEa.TabIndex = 18;
            this.labelIEa.Text = "ImpostorExtremes";
            // 
            // labelGE
            // 
            this.labelGE.AutoSize = true;
            this.labelGE.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.labelGE.Location = new System.Drawing.Point(107, 52);
            this.labelGE.Name = "labelGE";
            this.labelGE.Size = new System.Drawing.Size(13, 13);
            this.labelGE.TabIndex = 19;
            this.labelGE.Text = "g";
            // 
            // labelIE
            // 
            this.labelIE.AutoSize = true;
            this.labelIE.ForeColor = System.Drawing.Color.Red;
            this.labelIE.Location = new System.Drawing.Point(107, 77);
            this.labelIE.Name = "labelIE";
            this.labelIE.Size = new System.Drawing.Size(9, 13);
            this.labelIE.TabIndex = 20;
            this.labelIE.Text = "i";
            // 
            // labelE
            // 
            this.labelE.AutoSize = true;
            this.labelE.Location = new System.Drawing.Point(107, 30);
            this.labelE.Name = "labelE";
            this.labelE.Size = new System.Drawing.Size(59, 13);
            this.labelE.TabIndex = 4;
            this.labelE.Text = "Max value:";
            // 
            // labelFRR
            // 
            this.labelFRR.AutoSize = true;
            this.labelFRR.ForeColor = System.Drawing.Color.Navy;
            this.labelFRR.Location = new System.Drawing.Point(99, 345);
            this.labelFRR.Name = "labelFRR";
            this.labelFRR.Size = new System.Drawing.Size(35, 13);
            this.labelFRR.TabIndex = 24;
            this.labelFRR.Text = "label9";
            // 
            // labelFAR
            // 
            this.labelFAR.AutoSize = true;
            this.labelFAR.ForeColor = System.Drawing.Color.Navy;
            this.labelFAR.Location = new System.Drawing.Point(99, 322);
            this.labelFAR.Name = "labelFAR";
            this.labelFAR.Size = new System.Drawing.Size(35, 13);
            this.labelFAR.TabIndex = 23;
            this.labelFAR.Text = "label9";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 345);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 13);
            this.label11.TabIndex = 22;
            this.label11.Text = "FRR:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(4, 322);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(31, 13);
            this.label12.TabIndex = 21;
            this.label12.Text = "FAR:";
            // 
            // EvaluationStatisticsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelFRR);
            this.Controls.Add(this.labelFAR);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.labelIE);
            this.Controls.Add(this.labelGE);
            this.Controls.Add(this.labelIEa);
            this.Controls.Add(this.labelFR);
            this.Controls.Add(this.labelTR);
            this.Controls.Add(this.labelFA);
            this.Controls.Add(this.labelTA);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.radioButtonHigher);
            this.Controls.Add(this.radioButtonLower);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelE);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "EvaluationStatisticsControl";
            this.Size = new System.Drawing.Size(250, 369);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RadioButton radioButtonLower;
        private System.Windows.Forms.RadioButton radioButtonHigher;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelTA;
        private System.Windows.Forms.Label labelFA;
        private System.Windows.Forms.Label labelTR;
        private System.Windows.Forms.Label labelFR;
        private System.Windows.Forms.Label labelIEa;
        private System.Windows.Forms.Label labelGE;
        private System.Windows.Forms.Label labelIE;
        private System.Windows.Forms.Label labelE;
        private System.Windows.Forms.Label labelFRR;
        private System.Windows.Forms.Label labelFAR;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
    }
}

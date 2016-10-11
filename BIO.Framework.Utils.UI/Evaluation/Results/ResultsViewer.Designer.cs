namespace BIO.Framework.Utils.UI.Evaluation.Results {
    partial class ResultsViewer {
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.evaluationStatisticsControl1 = new BIO.Framework.Utils.UI.Evaluation.Results.EvaluationStatisticsControl();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageGI = new System.Windows.Forms.TabPage();
            this.evaluatorGenuineImpostorResultGraph1 = new BIO.Framework.Utils.UI.Evaluation.Results.EvaluatorGenuineImpostorResultGraph();
            this.tabPageDD = new System.Windows.Forms.TabPage();
            this.evaluatorDetailResultGraph1 = new BIO.Framework.Utils.UI.Evaluation.Results.BiometricAlgorithmDetailResultGraph();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageGI.SuspendLayout();
            this.tabPageDD.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 262F));
            this.tableLayoutPanel1.Controls.Add(this.evaluationStatisticsControl1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 294F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(687, 294);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // evaluationStatisticsControl1
            // 
            this.evaluationStatisticsControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.evaluationStatisticsControl1.Location = new System.Drawing.Point(428, 3);
            this.evaluationStatisticsControl1.Name = "evaluationStatisticsControl1";
            this.evaluationStatisticsControl1.Size = new System.Drawing.Size(256, 288);
            this.evaluationStatisticsControl1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageGI);
            this.tabControl1.Controls.Add(this.tabPageDD);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(419, 288);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPageGI
            // 
            this.tabPageGI.Controls.Add(this.evaluatorGenuineImpostorResultGraph1);
            this.tabPageGI.Location = new System.Drawing.Point(4, 22);
            this.tabPageGI.Name = "tabPageGI";
            this.tabPageGI.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGI.Size = new System.Drawing.Size(411, 262);
            this.tabPageGI.TabIndex = 0;
            this.tabPageGI.Text = "Genuine x Impostor";
            this.tabPageGI.UseVisualStyleBackColor = true;
            // 
            // evaluatorGenuineImpostorResultGraph1
            // 
            this.evaluatorGenuineImpostorResultGraph1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.evaluatorGenuineImpostorResultGraph1.Location = new System.Drawing.Point(3, 3);
            this.evaluatorGenuineImpostorResultGraph1.Name = "evaluatorGenuineImpostorResultGraph1";
            this.evaluatorGenuineImpostorResultGraph1.Size = new System.Drawing.Size(405, 256);
            this.evaluatorGenuineImpostorResultGraph1.TabIndex = 0;
            // 
            // tabPageDD
            // 
            this.tabPageDD.Controls.Add(this.evaluatorDetailResultGraph1);
            this.tabPageDD.Location = new System.Drawing.Point(4, 22);
            this.tabPageDD.Name = "tabPageDD";
            this.tabPageDD.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDD.Size = new System.Drawing.Size(411, 262);
            this.tabPageDD.TabIndex = 1;
            this.tabPageDD.Text = "Distance detail";
            this.tabPageDD.UseVisualStyleBackColor = true;
            // 
            // evaluatorDetailResultGraph1
            // 
            this.evaluatorDetailResultGraph1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.evaluatorDetailResultGraph1.Location = new System.Drawing.Point(3, 3);
            this.evaluatorDetailResultGraph1.Name = "evaluatorDetailResultGraph1";
            this.evaluatorDetailResultGraph1.Size = new System.Drawing.Size(405, 256);
            this.evaluatorDetailResultGraph1.TabIndex = 0;
            // 
            // ResultsViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ResultsViewer";
            this.Size = new System.Drawing.Size(687, 294);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPageGI.ResumeLayout(false);
            this.tabPageDD.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private EvaluationStatisticsControl evaluationStatisticsControl1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageGI;
        private System.Windows.Forms.TabPage tabPageDD;
        private BiometricAlgorithmDetailResultGraph evaluatorDetailResultGraph1;
        public EvaluatorGenuineImpostorResultGraph evaluatorGenuineImpostorResultGraph1;
    }
}

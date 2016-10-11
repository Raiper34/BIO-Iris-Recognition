namespace BIO.Framework.Utils.UI.Evaluation.Results {
    partial class MultipleEvaluatorDataVisualizer {
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
            this.backgroundWorkerCOMPUTE = new System.ComponentModel.BackgroundWorker();
            this.button1 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panelToAddThings = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // backgroundWorkerCOMPUTE
            // 
            this.backgroundWorkerCOMPUTE.WorkerReportsProgress = true;
            this.backgroundWorkerCOMPUTE.WorkerSupportsCancellation = true;
            this.backgroundWorkerCOMPUTE.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerCOMPUTE_DoWork);
            this.backgroundWorkerCOMPUTE.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerCOMPUTE_RunWorkerCompleted);
            this.backgroundWorkerCOMPUTE.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerCOMPUTE_ProgressChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Compute ...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(137, 3);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(323, 23);
            this.progressBar1.TabIndex = 1;
            // 
            // panelToAddThings
            // 
            this.panelToAddThings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelToAddThings.Location = new System.Drawing.Point(0, 0);
            this.panelToAddThings.Name = "panelToAddThings";
            this.panelToAddThings.Padding = new System.Windows.Forms.Padding(0, 31, 0, 0);
            this.panelToAddThings.Size = new System.Drawing.Size(472, 226);
            this.panelToAddThings.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.progressBar1);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(472, 31);
            this.panel2.TabIndex = 2;
            // 
            // MultipleEvaluatorDataVisualizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelToAddThings);
            this.Name = "MultipleEvaluatorDataVisualizer";
            this.Size = new System.Drawing.Size(472, 226);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button button1;
        private System.ComponentModel.BackgroundWorker backgroundWorkerCOMPUTE;
        protected internal System.Windows.Forms.Panel panelToAddThings;
        private System.Windows.Forms.Panel panel2;

    }
}

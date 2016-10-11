namespace BIO.Framework.Utils.UI.Evaluation.Results {
    partial class ResultsForm {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageResults = new System.Windows.Forms.TabPage();
            this.tabControlMethods = new System.Windows.Forms.TabControl();
            this.tabPageDET = new System.Windows.Forms.TabPage();
            this.evaluatorsDETGraph1 = new BIO.Framework.Utils.UI.Evaluation.Results.EvaluatorsDETGraph();
            this.tabPageROC = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.evaluatorsDETGraph2 = new BIO.Framework.Utils.UI.Evaluation.Results.EvaluatorsDETGraph();
            this.evaluatorsROCGraph1 = new BIO.Framework.Utils.UI.Evaluation.Results.EvaluatorsROCGraph();
            this.tabControlMain.SuspendLayout();
            this.tabPageResults.SuspendLayout();
            this.tabPageDET.SuspendLayout();
            this.tabPageROC.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageResults);
            this.tabControlMain.Controls.Add(this.tabPageDET);
            this.tabControlMain.Controls.Add(this.tabPageROC);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(691, 262);
            this.tabControlMain.TabIndex = 0;
            // 
            // tabPageResults
            // 
            this.tabPageResults.Controls.Add(this.tabControlMethods);
            this.tabPageResults.Location = new System.Drawing.Point(4, 22);
            this.tabPageResults.Name = "tabPageResults";
            this.tabPageResults.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageResults.Size = new System.Drawing.Size(683, 236);
            this.tabPageResults.TabIndex = 0;
            this.tabPageResults.Text = "Results";
            this.tabPageResults.UseVisualStyleBackColor = true;
            // 
            // tabControlMethods
            // 
            this.tabControlMethods.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMethods.Location = new System.Drawing.Point(3, 3);
            this.tabControlMethods.Name = "tabControlMethods";
            this.tabControlMethods.SelectedIndex = 0;
            this.tabControlMethods.Size = new System.Drawing.Size(677, 230);
            this.tabControlMethods.TabIndex = 0;
            // 
            // tabPageDET
            // 
            this.tabPageDET.Controls.Add(this.evaluatorsDETGraph1);
            this.tabPageDET.Location = new System.Drawing.Point(4, 22);
            this.tabPageDET.Name = "tabPageDET";
            this.tabPageDET.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDET.Size = new System.Drawing.Size(683, 236);
            this.tabPageDET.TabIndex = 1;
            this.tabPageDET.Text = "DET Curves";
            this.tabPageDET.UseVisualStyleBackColor = true;
            // 
            // evaluatorsDETGraph1
            // 
            this.evaluatorsDETGraph1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.evaluatorsDETGraph1.Location = new System.Drawing.Point(3, 3);
            this.evaluatorsDETGraph1.Name = "evaluatorsDETGraph1";
            this.evaluatorsDETGraph1.Size = new System.Drawing.Size(677, 230);
            this.evaluatorsDETGraph1.TabIndex = 0;
            // 
            // tabPageROC
            // 
            this.tabPageROC.Controls.Add(this.evaluatorsROCGraph1);
            this.tabPageROC.Location = new System.Drawing.Point(4, 22);
            this.tabPageROC.Name = "tabPageROC";
            this.tabPageROC.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageROC.Size = new System.Drawing.Size(683, 236);
            this.tabPageROC.TabIndex = 2;
            this.tabPageROC.Text = "ROC Curves";
            this.tabPageROC.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tabControl2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(683, 236);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Results";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(3, 3);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(677, 230);
            this.tabControl2.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.evaluatorsDETGraph2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(683, 236);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "DET Curves";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // evaluatorsDETGraph2
            // 
            this.evaluatorsDETGraph2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.evaluatorsDETGraph2.Location = new System.Drawing.Point(3, 3);
            this.evaluatorsDETGraph2.Name = "evaluatorsDETGraph2";
            this.evaluatorsDETGraph2.Size = new System.Drawing.Size(677, 230);
            this.evaluatorsDETGraph2.TabIndex = 0;
            // 
            // evaluatorsROCGraph1
            // 
            this.evaluatorsROCGraph1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.evaluatorsROCGraph1.Location = new System.Drawing.Point(3, 3);
            this.evaluatorsROCGraph1.Name = "evaluatorsROCGraph1";
            this.evaluatorsROCGraph1.Size = new System.Drawing.Size(677, 230);
            this.evaluatorsROCGraph1.TabIndex = 0;
            // 
            // ResultsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 262);
            this.Controls.Add(this.tabControlMain);
            this.Name = "ResultsForm";
            this.Text = "ResultsForm";
            this.tabControlMain.ResumeLayout(false);
            this.tabPageResults.ResumeLayout(false);
            this.tabPageDET.ResumeLayout(false);
            this.tabPageROC.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageResults;
        private System.Windows.Forms.TabControl tabControlMethods;
        private System.Windows.Forms.TabPage tabPageDET;
        private EvaluatorsDETGraph evaluatorsDETGraph1;
        private System.Windows.Forms.TabPage tabPageROC;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage2;
        private EvaluatorsDETGraph evaluatorsDETGraph2;
        private EvaluatorsROCGraph evaluatorsROCGraph1;

    }
}
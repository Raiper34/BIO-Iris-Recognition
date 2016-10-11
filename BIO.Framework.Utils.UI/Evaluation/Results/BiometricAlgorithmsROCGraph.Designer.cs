namespace BIO.Framework.Utils.UI.Evaluation.Results {
    partial class EvaluatorsROCGraph {
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
            this.components = new System.ComponentModel.Container();
            this.zedGraphControlROC = new ZedGraph.ZedGraphControl();
            this.panelToAddThings.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelToAddThings
            // 
            this.panelToAddThings.Controls.Add(this.zedGraphControlROC);
            this.panelToAddThings.Size = new System.Drawing.Size(603, 330);
            // 
            // zedGraphControlDET
            // 
            this.zedGraphControlROC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraphControlROC.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.zedGraphControlROC.Location = new System.Drawing.Point(0, 31);
            this.zedGraphControlROC.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.zedGraphControlROC.Name = "zedGraphControlROC";
            this.zedGraphControlROC.ScrollGrace = 0;
            this.zedGraphControlROC.ScrollMaxX = 0;
            this.zedGraphControlROC.ScrollMaxY = 0;
            this.zedGraphControlROC.ScrollMaxY2 = 0;
            this.zedGraphControlROC.ScrollMinX = 0;
            this.zedGraphControlROC.ScrollMinY = 0;
            this.zedGraphControlROC.ScrollMinY2 = 0;
            this.zedGraphControlROC.Size = new System.Drawing.Size(603, 299);
            this.zedGraphControlROC.TabIndex = 0;
            // 
            // EvaluatorsDETGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "EvaluatorsROCGraph";
            this.Size = new System.Drawing.Size(603, 330);
            this.panelToAddThings.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraphControlROC;


    }
}

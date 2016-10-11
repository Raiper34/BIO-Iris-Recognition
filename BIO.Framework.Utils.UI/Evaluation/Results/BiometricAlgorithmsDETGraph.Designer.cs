namespace BIO.Framework.Utils.UI.Evaluation.Results {
    partial class EvaluatorsDETGraph {
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
            this.zedGraphControlDET = new ZedGraph.ZedGraphControl();
            this.panelToAddThings.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelToAddThings
            // 
            this.panelToAddThings.Controls.Add(this.zedGraphControlDET);
            this.panelToAddThings.Size = new System.Drawing.Size(603, 330);
            // 
            // zedGraphControlDET
            // 
            this.zedGraphControlDET.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraphControlDET.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.zedGraphControlDET.Location = new System.Drawing.Point(0, 31);
            this.zedGraphControlDET.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.zedGraphControlDET.Name = "zedGraphControlDET";
            this.zedGraphControlDET.ScrollGrace = 0;
            this.zedGraphControlDET.ScrollMaxX = 0;
            this.zedGraphControlDET.ScrollMaxY = 0;
            this.zedGraphControlDET.ScrollMaxY2 = 0;
            this.zedGraphControlDET.ScrollMinX = 0;
            this.zedGraphControlDET.ScrollMinY = 0;
            this.zedGraphControlDET.ScrollMinY2 = 0;
            this.zedGraphControlDET.Size = new System.Drawing.Size(603, 299);
            this.zedGraphControlDET.TabIndex = 0;
            // 
            // EvaluatorsDETGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "EvaluatorsDETGraph";
            this.Size = new System.Drawing.Size(603, 330);
            this.panelToAddThings.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraphControlDET;


    }
}

﻿namespace MapEditor
{
	partial class ToolBarWindow
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
			if(disposing && (components != null))
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
			this.SuspendLayout();
			// 
			// ToolBarWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(229, 524);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(245, 562);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(245, 562);
			this.Name = "ToolBarWindow";
			this.Text = "Terrain tool bar";
			this.ResumeLayout(false);

		}

		#endregion
	}
}
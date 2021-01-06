
using System.Drawing;

namespace meeting_test
{
    partial class Main_Menu
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.新建会议ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.账号ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.注销ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.新建会议ToolStripMenuItem, this.账号ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(871, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 新建会议ToolStripMenuItem
            // 
            this.新建会议ToolStripMenuItem.Name = "新建会议ToolStripMenuItem";
            this.新建会议ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.新建会议ToolStripMenuItem.Text = "新建会议";
            this.新建会议ToolStripMenuItem.Click += new System.EventHandler(this.新建会议ToolStripMenuItem_Click);
            // 
            // 账号ToolStripMenuItem
            // 
            this.账号ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.注销ToolStripMenuItem});
            this.账号ToolStripMenuItem.Name = "账号ToolStripMenuItem";
            this.账号ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.账号ToolStripMenuItem.Text = "账号";
            this.账号ToolStripMenuItem.Click += new System.EventHandler(this.账号ToolStripMenuItem_Click);
            // 
            // 注销ToolStripMenuItem
            // 
            this.注销ToolStripMenuItem.Name = "注销ToolStripMenuItem";
            this.注销ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.注销ToolStripMenuItem.Text = "注销";
            this.注销ToolStripMenuItem.Click += new System.EventHandler(this.注销ToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Window;
            this.splitContainer1.Panel1.Controls.Add(this.button2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Size = new System.Drawing.Size(871, 411);
            this.splitContainer1.SplitterDistance = 173;
            this.splitContainer1.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Window;
            this.button2.Location = new System.Drawing.Point(3, 32);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(150, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "已提交任务";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 388);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Window;
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "待办任务";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Main_Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(871, 436);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main_Menu";
            this.Opacity = 0.9D;
            this.ShowInTaskbar = false;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Main_Menu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ToolStripMenuItem 注销ToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem 账号ToolStripMenuItem;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.Button button2;

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.SplitContainer splitContainer1;

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 新建会议ToolStripMenuItem;
    }
}
// Created by Anton Piruev in 2026. 
// Any direct commercial use of derivative work is strictly prohibited.

using System;

namespace AccountManager.Forms
{
  partial class DeleteDialog
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
      this.messageLabel = new System.Windows.Forms.Label();
      this.confirmButton = new System.Windows.Forms.Button();
      this.cancelButton = new System.Windows.Forms.Button();
      this.buttonPanel = new System.Windows.Forms.Panel();
      this.buttonPanel.SuspendLayout();
      this.SuspendLayout();
      // 
      // messageLabel
      // 
      this.messageLabel.Location = new System.Drawing.Point(12, 20);
      this.messageLabel.Name = "messageLabel";
      this.messageLabel.Size = new System.Drawing.Size(360, 50);
      this.messageLabel.TabIndex = 0;
      this.messageLabel.Text = "Вы уверены?";
      this.messageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // confirmButton
      // 
      this.confirmButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
      this.confirmButton.Dock = System.Windows.Forms.DockStyle.Right;
      this.confirmButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.confirmButton.ForeColor = System.Drawing.Color.White;
      this.confirmButton.Location = new System.Drawing.Point(284, 5);
      this.confirmButton.Name = "confirmButton";
      this.confirmButton.Size = new System.Drawing.Size(90, 35);
      this.confirmButton.TabIndex = 1;
      this.confirmButton.Text = "Удалить";
      this.confirmButton.UseVisualStyleBackColor = false;
      this.confirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
      // 
      // cancelButton
      // 
      this.cancelButton.Dock = System.Windows.Forms.DockStyle.Right;
      this.cancelButton.Location = new System.Drawing.Point(204, 5);
      this.cancelButton.Name = "cancelButton";
      this.cancelButton.Size = new System.Drawing.Size(80, 35);
      this.cancelButton.TabIndex = 0;
      this.cancelButton.Text = "Отмена";
      this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
      // 
      // buttonPanel
      // 
      this.buttonPanel.Controls.Add(this.cancelButton);
      this.buttonPanel.Controls.Add(this.confirmButton);
      this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.buttonPanel.Location = new System.Drawing.Point(0, 85);
      this.buttonPanel.Name = "buttonPanel";
      this.buttonPanel.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
      this.buttonPanel.Size = new System.Drawing.Size(384, 45);
      this.buttonPanel.TabIndex = 1;
      // 
      // DeleteDialog
      // 
      this.ClientSize = new System.Drawing.Size(384, 130);
      this.Controls.Add(this.messageLabel);
      this.Controls.Add(this.buttonPanel);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "DeleteDialog";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Удаление пользователя";
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DeleteDialog_FormClosed);
      this.buttonPanel.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label messageLabel;
    private System.Windows.Forms.Button confirmButton;
    private System.Windows.Forms.Button cancelButton;
    private System.Windows.Forms.Panel buttonPanel;
  }
}

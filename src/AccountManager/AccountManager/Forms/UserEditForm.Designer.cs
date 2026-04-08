// Created by Anton Piruev in 2026. 
// Any direct commercial use of derivative work is strictly prohibited.

using System;

namespace AccountManager.Forms
{
  partial class UserEditForm
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
      this.components = new System.ComponentModel.Container();
      this.tableLayout = new System.Windows.Forms.TableLayoutPanel();
      this.labelFirstName = new System.Windows.Forms.Label();
      this.firstNameBox = new System.Windows.Forms.TextBox();
      this.labelLastName = new System.Windows.Forms.Label();
      this.lastNameBox = new System.Windows.Forms.TextBox();
      this.labelEmail = new System.Windows.Forms.Label();
      this.emailBox = new System.Windows.Forms.TextBox();
      this.labelPhone = new System.Windows.Forms.Label();
      this.phoneBox = new System.Windows.Forms.TextBox();
      this.labelBirthDate = new System.Windows.Forms.Label();
      this.birthDatePicker = new System.Windows.Forms.DateTimePicker();
      this.buttonPanel = new System.Windows.Forms.Panel();
      this.saveButton = new System.Windows.Forms.Button();
      this.cancelButton = new System.Windows.Forms.Button();
      this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);

      this.tableLayout.SuspendLayout();
      this.buttonPanel.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
      this.SuspendLayout();

      // ── tableLayout ────────────────────────────────────────────
      // Две колонки: Label (авто) + TextBox (заполняет остаток)
      // Пять строк — по одной на каждое поле
      this.tableLayout.ColumnCount = 2;
      this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(
          System.Windows.Forms.SizeType.Absolute, 110F));
      this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(
          System.Windows.Forms.SizeType.Percent, 100F));

      this.tableLayout.RowCount = 5;
      this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
      this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
      this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
      this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
      this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));

      this.tableLayout.Controls.Add(this.labelFirstName, 0, 0);
      this.tableLayout.Controls.Add(this.firstNameBox, 1, 0);
      this.tableLayout.Controls.Add(this.labelLastName, 0, 1);
      this.tableLayout.Controls.Add(this.lastNameBox, 1, 1);
      this.tableLayout.Controls.Add(this.labelEmail, 0, 2);
      this.tableLayout.Controls.Add(this.emailBox, 1, 2);
      this.tableLayout.Controls.Add(this.labelPhone, 0, 3);
      this.tableLayout.Controls.Add(this.phoneBox, 1, 3);
      this.tableLayout.Controls.Add(this.labelBirthDate, 0, 4);
      this.tableLayout.Controls.Add(this.birthDatePicker, 1, 4);

      this.tableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayout.Padding = new System.Windows.Forms.Padding(10);
      this.tableLayout.Name = "tableLayout";

      // ── Labels ─────────────────────────────────────────────────
      this.labelFirstName.Text = "Имя:";
      this.labelFirstName.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.labelFirstName.Name = "labelFirstName";

      this.labelLastName.Text = "Фамилия:";
      this.labelLastName.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.labelLastName.Name = "labelLastName";

      this.labelEmail.Text = "Email:";
      this.labelEmail.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.labelEmail.Name = "labelEmail";

      this.labelPhone.Text = "Телефон:";
      this.labelPhone.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.labelPhone.Name = "labelPhone";

      this.labelBirthDate.Text = "Дата рождения:";
      this.labelBirthDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
      this.labelBirthDate.Name = "labelBirthDate";

      // ── TextBox-ы ──────────────────────────────────────────────
      // Общие настройки: Anchor = Left|Right чтобы тянулись по ширине колонки
      System.Windows.Forms.AnchorStyles fillRow =
          System.Windows.Forms.AnchorStyles.Left |
          System.Windows.Forms.AnchorStyles.Right;

      this.firstNameBox.Anchor = fillRow;
      this.firstNameBox.Name = "firstNameBox";

      this.lastNameBox.Anchor = fillRow;
      this.lastNameBox.Name = "lastNameBox";

      this.emailBox.Anchor = fillRow;
      this.emailBox.Name = "emailBox";

      this.phoneBox.Anchor = fillRow;
      this.phoneBox.Name = "phoneBox";

      // ── birthDatePicker ────────────────────────────────────────
      this.birthDatePicker.Anchor = fillRow;
      this.birthDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
      this.birthDatePicker.Name = "birthDatePicker";

      // ── buttonPanel ────────────────────────────────────────────
      this.buttonPanel.Controls.Add(this.cancelButton);
      this.buttonPanel.Controls.Add(this.saveButton);
      this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.buttonPanel.Height = 45;
      this.buttonPanel.Name = "buttonPanel";
      this.buttonPanel.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);

      // ── saveButton ─────────────────────────────────────────────
      this.saveButton.Text = "Сохранить";
      this.saveButton.Dock = System.Windows.Forms.DockStyle.Right;
      this.saveButton.Width = 110;
      this.saveButton.Name = "saveButton";
      this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);

      // ── cancelButton ───────────────────────────────────────────
      this.cancelButton.Text = "Отмена";
      this.cancelButton.Dock = System.Windows.Forms.DockStyle.Right;
      this.cancelButton.Width = 90;
      this.cancelButton.Name = "cancelButton";
      this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);

      // ── errorProvider ──────────────────────────────────────────
      this.errorProvider.ContainerControl = this;

      // ── UserEditForm ───────────────────────────────────────────
      this.ClientSize = new System.Drawing.Size(380, 260);
      this.Controls.Add(this.tableLayout);
      this.Controls.Add(this.buttonPanel);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "UserEditForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Пользователь";   // переопределяется в конструкторе

      this.tableLayout.ResumeLayout(false);
      this.tableLayout.PerformLayout();
      this.buttonPanel.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
      this.ResumeLayout(false);
    }

    #endregion

    // ── поля ───────────────────────────────────────────────────────
    private System.Windows.Forms.TableLayoutPanel tableLayout;
    private System.Windows.Forms.Label labelFirstName;
    private System.Windows.Forms.TextBox firstNameBox;
    private System.Windows.Forms.Label labelLastName;
    private System.Windows.Forms.TextBox lastNameBox;
    private System.Windows.Forms.Label labelEmail;
    private System.Windows.Forms.TextBox emailBox;
    private System.Windows.Forms.Label labelPhone;
    private System.Windows.Forms.TextBox phoneBox;
    private System.Windows.Forms.Label labelBirthDate;
    private System.Windows.Forms.DateTimePicker birthDatePicker;
    private System.Windows.Forms.Panel buttonPanel;
    private System.Windows.Forms.Button saveButton;
    private System.Windows.Forms.Button cancelButton;
    private System.Windows.Forms.ErrorProvider errorProvider;
  }
}

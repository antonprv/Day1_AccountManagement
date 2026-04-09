// Created by Anton Piruev in 2026. 
// Any direct commercial use of derivative work is strictly prohibited.

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AccountManager.Forms
{
  public partial class UserEditForm : Form
  {
    internal Models.User Result => _userResult;

    private Models.User _userResult;

    private Dictionary<string, string> _fields;

    public UserEditForm()
    {
      InitializeComponent();

      Text = "Добавить пользователя";
    }

    public UserEditForm(Models.User user)
    {
      if (user == null)
        throw new ArgumentNullException("user");

      InitializeComponent();

      firstNameBox.Text = user.FirstName;
      lastNameBox.Text = user.LastName;
      emailBox.Text = user.Email;
      phoneBox.Text = user.Phone;
      birthDatePicker.Value = user.BirthDate;

      Text = "Редактировать пользователя";
    }

    private void CancelButton_Click(object sender, EventArgs e)
    {
      _userResult?.Clear();

      DialogResult = DialogResult.Cancel;
      Close();
    }

    private void SaveButton_Click(object sender, EventArgs e)
    {
      RegisterFields(out bool valid);
      if (!valid) return;

      _userResult = new Models.User(
        firstName: firstNameBox.Text,
        lastName: lastNameBox.Text,
        email: emailBox.Text,
        phone: phoneBox.Text,
        birthDate: birthDatePicker.Value
        );

      DialogResult = DialogResult.OK;
      Close();
    }

    #region Fields Registration

    private void RegisterFields(out bool valid)
    {
      _fields = new Dictionary<string, string>
      {
        { "Имя", firstNameBox.Text },
        { "Фамилия", lastNameBox.Text },
        { "Email", emailBox.Text },
        { "Телефон", phoneBox.Text },
        { "Дата рождения", birthDatePicker.Text }
      };

      valid = ValidateFields();
    }

    private bool ValidateFields()
    {
      foreach (var item in _fields)
      {
        if (string.IsNullOrEmpty(item.Value))
        {
          MessageBox.Show(
            $"Неправильно введено поле: {item.Key}.",
            "Ошибка",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error
            );

          return false;
        }
      }

      return true;
    }

    #endregion

    private void UserEditForm_FormClosed(object sender, FormClosedEventArgs e)
    {
      cancelButton.Click -= CancelButton_Click;
      saveButton.Click -= SaveButton_Click;
    }
  }
}

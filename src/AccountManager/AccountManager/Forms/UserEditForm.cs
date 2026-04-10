// Created by Anton Piruev in 2026. 
// Any direct commercial use of derivative work is strictly prohibited.

using System;
using System.Collections.Generic;
using System.Windows.Forms;

using AccountManager.Services;

namespace AccountManager.Forms
{
  public partial class UserEditForm : Form
  {
    internal Models.User Result => _userResult;

    private Models.User _userResult;

    private Dictionary<string, KeyValuePair<string, bool>> _fields;

    private bool _validFirstName;
    private bool _validLastName;
    private bool _validEmail;
    private bool _validPhone;

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
      ValidateChildren();

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
      _fields = new Dictionary<string, KeyValuePair<string, bool>>
      {
        {
          "Имя",
          new KeyValuePair<string, bool>(firstNameBox.Text, _validFirstName)
        },

        {
          "Фамилия",
          new KeyValuePair<string, bool>(lastNameBox.Text, _validLastName)
        },

        {
          "Email",
          new KeyValuePair<string, bool>(emailBox.Text, _validEmail)
        },

        {
          "Телефон",
          new KeyValuePair<string, bool>(phoneBox.Text, _validPhone)
        },

        {
          "Дата рождения",
          new KeyValuePair<string, bool>(birthDatePicker.Text, true)
        }
      };

      valid = ValidateFields();
    }

    private bool ValidateFields()
    {
      foreach (var item in _fields)
      {
        var fieldName = item.Value.Key;
        var valid = item.Value.Value;

        if (string.IsNullOrWhiteSpace(fieldName))
        {
          ShowErrorBox(item);
          return false;
        }
        else if (!valid)
        {
          ShowErrorBox(item);
          return false;
        }
      }

      return true;
    }

    private static void ShowErrorBox(KeyValuePair<string, KeyValuePair<string, bool>> item)
    {
      MessageBox.Show(
        $"Неправильно введено поле: {item.Key}.",
        "Ошибка",
        MessageBoxButtons.OK,
        MessageBoxIcon.Error
        );
    }

    #endregion

    private void UserEditForm_FormClosed(object sender, FormClosedEventArgs e)
    {
      cancelButton.Click -= CancelButton_Click;
      saveButton.Click -= SaveButton_Click;
    }

    #region Per-form validation

    private void FirstNameBox_Validating(object sender, System.ComponentModel.CancelEventArgs e) =>
      _validFirstName = Validator.IsValidName(firstNameBox.Text);

    private void LastNameBox_Validating(object sender, System.ComponentModel.CancelEventArgs e) =>
      _validLastName = Validator.IsValidName(lastNameBox.Text);

    private void EmailBox_Validating(object sender, System.ComponentModel.CancelEventArgs e) =>
      _validEmail = Validator.IsValidEmail(emailBox.Text);

    private void PhoneBox_Validating(object sender, System.ComponentModel.CancelEventArgs e) =>
      _validPhone = Validator.IsValidPhone(phoneBox.Text);

    #endregion
  }
}

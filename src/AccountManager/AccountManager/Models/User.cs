// Created by Anton Piruev in 2026. 
// Any direct commercial use of derivative work is strictly prohibited.

using System;
using System.ComponentModel;

namespace AccountManager.Models
{
  public class User
  {
    public User() => InitProperties();

    public User(
      string firstName,
      string lastName,
      string email,
      string phone,
      DateTime birthDate
      )
    {
      FirstName = firstName;
      LastName = lastName;
      Email = email;
      Phone = phone;
      BirthDate = birthDate;
    }

    [DisplayName("Имя")]
    public string FirstName { get; set; }
    [DisplayName("Фамилия")]
    public string LastName { get; set; }
    [DisplayName("email")]
    public string Email { get; set; }
    [DisplayName("Телефон")]
    public string Phone { get; set; }
    [DisplayName("Дата рождения")]
    public DateTime BirthDate { get; set; }

    public override string ToString() => $"{LastName} {FirstName}";

    public void Clear() => InitProperties();

    private void InitProperties()
    {
      FirstName = string.Empty;
      LastName = string.Empty;
      Email = string.Empty;
      Phone = string.Empty;
      BirthDate = DateTime.MinValue;
    }
  }
}

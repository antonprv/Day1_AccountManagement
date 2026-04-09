// Created by Anton Piruev in 2026. 
// Any direct commercial use of derivative work is strictly prohibited.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace AccountManager.Forms
{
  public partial class MainForm : Form
  {
    private readonly List<Models.User> _users =
      new List<Models.User>();

    private readonly Services.UserXMLService _service;
    private Models.User _selectedUser;
    private bool _searchBoxBusy;
    private ContextMenuStrip _contextMenu;
    private readonly string _defaultSearchBoxText;

    public MainForm()
    {
      InitializeComponent();

      _service = new Services.UserXMLService("users.xml");
      _users = _service.Load();

      _defaultSearchBoxText = searchBox.Text;

      RefreshGrid();
      SetGridContextMenus();
    }

    #region Grid Context Menus

    private void SetGridContextMenus()
    {
      _contextMenu = new ContextMenuStrip();

      _contextMenu.Items.Add("Копировать ячейку", null, CopyCell_Click);
      _contextMenu.Items.Add("Копировать строку", null, CopyRow_Click);
      _contextMenu.Items.Add("Копировать столбец", null, CopyColumn_Click);

      dataGridView.ContextMenuStrip = _contextMenu;
    }

    private void CopyCell_Click(object sender, EventArgs e)
    {
      if (dataGridView.CurrentCell == null) return;

      var value = FormatValue(dataGridView.CurrentCell.Value);
      AddToClipboard(value);
    }

    private void CopyRow_Click(object sender, EventArgs e)
    {
      if (dataGridView.CurrentRow == null) return;

      var values = dataGridView.CurrentRow.Cells
        .Cast<DataGridViewCell>()
        .Select(c => FormatValue(c.Value));

      var result = string.Join("\t", values);

      AddToClipboard(result);
    }

    private void CopyColumn_Click(object sender, EventArgs e)
    {
      if (dataGridView.CurrentCell == null) return;

      int columnIndex = dataGridView.CurrentCell.ColumnIndex;

      var values = dataGridView.Rows
        .Cast<DataGridViewRow>()
        .Where(r => !r.IsNewRow)
        .Select(r =>
          FormatValue(r.Cells[columnIndex].Value)
          );

      var result = string.Join(Environment.NewLine, values);

      AddToClipboard(result);
    }

    private static void AddToClipboard(string value)
    {
      if (!string.IsNullOrWhiteSpace(value))
        Clipboard.SetText(value);
    }

    #endregion


    #region Grid Selections

    private void DataGridView_SelectionChanged(object sender, EventArgs e) =>
      _selectedUser = GetSelectedUser();

    #endregion

    #region Top Bar Callbacks

    private void SearchBox_Click(object sender, EventArgs e) =>
      SetSearchBoxText(string.Empty);

    private void SearchBox_Leave(object sender, EventArgs e) =>
      SetSearchBoxText(_defaultSearchBoxText);

    private void SearchBox_TextChanged(object sender, EventArgs e)
    {
      if (_searchBoxBusy) return;

      var query = searchBox.Text.ToLower();
      var filtered = string.IsNullOrEmpty(query)
          ? _users
          : _users.Where(u =>
              u.FirstName.ToLower().Contains(query) ||
              u.LastName.ToLower().Contains(query)  ||
              u.Email.ToLower().Contains(query)     ||
              u.Phone.Contains(query)).ToList();

      dataGridView.DataSource = new BindingList<Models.User>(filtered);
      statusLabel.Text = $"Найдено: {filtered.Count} из {_users.Count}";
    }

    private void DeleteButton_Click(object sender, EventArgs e)
    {
      if (_selectedUser == null) return;

      using (var form = new DeleteDialog())
      {
        if (form.ShowDialog() == DialogResult.OK)
        {
          _users.Remove(_selectedUser);

          _service.Save(_users);
          RefreshGrid();
        }
      }
    }

    private void EditButton_Click(object sender, EventArgs e)
    {
      if (_selectedUser == null) return;

      using (var form = new UserEditForm(_selectedUser))
      {
        if (form.ShowDialog() == DialogResult.OK)
        {
          _users[_users.IndexOf(_selectedUser)] = form.Result;
          _service.Save(_users);
          RefreshGrid();
        }
      }
    }

    private void AddButton_Click(object sender, EventArgs e)
    {
      using (var form = new UserEditForm())
      {
        if (form.ShowDialog() == DialogResult.OK)
        {
          _users.Add(form.Result);
          _service.Save(_users);
          RefreshGrid();
        }
      }
    }

    #endregion

    #region Helper Functions

    private void SetSearchBoxText(string text)
    {
      _searchBoxBusy = true;
      searchBox.Text = text;
      _searchBoxBusy = false;
    }

    private Models.User GetSelectedUser()
    {
      if (dataGridView.CurrentRow == null) return null;
      return dataGridView.CurrentRow.DataBoundItem as Models.User;
    }

    private void RefreshGrid()
    {
      dataGridView.SelectionChanged -= DataGridView_SelectionChanged;

      dataGridView.DataSource = new BindingList<Models.User>(_users);
      FormatGrid();

      dataGridView.SelectionChanged += DataGridView_SelectionChanged;

      statusLabel.Text = $"Пользователей: {_users.Count}";
    }

    private void FormatGrid()
    {
      dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

      dataGridView
        .Columns[$"{nameof(Models.User.FirstName)}"].FillWeight = 20;
      dataGridView
        .Columns[$"{nameof(Models.User.LastName)}"].FillWeight = 20;
      dataGridView
        .Columns[$"{nameof(Models.User.Email)}"].FillWeight = 40;
      dataGridView
        .Columns[$"{nameof(Models.User.Phone)}"].FillWeight = 20;
      dataGridView.RowHeadersWidth = 25;

      dataGridView
        .Columns[$"{nameof(Models.User.BirthDate)}"]
        .DefaultCellStyle.Format = "dd.MM.yyyy";
    }

    private static string FormatValue(object value)
    {
      if (value == null) return string.Empty;

      if (value is DateTime dt)
        return dt.ToString("dd.MM.yyyy");

      return value.ToString();
    }

    #endregion

    #region Grid Selections

    private void DataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
      dataGridView.ClearSelection();

      foreach (DataGridViewRow row in dataGridView.Rows)
        if (!row.IsNewRow)
          row.Cells[e.ColumnIndex].Selected = true;
    }

    private void DataGridView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
      dataGridView.ClearSelection();

      foreach (DataGridViewCell cell in dataGridView.Rows[e.RowIndex].Cells)
        cell.Selected = true;
    }

    #endregion
  }
}

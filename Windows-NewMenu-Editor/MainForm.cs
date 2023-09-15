using System.ComponentModel;
using System.Diagnostics;
using Windows_NewMenu_Editor.Properties;

namespace Windows_NewMenu_Editor;

public partial class MainForm : Form
{
    public BindingList<NewMenuType> AvailableTypes { get; set; } = new BindingList<NewMenuType>();
    public List<string> AvailableTypesOrg { get; set; } = new List<string>();

    public BindingList<NewMenuType> NewMenuTypes { get; set; } = new BindingList<NewMenuType>();
    public List<string> NewMenuTypesOrg { get; set; } = new List<string>();

    public List<string> ToAddNewMenuTypes { get; set; } = new List<string>();

    public List<string> ToRemoveNewMenuTypes { get; set; } = new List<string>();


    public MainForm()
    {
        InitializeComponent();

        AvailableTypesListBox.DataSource = AvailableTypes;
        AvailableTypesListBox.DisplayMember = "TypeName";

        NewMenuListBox.DataSource = NewMenuTypes;
        NewMenuListBox.DisplayMember = "TypeName";

        _ = FillAvailableTypes();
        _ = FillNewMenuTypes();

        RestoreBackupButton.Enabled = !string.IsNullOrEmpty(Settings.Default.NewMenuItemsBackup);
    }

    private async Task FillAvailableTypes()
    {
        NewMenuType[] types = RegistryHelper.GetAvailableFileTypes();
        await SetAvailableTypes(types);
        AvailableTypesOrg = AvailableTypes.Select(x => x.TypeName).Where(x => !string.IsNullOrEmpty(x)).ToList();
    }

    private async Task SetAvailableTypes(NewMenuType[] types)
    {
        AvailableTypes.RaiseListChangedEvents = false;
        AvailableTypes.Clear();
        foreach (NewMenuType type in types)
            AvailableTypes.Add(type);
        AvailableTypes.RaiseListChangedEvents = true;
        AvailableTypes.ResetBindings();
        AvailableTypesListBox.ClearSelected();
    }

    private async Task FillNewMenuTypes()
    {
        NewMenuType[] types = RegistryHelper.GetNewMenuFileTypes();
        await SetNewMenuTypes(types);
        NewMenuTypesOrg = NewMenuTypes.Select(x => x.TypeName).Where(x => !string.IsNullOrEmpty(x)).ToList();
    }

    private async Task SetNewMenuTypes(NewMenuType[] types)
    {
        AvailableTypes.RaiseListChangedEvents = false;
        NewMenuTypes.RaiseListChangedEvents = false;
        NewMenuTypes.Clear();
        foreach (NewMenuType type in types)
        {
            NewMenuTypes.Add(type);
            NewMenuType? inNewMenuType = AvailableTypes.SingleOrDefault(x => x.TypeName == type.TypeName);
            if (inNewMenuType is not null)
                AvailableTypes.Remove(inNewMenuType);
        }
        NewMenuTypes.RaiseListChangedEvents = true;
        AvailableTypes.RaiseListChangedEvents = true;
        NewMenuTypes.ResetBindings();
        AvailableTypes.ResetBindings();
        AvailableTypesListBox.ClearSelected();
        NewMenuListBox.ClearSelected();
    }

    private async Task UpdateAvailableTypesListBox()
    {
        BindingList<NewMenuType> filteredList = new BindingList<NewMenuType>(AvailableTypes.Where(x => !x.Hidden).ToList());
        AvailableTypesListBox.DataSource = filteredList;
        AvailableTypesListBox.ClearSelected();
    }

    private async Task UpdateNewMenuTypesListBox()
    {
        BindingList<NewMenuType> filteredList = new BindingList<NewMenuType>(NewMenuTypes.Where(x => !x.Hidden).ToList());
        NewMenuListBox.DataSource = filteredList;
        NewMenuListBox.ClearSelected();
    }

    private async Task ApplyNewMenuItems(string[] toAdd, string[] toRemove)
    {
        bool success = false;
        if (RegistryHelper.IsRunningAsAdmin())
            success = await ApplyNewMenuItemsAdmin(toAdd, toRemove);
        else
            success = await ApplyNewMenuItemsRequestAdmin(toAdd, toRemove);

        if (!success)
        {
            MessageBox.Show("An Error occurred while applying the changes", "Apply Change Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        NewMenuTypesOrg.AddRange(toAdd);
        NewMenuTypesOrg.RemoveAll(x => toRemove.Contains(x));
        ApplyButton.Enabled = IsChangeNewMenuTypes();
    }

    private async Task<bool> ApplyNewMenuItemsAdmin(string[] add, string[] remove)
    {
        bool successAll = true;
        if (add.Length != 0)
            foreach (string type in add)
            {
                bool success = RegistryHelper.AddTypeToNewMenu(type);
                if (successAll)
                    successAll = success;
            }

        if (remove.Length != 0)
            foreach (string type in remove)
            {
                bool success = RegistryHelper.RemoveTypeFromNewMenu(type);
                if (successAll)
                    successAll = success;
            }
        return successAll;
    }

    private async Task<bool> ApplyNewMenuItemsRequestAdmin(string[] add, string[] remove)
    {
        string? commandLineArgs = null;

        if (add.Length != 0)
        {
            string serializedAdd = string.Join(",", add);
            commandLineArgs += $"-a \"{serializedAdd}\" ";
        }
        if (remove.Length != 0)
        {
            string serializedRemove = string.Join(",", remove);
            commandLineArgs += $"-r \"{serializedRemove}\"";
            commandLineArgs = commandLineArgs.Trim();
        }

        ProcessStartInfo startInfo = new ProcessStartInfo
        {
            FileName = Application.ExecutablePath,
            Arguments = commandLineArgs,
            CreateNoWindow = true,
            UseShellExecute = true,
            Verb = "runas",
        };
        try
        {
            Process.Start(startInfo);
            return true;
        }
        catch (Win32Exception)
        {
            return false;
        }
    }

    private string[] GetToAddNewMenuItems()
    {
        List<string> currTypes = NewMenuTypes.Select(x => x.TypeName).Where(x => !string.IsNullOrEmpty(x)).ToList();
        return currTypes.Except(NewMenuTypesOrg).ToArray();
    }

    private string[] GetToRemoveNewMenuItems()
    {
        List<string> currTypes = NewMenuTypes.Select(x => x.TypeName).Where(x => !string.IsNullOrEmpty(x)).ToList();
        return NewMenuTypesOrg.Except(currTypes).ToArray();
    }

    private bool IsChangeNewMenuTypes()
    {
        List<string> currTypes = NewMenuTypes.Select(x => x.TypeName).Where(x => !string.IsNullOrEmpty(x)).Order().ToList();
        NewMenuTypesOrg = NewMenuTypesOrg.Order().ToList();
        return !currTypes.SequenceEqual(NewMenuTypesOrg);
    }

    private async Task RestoreBackup()
    {
        string[] newMenuTypesBackup = Settings.Default.NewMenuItemsBackup.Split(',');
        List<NewMenuType> types = new List<NewMenuType>();
        foreach (string type in newMenuTypesBackup)
            types.Add(new NewMenuType { TypeName = type });

        await SetNewMenuTypes(types.ToArray());
        await UpdateNewMenuTypesListBox();
        ApplyButton.Enabled = IsChangeNewMenuTypes();
    }

    private void AvailableTypesSearchTextBox_TextChanged(object sender, EventArgs e)
    {
        string searchText = AvailableTypesSearchTextBox.Text.ToLower();
        foreach (NewMenuType type in AvailableTypes)
        {
            bool showItem = string.IsNullOrEmpty(searchText) || type.TypeName?.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) != -1;
            type.Hidden = !showItem;
        }

        _ = UpdateAvailableTypesListBox();
    }

    private void NewMenuSearchTextBox_TextChanged(object sender, EventArgs e)
    {
        string searchText = NewMenuSearchTextBox.Text.ToLower();
        foreach (NewMenuType type in NewMenuTypes)
        {
            bool showItem = string.IsNullOrEmpty(searchText) || type.TypeName?.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) != -1;
            type.Hidden = !showItem;
        }

        _ = UpdateNewMenuTypesListBox();
    }

    private void AddMenuItemButton_Click(object sender, EventArgs e)
    {
        if (AvailableTypesListBox.SelectedIndices.Count == 0)
            return;
        AvailableTypes.RaiseListChangedEvents = false;
        foreach (NewMenuType type in AvailableTypesListBox.SelectedItems)
        {
            AvailableTypes.Remove(type);
            NewMenuTypes.Add(type);
        }
        AvailableTypes.RaiseListChangedEvents = true;
        _ = UpdateAvailableTypesListBox();
        _ = UpdateNewMenuTypesListBox();
        ApplyButton.Enabled = IsChangeNewMenuTypes();
    }

    private void RemoveMenuItemButton_Click(object sender, EventArgs e)
    {
        if (NewMenuListBox.SelectedIndices.Count == 0)
            return;
        NewMenuTypes.RaiseListChangedEvents = false;
        foreach (NewMenuType type in NewMenuListBox.SelectedItems)
        {
            NewMenuTypes.Remove(type);
            AvailableTypes.Add(type);
        }
        NewMenuTypes.RaiseListChangedEvents = true;
        _ = UpdateNewMenuTypesListBox();
        _ = UpdateAvailableTypesListBox();
        ApplyButton.Enabled = IsChangeNewMenuTypes();
    }

    private void AvailableTypesListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        AddMenuItemButton.Enabled = AvailableTypesListBox.SelectedIndices.Count != 0;
    }

    private void NewMenuListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        RemoveMenuItemButton.Enabled = NewMenuListBox.SelectedIndices.Count != 0;
    }

    private void ApplyButton_Click(object sender, EventArgs e)
    {
        string[] toAdd = GetToAddNewMenuItems();
        string[] toRemove = GetToRemoveNewMenuItems();
        _ = ApplyNewMenuItems(toAdd, toRemove);
    }

    private void CreateBackupButton_Click(object sender, EventArgs e)
    {
        string newMenuTypesBackup = string.Join(",", NewMenuTypesOrg);
        Settings.Default.NewMenuItemsBackup = newMenuTypesBackup;
        Settings.Default.Save();

        MessageBox.Show("Backup successfully created.", "Backup Created", MessageBoxButtons.OK, MessageBoxIcon.Information);

        RestoreBackupButton.Enabled = true;
    }

    private void RestoreBackupButton_Click(object sender, EventArgs e)
    {
        _ = RestoreBackup();
    }
}

using Microsoft.Win32;
using System.Security.Principal;

namespace Windows_NewMenu_Editor;
public static class RegistryHelper
{
    public static object? GetRegKeyValue(string path, string key)
    {
        RegistryKey? regKey = Registry.ClassesRoot.OpenSubKey(path);
        if (regKey is not null)
            return regKey.GetValue(key);

        return null;
    }

    public static bool DoesRegKeyExist(string path, string key)
    {
        RegistryKey? regKey = Registry.ClassesRoot.OpenSubKey(path);
        if (regKey is not null)
        {
            RegistryKey? keyToCheck = regKey.OpenSubKey(key);
            return keyToCheck is not null;
        }
        return false;
    }

    public static void SetRegKeyValue(string path, string key, string? value = null)
    {
        RegistryKey regKey = Registry.ClassesRoot.CreateSubKey(path);
        if (string.IsNullOrEmpty(value))
            regKey.CreateSubKey(key);
        else
            regKey.SetValue(key, value);
    }

    public static NewMenuType[] GetAvailableFileTypes()
    {
        List<NewMenuType> types = new List<NewMenuType>();
        string[] subKeys = Registry.ClassesRoot.GetSubKeyNames();

        foreach (string subKey in subKeys)
        {
            if (subKey.StartsWith("."))
                types.Add(new NewMenuType { TypeName = subKey });
        }

        return types.ToArray();
    }

    public static NewMenuType[] GetNewMenuFileTypes()
    {
        List<NewMenuType> types = new List<NewMenuType>();
        string[] subKeys = Registry.ClassesRoot.GetSubKeyNames();

        foreach (string subKey in subKeys)
        {
            if (subKey.StartsWith("."))
            {
                RegistryKey? shellNewKey = Registry.ClassesRoot.OpenSubKey(subKey);
                if (shellNewKey is null)
                    continue;
                if (shellNewKey.OpenSubKey("ShellNew") is not null)
                    types.Add(new NewMenuType { TypeName = subKey });
            }
        }

        return types.ToArray();
    }

    public static bool AddTypeToNewMenu(string type)
    {
        RegistryKey? regKey = Registry.ClassesRoot.OpenSubKey(type, true);
        if (regKey is null)
            return false;
        RegistryKey shellNewKey = regKey.CreateSubKey("ShellNew");
        shellNewKey.SetValue("NullFile", "", RegistryValueKind.String);
        return true;
    }

    public static bool RemoveTypeFromNewMenu(string type)
    {
        RegistryKey? regKey = Registry.ClassesRoot.OpenSubKey(type, true);
        if (regKey is null)
            return false;
        regKey.DeleteSubKeyTree("ShellNew");
        return true;
    }

    public static bool IsRunningAsAdmin()
    {
        WindowsIdentity identity = WindowsIdentity.GetCurrent();
        WindowsPrincipal principal = new WindowsPrincipal(identity);
        return principal.IsInRole(WindowsBuiltInRole.Administrator);
    }
}

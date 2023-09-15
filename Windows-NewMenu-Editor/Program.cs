namespace Windows_NewMenu_Editor;

internal static class Program
{
    [STAThread]
    static void Main(string[] args)
    {
        ApplicationConfiguration.Initialize();

        if (args.Length == 0)
            Application.Run(new MainForm());
        else
        {
            string[]? add = null;
            string[]? remove = null;

            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == "-a" && i + 1 < args.Length)
                    add = args[i + 1].Split(',');
                else if (args[i] == "-r" && i + 1 < args.Length)
                    remove = args[i + 1].Split(',');
            }

            if (add is not null && add.Length != 0)
            {
                foreach (string type in add)
                    RegistryHelper.AddTypeToNewMenu(type);
            }

            if (remove is not null && remove.Length != 0)
            {
                foreach (string type in remove)
                    RegistryHelper.RemoveTypeFromNewMenu(type);
            }
        }
    }
}
namespace Windows_NewMenu_Editor;

public class NewMenuType
{
    public string? TypeName { get; set; }
    public bool Hidden { get; set; }

    public override string ToString() => $"{TypeName} | Hidden '{Hidden}'";
}

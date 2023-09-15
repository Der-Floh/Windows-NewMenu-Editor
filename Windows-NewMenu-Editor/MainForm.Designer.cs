namespace Windows_NewMenu_Editor;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        AvailableTypesListBox = new ListBox();
        AvailableTypesLabel = new Label();
        AvailableTypesSearchTextBox = new TextBox();
        AvailableTypesPanel = new Panel();
        AvailalbeTypesSearchLabel = new Label();
        NewMenuPanel = new Panel();
        NewMenuSearchLabel = new Label();
        NewMenuListBox = new ListBox();
        NewMenuLabel = new Label();
        NewMenuSearchTextBox = new TextBox();
        tableLayoutPanel1 = new TableLayoutPanel();
        ActionsPanel = new Panel();
        RestoreBackupButton = new Button();
        CreateBackupButton = new Button();
        ApplyButton = new Button();
        AddMenuItemButton = new Button();
        RemoveMenuItemButton = new Button();
        AvailableTypesPanel.SuspendLayout();
        NewMenuPanel.SuspendLayout();
        tableLayoutPanel1.SuspendLayout();
        ActionsPanel.SuspendLayout();
        SuspendLayout();
        // 
        // AvailableTypesListBox
        // 
        AvailableTypesListBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        AvailableTypesListBox.FormattingEnabled = true;
        AvailableTypesListBox.ItemHeight = 15;
        AvailableTypesListBox.Location = new Point(3, 91);
        AvailableTypesListBox.Name = "AvailableTypesListBox";
        AvailableTypesListBox.SelectionMode = SelectionMode.MultiExtended;
        AvailableTypesListBox.Size = new Size(294, 319);
        AvailableTypesListBox.Sorted = true;
        AvailableTypesListBox.TabIndex = 0;
        AvailableTypesListBox.SelectedIndexChanged += AvailableTypesListBox_SelectedIndexChanged;
        // 
        // AvailableTypesLabel
        // 
        AvailableTypesLabel.AutoSize = true;
        AvailableTypesLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        AvailableTypesLabel.Location = new Point(3, 5);
        AvailableTypesLabel.Name = "AvailableTypesLabel";
        AvailableTypesLabel.Size = new Size(113, 15);
        AvailableTypesLabel.TabIndex = 2;
        AvailableTypesLabel.Text = "Available File Types";
        // 
        // AvailableTypesSearchTextBox
        // 
        AvailableTypesSearchTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        AvailableTypesSearchTextBox.Location = new Point(3, 62);
        AvailableTypesSearchTextBox.Name = "AvailableTypesSearchTextBox";
        AvailableTypesSearchTextBox.Size = new Size(294, 23);
        AvailableTypesSearchTextBox.TabIndex = 3;
        AvailableTypesSearchTextBox.TextChanged += AvailableTypesSearchTextBox_TextChanged;
        // 
        // AvailableTypesPanel
        // 
        AvailableTypesPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        AvailableTypesPanel.BorderStyle = BorderStyle.FixedSingle;
        AvailableTypesPanel.Controls.Add(AvailalbeTypesSearchLabel);
        AvailableTypesPanel.Controls.Add(AvailableTypesListBox);
        AvailableTypesPanel.Controls.Add(AvailableTypesLabel);
        AvailableTypesPanel.Controls.Add(AvailableTypesSearchTextBox);
        AvailableTypesPanel.Location = new Point(3, 3);
        AvailableTypesPanel.Name = "AvailableTypesPanel";
        AvailableTypesPanel.Size = new Size(302, 420);
        AvailableTypesPanel.TabIndex = 4;
        // 
        // AvailalbeTypesSearchLabel
        // 
        AvailalbeTypesSearchLabel.AutoSize = true;
        AvailalbeTypesSearchLabel.Location = new Point(3, 44);
        AvailalbeTypesSearchLabel.Name = "AvailalbeTypesSearchLabel";
        AvailalbeTypesSearchLabel.Size = new Size(42, 15);
        AvailalbeTypesSearchLabel.TabIndex = 4;
        AvailalbeTypesSearchLabel.Text = "Search";
        // 
        // NewMenuPanel
        // 
        NewMenuPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        NewMenuPanel.BorderStyle = BorderStyle.FixedSingle;
        NewMenuPanel.Controls.Add(NewMenuSearchLabel);
        NewMenuPanel.Controls.Add(NewMenuListBox);
        NewMenuPanel.Controls.Add(NewMenuLabel);
        NewMenuPanel.Controls.Add(NewMenuSearchTextBox);
        NewMenuPanel.Location = new Point(471, 3);
        NewMenuPanel.Name = "NewMenuPanel";
        NewMenuPanel.Size = new Size(302, 420);
        NewMenuPanel.TabIndex = 5;
        // 
        // NewMenuSearchLabel
        // 
        NewMenuSearchLabel.AutoSize = true;
        NewMenuSearchLabel.Location = new Point(3, 44);
        NewMenuSearchLabel.Name = "NewMenuSearchLabel";
        NewMenuSearchLabel.Size = new Size(42, 15);
        NewMenuSearchLabel.TabIndex = 4;
        NewMenuSearchLabel.Text = "Search";
        // 
        // NewMenuListBox
        // 
        NewMenuListBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        NewMenuListBox.FormattingEnabled = true;
        NewMenuListBox.ItemHeight = 15;
        NewMenuListBox.Location = new Point(3, 91);
        NewMenuListBox.Name = "NewMenuListBox";
        NewMenuListBox.SelectionMode = SelectionMode.MultiExtended;
        NewMenuListBox.Size = new Size(294, 319);
        NewMenuListBox.Sorted = true;
        NewMenuListBox.TabIndex = 0;
        NewMenuListBox.SelectedIndexChanged += NewMenuListBox_SelectedIndexChanged;
        // 
        // NewMenuLabel
        // 
        NewMenuLabel.AutoSize = true;
        NewMenuLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        NewMenuLabel.Location = new Point(3, 5);
        NewMenuLabel.Name = "NewMenuLabel";
        NewMenuLabel.Size = new Size(102, 15);
        NewMenuLabel.TabIndex = 2;
        NewMenuLabel.Text = "New Menu Types";
        // 
        // NewMenuSearchTextBox
        // 
        NewMenuSearchTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        NewMenuSearchTextBox.Location = new Point(3, 62);
        NewMenuSearchTextBox.Name = "NewMenuSearchTextBox";
        NewMenuSearchTextBox.Size = new Size(294, 23);
        NewMenuSearchTextBox.TabIndex = 3;
        NewMenuSearchTextBox.TextChanged += NewMenuSearchTextBox_TextChanged;
        // 
        // tableLayoutPanel1
        // 
        tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        tableLayoutPanel1.ColumnCount = 3;
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160F));
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tableLayoutPanel1.Controls.Add(AvailableTypesPanel, 0, 0);
        tableLayoutPanel1.Controls.Add(NewMenuPanel, 2, 0);
        tableLayoutPanel1.Controls.Add(ActionsPanel, 1, 0);
        tableLayoutPanel1.Location = new Point(12, 12);
        tableLayoutPanel1.Name = "tableLayoutPanel1";
        tableLayoutPanel1.RowCount = 1;
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tableLayoutPanel1.Size = new Size(776, 426);
        tableLayoutPanel1.TabIndex = 6;
        // 
        // ActionsPanel
        // 
        ActionsPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        ActionsPanel.Controls.Add(RestoreBackupButton);
        ActionsPanel.Controls.Add(CreateBackupButton);
        ActionsPanel.Controls.Add(ApplyButton);
        ActionsPanel.Controls.Add(AddMenuItemButton);
        ActionsPanel.Controls.Add(RemoveMenuItemButton);
        ActionsPanel.Location = new Point(311, 3);
        ActionsPanel.Name = "ActionsPanel";
        ActionsPanel.Size = new Size(154, 420);
        ActionsPanel.TabIndex = 6;
        // 
        // RestoreBackupButton
        // 
        RestoreBackupButton.Cursor = Cursors.Hand;
        RestoreBackupButton.Enabled = false;
        RestoreBackupButton.Location = new Point(10, 56);
        RestoreBackupButton.Name = "RestoreBackupButton";
        RestoreBackupButton.Size = new Size(134, 44);
        RestoreBackupButton.TabIndex = 5;
        RestoreBackupButton.Text = "Restore Backup";
        RestoreBackupButton.UseVisualStyleBackColor = true;
        RestoreBackupButton.Click += RestoreBackupButton_Click;
        // 
        // CreateBackupButton
        // 
        CreateBackupButton.Cursor = Cursors.Hand;
        CreateBackupButton.Location = new Point(10, 6);
        CreateBackupButton.Name = "CreateBackupButton";
        CreateBackupButton.Size = new Size(134, 44);
        CreateBackupButton.TabIndex = 4;
        CreateBackupButton.Text = "Create Backup";
        CreateBackupButton.UseVisualStyleBackColor = true;
        CreateBackupButton.Click += CreateBackupButton_Click;
        // 
        // ApplyButton
        // 
        ApplyButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        ApplyButton.Cursor = Cursors.Hand;
        ApplyButton.Enabled = false;
        ApplyButton.Location = new Point(10, 367);
        ApplyButton.Name = "ApplyButton";
        ApplyButton.Size = new Size(134, 44);
        ApplyButton.TabIndex = 3;
        ApplyButton.Text = "Apply Changes";
        ApplyButton.UseVisualStyleBackColor = true;
        ApplyButton.Click += ApplyButton_Click;
        // 
        // AddMenuItemButton
        // 
        AddMenuItemButton.Anchor = AnchorStyles.Left;
        AddMenuItemButton.Cursor = Cursors.Hand;
        AddMenuItemButton.Location = new Point(29, 197);
        AddMenuItemButton.Name = "AddMenuItemButton";
        AddMenuItemButton.Size = new Size(99, 34);
        AddMenuItemButton.TabIndex = 2;
        AddMenuItemButton.Text = "-->";
        AddMenuItemButton.UseVisualStyleBackColor = true;
        AddMenuItemButton.Click += AddMenuItemButton_Click;
        // 
        // RemoveMenuItemButton
        // 
        RemoveMenuItemButton.Anchor = AnchorStyles.Left;
        RemoveMenuItemButton.Cursor = Cursors.Hand;
        RemoveMenuItemButton.Location = new Point(29, 237);
        RemoveMenuItemButton.Name = "RemoveMenuItemButton";
        RemoveMenuItemButton.Size = new Size(99, 34);
        RemoveMenuItemButton.TabIndex = 1;
        RemoveMenuItemButton.Text = "<--";
        RemoveMenuItemButton.UseVisualStyleBackColor = true;
        RemoveMenuItemButton.Click += RemoveMenuItemButton_Click;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(tableLayoutPanel1);
        MinimumSize = new Size(520, 350);
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Windows NewMenu Editor";
        AvailableTypesPanel.ResumeLayout(false);
        AvailableTypesPanel.PerformLayout();
        NewMenuPanel.ResumeLayout(false);
        NewMenuPanel.PerformLayout();
        tableLayoutPanel1.ResumeLayout(false);
        ActionsPanel.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private ListBox AvailableTypesListBox;
    private Label AvailableTypesLabel;
    private TextBox AvailableTypesSearchTextBox;
    private Panel AvailableTypesPanel;
    private Label AvailalbeTypesSearchLabel;
    private Panel NewMenuPanel;
    private Label NewMenuSearchLabel;
    private ListBox NewMenuListBox;
    private Label NewMenuLabel;
    private TextBox NewMenuSearchTextBox;
    private TableLayoutPanel tableLayoutPanel1;
    private Panel ActionsPanel;
    private Button ApplyButton;
    private Button AddMenuItemButton;
    private Button RemoveMenuItemButton;
    private Button RestoreBackupButton;
    private Button CreateBackupButton;
}

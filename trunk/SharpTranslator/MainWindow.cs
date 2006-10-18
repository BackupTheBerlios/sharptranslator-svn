using System;
using Mono.Data.SqliteClient;
using System.Data;
using Gtk;
using System.Collections;

namespace SharpTranslator
{
public class MainWindow: Gtk.Window
{	
	private IDbConnection dbcon;
	private string connectionString = "URI=file:translator.db, version=3";
	private IDbCommand dbcmd;
	protected Gtk.Entry entryKeyword;
	protected Gtk.TreeView treeviewResults;
	private GuiTreeview gtv;
	private Hashtable languages = new Hashtable();
	protected Gtk.Entry entryExpression;
	protected SharpTranslator.ReversibleCombos rCombos;
	
	public MainWindow (): base ("")
	{
		Stetic.Gui.Build (this, typeof(MainWindow));
		this.Title = "SharpTranslator";
		rCombos.CheckButtonReverse.Toggled += new EventHandler(this.OnReverseToggled);
		try {
			TranslatorLib.Connect();
			LoadLanguages();
			InitTreeview();
			entryKeyword.HasFocus = true;
			this.DefaultWidth = rCombos.WidthRequest; 
		}
		catch(Exception e)
		{
			System.Console.WriteLine("Exception:" + e.Message);
		}
	 
	}
	
	
	public void LoadLanguages()
	{ 
		ArrayList langs = (ArrayList)TranslatorLib.LoadActiveLanguages();
		int id;
		for (int i = 0; i < langs.Count; i = i+2)
		{
       		rCombos.ComboSource.AppendText((string)langs[i]);
       		id = Int32.Parse((string)langs[i+1]);
       		languages[langs[i]] = id;
            rCombos.ComboTarget.AppendText((string)langs[i]);
		}
		if (langs.Count >= 2)
		{
			rCombos.ComboSource.Active = 0;
			rCombos.ComboTarget.Active = 1;
		}
    }
	
	public void InitTreeview()
	{
         ArrayList columns = new ArrayList();
         Column keyw = new Column();
         keyw.name = "Original";
         keyw.type = "string";
         keyw.view = true;
         columns.Add(keyw);
         Column trans = new Column();
         trans.name = "Translation";
         trans.type = "string";
         trans.view = true;
         columns.Add(trans);
         gtv = new GuiTreeview();
         gtv.NewTreeView(columns, ref treeviewResults);
	}
	
	
	protected void OnClose (object sender, System.EventArgs a)
	{
		TranslatorLib.Disconnect();
		Application.Quit ();
		//a.RetVal = true;
	}

	protected virtual void OnSearch(object sender, System.EventArgs e)
	{
		string key = entryKeyword.Text;
		((TreeStore)treeviewResults.Model).Clear();
		if (key.Length > 0)
		{
			ArrayList res = (ArrayList)TranslatorLib.SearchKey(key, rCombos.ComboSource.ActiveText, rCombos.ComboTarget.ActiveText);
			for (int i = 0; i < res.Count; i=i+2)
			{
				string[] row = new string[2];
				row[0] = (string)res[i];
				row[1] = (string)res[i+1];
				gtv.InsertRow(TreeIter.Zero, row); 
			}
			if (res.Count == 0)
			{
				string[] row = new string[2];
				row[0] = "Not found:";
				row[1] = "Word or expression not found, please use learn function to add new words";
				gtv.InsertRow(TreeIter.Zero, row);
				row[0] = "";
				row[1] = "If you use to learn words and expressions, send your translator.db to SharpTranslator's developers please";
				gtv.InsertRow(TreeIter.Zero, row);
			
			}
		}
		
	}

	protected virtual void OnDeleteEvent(object o, Gtk.DeleteEventArgs args)
	{
		TranslatorLib.Disconnect();
		Application.Quit();
		args.RetVal = true;
	}

	protected virtual void OnLearn(object sender, System.EventArgs e)
	{
		LearnWindow lw = new LearnWindow((int)languages[rCombos.ComboSource.ActiveText], (int)languages[rCombos.ComboTarget.ActiveText]);
		lw.Present();
	}

	protected virtual void OnSearchExpression(object sender, System.EventArgs e)
	{
		string key = entryExpression.Text;
		((TreeStore)treeviewResults.Model).Clear();
		if (key.Length > 0)
		{
			ArrayList res = (ArrayList)TranslatorLib.SearchExpression(key, rCombos.ComboSource.ActiveText, rCombos.ComboTarget.ActiveText);
			for (int i = 0; i < res.Count; i=i+2)
			{
				string[] row = new string[2];
				row[0] = (string)res[i];
				row[1] = (string)res[i+1];
				gtv.InsertRow(TreeIter.Zero, row); 
			}
			if (res.Count == 0)
			{
				string[] row = new string[2];
				row[0] = "Not found:";
				row[1] = "Word or expression not found, please use learn function to add new words";
				gtv.InsertRow(TreeIter.Zero, row);
			}
		}

	}

	protected virtual void OnAbout(object sender, System.EventArgs e)
	{
		AboutDialog ad = new AboutDialog();
		ad.Present();
	}

	protected virtual void OnReverseToggled(object sender, System.EventArgs e)
	{
		entryKeyword.HasFocus = true;
		this.OnSearch(sender, e);
	}
	
	
}
}
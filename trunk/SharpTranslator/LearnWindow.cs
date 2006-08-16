
using System;
using System.Collections;
using Gtk;

namespace SharpTranslator
{
	
	public class LearnWindow : Gtk.Window
	{
		protected Gtk.ComboBox comboSource;
		protected Gtk.ComboBox comboTarget;
		protected Gtk.Entry entryText;
		protected Gtk.Entry entryTranslation;
		protected Gtk.CheckButton checkbExpression;
		protected Gtk.CheckButton checkbWord;
		private Hashtable languages = new Hashtable();
		private bool word = true;
		private int actlangSource, actlangTarget;
		
		public LearnWindow(int active1, int active2) : 
				base("")
		{
			Stetic.Gui.Build(this, typeof(SharpTranslator.LearnWindow));
			checkbWord.Toggled += new EventHandler(this.OnWordToggled);
			checkbExpression.Toggled += new EventHandler(this.OnExpressionToggled);
			this.Title = "Learn a new item";
			actlangSource = active1;
			actlangTarget = active2;
			LoadLanguages();
		}

		public void LoadLanguages()
		{	 
			ArrayList langs = (ArrayList)TranslatorLib.LoadAllLanguages();
			int id;
			for (int i = 0; i < langs.Count; i = i+2)
			{
   	    		comboSource.AppendText((string)langs[i]);
   	    		id = Int32.Parse((string)langs[i+1]);
   	    		languages[langs[i]] = id;
				comboTarget.AppendText((string)langs[i]);
			}
			if (langs.Count >= 2)
			{
				comboSource.Active = actlangSource -1;
				comboTarget.Active = actlangTarget -1;
			}
		}
		
		protected virtual void OnAccept(object sender, System.EventArgs e)
		{
			string sourcelang = comboSource.ActiveText;
			string targetlang = comboTarget.ActiveText;
			string text = entryText.Text;
			string translation = entryTranslation.Text;
			if (checkbWord.Active)
				TranslatorLib.LearnWord((int)languages[sourcelang],
										(int)languages[targetlang],
										text, translation);
			else 
				TranslatorLib.LearnExpression((int)languages[sourcelang],
										(int)languages[targetlang],
										text, translation);
			this.Hide();
		}

		protected virtual void OnCancel(object sender, System.EventArgs e)
		{
			this.Hide();
			this.Destroy();
		}

		protected virtual void OnWordToggled(object sender, System.EventArgs e)
		{
			if (!word)
			{
				checkbExpression.Active = false;
				word = true;
			}
		}
		
		protected virtual void OnExpressionToggled(object sender, System.EventArgs e)
		{
			if (word)
			{
				checkbWord.Active = false;
				word = false;
			}
		}
	}
	
}


using System;
using System.Collections;
using Gtk;

namespace SharpTranslator
{
	
	public class LearnWindow : Gtk.Window
	{
		protected Gtk.Entry entryText;
		protected Gtk.Entry entryTranslation;
		protected Gtk.CheckButton checkbExpression;
		protected Gtk.CheckButton checkbWord;
		private Hashtable languages = new Hashtable();
		private bool word = true;
		private int actlangSource, actlangTarget;
		protected SharpTranslator.ReversibleCombos rCombos;
		
		public LearnWindow(int active1, int active2) : 
				base("")
		{
			Stetic.Gui.Build(this, typeof(SharpTranslator.LearnWindow));
			checkbWord.Toggled += new EventHandler(this.OnWordToggled);
			checkbExpression.Toggled += new EventHandler(this.OnExpressionToggled);
			rCombos.CheckButtonReverse.Toggled += new EventHandler(this.OnReverseToggled);
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
   	    		rCombos.ComboSource.AppendText((string)langs[i]);
   	    		id = Int32.Parse((string)langs[i+1]);
   	    		languages[langs[i]] = id;
				rCombos.ComboTarget.AppendText((string)langs[i]);
			}
			if (langs.Count >= 2)
			{
				rCombos.ComboSource.Active = actlangSource -1;
				rCombos.ComboTarget.Active = actlangTarget -1;
			}
		}
		
		protected virtual void OnAccept(object sender, System.EventArgs e)
		{
			string sourcelang = rCombos.ComboSource.ActiveText;
			string targetlang = rCombos.ComboTarget.ActiveText;
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

		protected virtual void OnClose(object sender, Gtk.DeleteEventArgs e)
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
		
		
		protected virtual void OnReverseToggled(object sender, System.EventArgs e)
		{
			entryText.HasFocus = true;
		}
	}
	
}

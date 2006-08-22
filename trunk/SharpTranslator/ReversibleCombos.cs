
using System;

namespace SharpTranslator
{
	
	public class ReversibleCombos : Gtk.Bin
	{
		protected Gtk.ComboBox comboSource;
		protected Gtk.CheckButton checkbuttonReverse;
		protected Gtk.ComboBox comboTarget;

		
		public ReversibleCombos()
		{
			Stetic.Gui.Build(this, typeof(SharpTranslator.ReversibleCombos));
			checkbuttonReverse.Toggled += new EventHandler(this.OnReverseToggled);
		}
		
		public Gtk.ComboBox ComboSource 
		{
			get { return comboSource; }
		}
		
		public Gtk.ComboBox ComboTarget
		{
			get { return comboTarget; }
		}
		
		public Gtk.CheckButton CheckButtonReverse
		{
			get { return checkbuttonReverse; }
		}
		
		protected virtual void OnReverseToggled(object sender, System.EventArgs e)
		{
			int targetActive = comboTarget.Active;
			comboTarget.Active = comboSource.Active;
			comboSource.Active = targetActive;
			//entryKeyword.HasFocus = true;
		}
	}
	
}


using System;

namespace SharpTranslator
{
	
	public class AboutDialog : Gtk.Dialog
	{
		
		public AboutDialog()
		{
			Stetic.Gui.Build(this, typeof(SharpTranslator.AboutDialog));
			this.Title = "About SharpTranslator";
		}

		protected virtual void OnClose(object sender, System.EventArgs e)
		{
			this.Hide();
			this.Destroy();
		}
	}
	
}

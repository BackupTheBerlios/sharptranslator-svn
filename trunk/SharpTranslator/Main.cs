// project created on 14/08/2006 at 11:24
using System;
using Gtk;

namespace SharpTranslator
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Application.Init ();
			MainWindow win = new MainWindow ();
			win.Show ();
			Application.Run ();
		}
	}
}
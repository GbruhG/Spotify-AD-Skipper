using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;


namespace SpotifyAntiADD_FINAL
{
    public partial class Form1 : Form
    {
		globalKeyboardHook gkh = new globalKeyboardHook();
		SpotifyHandler spotify = new SpotifyHandler();

		string spotifyPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Spotify\\Spotify.exe";
		[DllImport("user32.dll", SetLastError = true)]
		public static extern void keybd_event(byte virtualKey, byte scanCode, uint flags, IntPtr extraInfo);

		public Form1()
        {
            InitializeComponent();
			gkh.HookedKeys.Add(Keys.F12);
			gkh.KeyDown += new KeyEventHandler(gkh_KeyDown);
		}

		void gkh_KeyDown(object sender, KeyEventArgs e)
		{
			spotify.close();
			e.Handled = true;
		}
	}
}



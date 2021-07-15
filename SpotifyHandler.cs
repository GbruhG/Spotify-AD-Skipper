using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Management;
using System.Threading;
using System.Runtime.InteropServices;

namespace SpotifyAntiADD_FINAL
{
    class SpotifyHandler
    {
        string spotifyPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Spotify\\Spotify.exe";

        [DllImport("user32.dll", SetLastError = true)]
        public static extern void keybd_event(byte virtualKey, byte scanCode, uint flags, IntPtr extraInfo);

        public void close()
        {

            var spotifyProcess = Process.GetProcessesByName("spotify");

            if (spotifyProcess != null)
            {

                foreach (var spot in spotifyProcess)
                {
                    spot.Kill();
                }

                Process.Start(spotifyPath);
                Thread.Sleep(4000);
                keybd_event(0xB3, 0, 0x0001, IntPtr.Zero);
            }
        }


    }
}

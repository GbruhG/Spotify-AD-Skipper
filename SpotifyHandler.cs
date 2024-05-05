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
        // gets the spotify exe path
        string spotifyPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Spotify\\Spotify.exe";

        [DllImport("user32.dll", SetLastError = true)]
        public static extern void keybd_event(byte virtualKey, byte scanCode, uint flags, IntPtr extraInfo);

        public void close()
        {
            while (true)
            {
                // gets all the spotify processes
                var spotifyProcess = Process.GetProcessesByName("spotify");

                // checks if spotify is running
                if (spotifyProcess != null)
                {
                    // loop through all the spotify processes
                    foreach(var process in spotifyProcess)
                    {
                        // checks if the spotify window title contains "Advertisement", if it does that means an ad is running
                        if (process.MainWindowTitle.Contains("Advertisement", StringComparison.InvariantCultureIgnoreCase))
                        {
                            // loop through all the spotify processes and kills them
                            foreach (var spot in spotifyProcess)
                            {
                                spot.Kill();
                            }

                            // starts spotify
                            Process.Start(spotifyPath);

                            // waits for spotify to load
                            Thread.Sleep(4000);

                            // presses keyboard button (PLay Media) to automatically resume playing the song
                            keybd_event(0xB3, 0, 0x0001, IntPtr.Zero);
                        }
                    }
                }

                // waits for 1 second before checking if an ad is running
                Thread.Sleep(1000);
            }
        }


    }
}

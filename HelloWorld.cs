using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using SdlDotNet;
using SdlDotNet.Core;
using SdlDotNet.Graphics;
using SdlDotNet.Graphics.Primitives;
using SdlDotNet.Input;

namespace SDLTemplate
{
    public class HelloWorld
    {
        public Box Player;

        public HelloWorld()
        {
            // System Setup
            Video.SetVideoMode(400, 300);
            Video.WindowCaption = "Hello World!";

            // Objects Setup
            Player = new Box(20, 20, 60, 60);
        }

        public void Start()
        {
            // Setup SDL Events
            Events.Fps = 50;
            Events.Tick += new EventHandler<TickEventArgs>(Events_Tick);
            Events.Quit += new EventHandler<QuitEventArgs>(Events_Quit);
            Events.KeyboardDown += new EventHandler<KeyboardEventArgs>(Events_KeyboardDown);
            Events.Run();
        }

        private void Events_Tick(object sender, TickEventArgs e)
        {
            // Clear Screen, Draw, Output
            Video.Screen.Fill(Color.Black);
            Player.Draw(Video.Screen, Color.Wheat, false, true);
            Video.Screen.Update();

            // Handle Movement
            KeyboardState KeyState = new KeyboardState(true);
            if (KeyState.IsKeyPressed(Key.A)) { Player.XPosition1 -= 2; Player.XPosition2 -= 2; }
            else if (KeyState.IsKeyPressed(Key.D)) { Player.XPosition1 += 2; Player.XPosition2 += 2; }
            if (KeyState.IsKeyPressed(Key.W)) { Player.YPosition1 -= 2; Player.YPosition2 -= 2; }
            else if (KeyState.IsKeyPressed(Key.S)) { Player.YPosition1 += 2; Player.YPosition2 += 2; }
        }

        private void Events_KeyboardDown(object sender, KeyboardEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Escape:
                case Key.Q:
                    Events.QuitApplication();
                    break;
            }
        }

        private void Events_Quit(object sender, QuitEventArgs e)
        {
            Events.QuitApplication();
        }
    }
}

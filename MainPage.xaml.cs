using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Asteroids {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page {
        Asteroids_Game game;
        public MainPage() {
            this.InitializeComponent();
            game = new Asteroids_Game(1400, 760);
            Window.Current.CoreWindow.KeyDown += OnKeyDown;
            Window.Current.CoreWindow.KeyUp += OnKeyUp;
            
        }

        private void Canvas_Draw(Microsoft.Graphics.Canvas.UI.Xaml.ICanvasAnimatedControl sender, Microsoft.Graphics.Canvas.UI.Xaml.CanvasAnimatedDrawEventArgs args) {
            game.DrawAllGameObjects(args.DrawingSession);
        }

        private void Canvas_Update(Microsoft.Graphics.Canvas.UI.Xaml.ICanvasAnimatedControl sender, Microsoft.Graphics.Canvas.UI.Xaml.CanvasAnimatedUpdateEventArgs args) {
            game.Update();
        }

        private void Canvas_CreateResources(Microsoft.Graphics.Canvas.UI.Xaml.CanvasAnimatedControl sender, Microsoft.Graphics.Canvas.UI.CanvasCreateResourcesEventArgs args) {

        }

        private void OnKeyDown(CoreWindow sender, KeyEventArgs args) {
            if (args.VirtualKey == Windows.System.VirtualKey.W || args.VirtualKey == Windows.System.VirtualKey.Up) {
                game.IsUpButtonPressed = true;
            }
            if (args.VirtualKey == Windows.System.VirtualKey.S || args.VirtualKey == Windows.System.VirtualKey.Down) {
                game.IsDownButtonPressed = true;
            }
            if (args.VirtualKey == Windows.System.VirtualKey.A || args.VirtualKey == Windows.System.VirtualKey.Left) {
                game.IsLeftButtonPressed = true;
            }
            if (args.VirtualKey == Windows.System.VirtualKey.D || args.VirtualKey == Windows.System.VirtualKey.Right) {
                game.IsRightButtonPressed = true;
            }
            if (args.VirtualKey == Windows.System.VirtualKey.Space) {
                game.IsSpaceBarPressed = true;
            }
        }

        private void OnKeyUp(CoreWindow sender, KeyEventArgs args) {
            if (args.VirtualKey == Windows.System.VirtualKey.W || args.VirtualKey == Windows.System.VirtualKey.Up) {
                game.IsUpButtonPressed = false;
            }
            if (args.VirtualKey == Windows.System.VirtualKey.S || args.VirtualKey == Windows.System.VirtualKey.Down) {
                game.IsDownButtonPressed = false;
            }
            if (args.VirtualKey == Windows.System.VirtualKey.A || args.VirtualKey == Windows.System.VirtualKey.Left) {
                game.IsLeftButtonPressed = false;
            }
            if (args.VirtualKey == Windows.System.VirtualKey.D || args.VirtualKey == Windows.System.VirtualKey.Right) {
                game.IsRightButtonPressed = false;
            }
            if (args.VirtualKey == Windows.System.VirtualKey.Space) {
                game.IsSpaceBarPressed = false;
            }
        }
    }
}
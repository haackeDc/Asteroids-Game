using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.UI.Xaml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Asteroids {
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page {
        Asteroids_Game game;
        MainMenu mainMenu;
        CanvasBitmap spaceImage;

        public MainPage() {
            this.InitializeComponent();
            mainMenu = new MainMenu();
            game = new Asteroids_Game(1400, 760);
            Window.Current.CoreWindow.KeyDown += OnKeyDown;
            Window.Current.CoreWindow.KeyUp += OnKeyUp;
            
        }

        private void Canvas_Draw(Microsoft.Graphics.Canvas.UI.Xaml.ICanvasAnimatedControl sender, Microsoft.Graphics.Canvas.UI.Xaml.CanvasAnimatedDrawEventArgs args) {
            if (!mainMenu.gameStarted)
            {
                if (mainMenu.onInstructions == false && mainMenu.onCredits == false)
                {
                    mainMenu.DrawMainMenu(args.DrawingSession);
                }
                else if(mainMenu.onInstructions == true && mainMenu.onCredits == false)
                {
                    mainMenu.DrawInstructions(args.DrawingSession);
                }
                else
                {
                    mainMenu.DrawCredits(args.DrawingSession);
                }
            }
            else if (!game.gameOver)
            {
                game.DrawAllGameObjects(args.DrawingSession);

            }
            else
            {
                var fontFormat = new Microsoft.Graphics.Canvas.Text.CanvasTextFormat
                {
                    FontSize = 48
                };
                args.DrawingSession.DrawImage(spaceImage);
                //args.DrawingSession.Clear(Colors.Red);
                args.DrawingSession.DrawText("  Game over! Do you want to play again? (Y/N)", 0, 200, Colors.LightYellow, fontFormat);
            }
        }

        private void Canvas_Update(Microsoft.Graphics.Canvas.UI.Xaml.ICanvasAnimatedControl sender, Microsoft.Graphics.Canvas.UI.Xaml.CanvasAnimatedUpdateEventArgs args) {

            game.Update();
        }
        private void Canvas_CreateResources(CanvasAnimatedControl sender, Microsoft.Graphics.Canvas.UI.CanvasCreateResourcesEventArgs args) {
            args.TrackAsyncAction(CreateResources(sender).AsAsyncAction());
        }

        async Task CreateResources(Microsoft.Graphics.Canvas.UI.Xaml.CanvasAnimatedControl sender)
        {
            spaceImage = await CanvasBitmap.LoadAsync(sender, "Assets/spacepic.png");
            game.spaceImage = spaceImage;
            mainMenu.spaceImage = spaceImage;
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
            if (args.VirtualKey == Windows.System.VirtualKey.Y && game.gameOver == true)
            {
                game = new Asteroids_Game(1400, 760);
                Window.Current.CoreWindow.KeyDown += OnKeyDown;
                Window.Current.CoreWindow.KeyUp += OnKeyUp;
            }
            if (args.VirtualKey == Windows.System.VirtualKey.N && game.gameOver == true)
            {
                mainMenu = new MainMenu();
            }
            if (args.VirtualKey == Windows.System.VirtualKey.Number1 && mainMenu.gameStarted == false)
            {
                mainMenu.gameStarted = true;
                game = new Asteroids_Game(1400, 760);
                Window.Current.CoreWindow.KeyDown += OnKeyDown;
                Window.Current.CoreWindow.KeyUp += OnKeyUp;
            }
            if (args.VirtualKey == Windows.System.VirtualKey.Number2 && mainMenu.gameStarted == false)
            {
                mainMenu.onInstructions = true;
            }
            if (args.VirtualKey == Windows.System.VirtualKey.Number3 && mainMenu.gameStarted == false)
            {
                mainMenu.onCredits = true;
            }
            if (args.VirtualKey == Windows.System.VirtualKey.B && mainMenu.gameStarted == false)
            {
                mainMenu.onInstructions = false;
                mainMenu.onCredits = false;
            }
        }
    }
}
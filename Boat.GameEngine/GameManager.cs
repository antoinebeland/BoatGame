using System;
using System.Drawing;
using Boat.GameObject.Vehicule;
using SdlDotNet.Core;
using SdlDotNet.Graphics;

namespace Boat.GameEngine
{
    public class GameManager : IDisposable
    {
        private readonly Surface _video;
        private readonly GameObjectSprite _gameObjectSprite1;
        private readonly GameObjectSprite _gameObjectSprite2;

        public GameManager()
        {
            _video = Video.SetVideoMode(800, 600, 32, false, false, false, true);
            _gameObjectSprite1 = new GameObjectSprite(new Battlecruiser());
            _gameObjectSprite2 = new GameObjectSprite(new Frigate());
        }

        public void Initialize()
        {
            Events.Quit += (sender, args) => Events.QuitApplication();
            Events.Fps = 60;
            
            Events.Tick += EventsOnTick;
            Events.Run();
        }


        private void EventsOnTick(object sender, TickEventArgs tickEventArgs)
        {
            _video.Fill(Color.Blue);
            _video.Blit(_gameObjectSprite1, _gameObjectSprite1.Rectangle.Location);
            _video.Blit(_gameObjectSprite2, _gameObjectSprite2.Rectangle.Location);
            _video.Update();
        }

        public void Dispose()
        {
           
        }
    }
}

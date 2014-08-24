using System;
using System.Drawing;
using Boat.GameObject.Vehicule;
using SdlDotNet.Core;
using SdlDotNet.Graphics;
using SdlDotNet.Graphics.Sprites;

namespace Boat.GameEngine
{
    public class GameManager : IDisposable
    {
        private readonly Surface _video;
        private readonly SpriteCollection _spriteCollection;

        public GameManager()
        {
            _video = Video.SetVideoMode(320, 240, 32, false, false, false, true);
            _spriteCollection = new SpriteCollection();
        }

        public void Initialize()
        {
            Events.Quit += (sender, args) => Events.QuitApplication();
            _spriteCollection.Add(new GameObjectSprite(new Battlecruiser()));

            
            _video.Fill(Color.Blue);
            _video.Blit(_spriteCollection);
            
            _video.Update();
            Events.Run();
        }

        public void Dispose()
        {
           
        }
    }
}

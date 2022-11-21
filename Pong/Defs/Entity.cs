using Microsoft.Xna.Framework.Graphics;

namespace Pong.Defs
{
    public class Entity
    {
        public Texture2D Texture { get; private set; } = null;
        public Entity(Texture2D texture) {
            Texture = texture;
        }
    }
}

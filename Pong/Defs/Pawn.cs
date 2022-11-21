using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Pong.Defs
{
    public class Pawn
    {
        private int _maxHealth;
        private int _health;

        public int Health
        {
            get { return _health; }
            set {
                if (value <= _maxHealth) { _health = value; } 
                else if ( value <= 0 ) { _health = 0; }
            }
        }
        public float Speed { get; private set; }
        public Vector2 Position { get; set; }
        public Texture2D Texture { get; set; }

        public Pawn(int maxHealth, float speed, Vector2 initialPosition)
        {
            _maxHealth = maxHealth;
            _health = maxHealth;
            Position = initialPosition;
            Speed = speed;
        }

        public void MoveUp()
        {
            Position.Y -= PlayerPawn.Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}

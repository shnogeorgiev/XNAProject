using Application.Util;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Entities.Classes
{
    public class GameObject
    {
        protected Texture2D texture;
        protected Vector2 position;
        protected int width, height;
        protected int objectID;

        public GameObject()
        {
            this.Position = new Vector2();

            CollisionHandler.AllObjects.Add(this);
            this.objectID = CollisionHandler.ObjectID;
            CollisionHandler.ObjectID++;
        }

        public Texture2D Texture
        {
            get { return this.texture; }
            set { this.texture = value; }
        }

        public Vector2 Position
        {
            get { return this.position; }
            set { this.position = value; }
        }
        public int Width
        {
            get { return this.width; }
            set { this.width = value; }
        }
        public int Height
        {
            get { return this.height; }
            set { this.height = value; }
        }
        public int ID
        {
            get { return this.objectID; }
            set { this.objectID = value; }
        }
    }
}

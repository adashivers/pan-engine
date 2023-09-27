using System;
using System.Collections.Generic;
using pan_engine.Engine.Objects;

namespace pan_engine.Engine.Scenes
{
    public class Scene
    {
        List<Object2D> objectsInScene;

        public Scene()
        {
            objectsInScene = new List<Object2D>();
        }

        public Scene(params Object2D[] objectList)
        {
            objectsInScene = new List<Object2D>(objectList);
        }

        public Scene(List<Object2D> objectList) 
        { 
            objectsInScene = objectList;
        }

        public void Update()
        {
            foreach (Object2D obj in objectsInScene) { obj.Update(); }
        }

        public void Draw()
        {
            foreach (Object2D obj in objectsInScene) { obj.Draw(); }
        }


    }
}

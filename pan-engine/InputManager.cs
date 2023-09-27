using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pan_engine
{
    public class InputManager : GameComponent
        /// <summary>
        /// A class that interfaces with the user to provide input info
        /// more precisely than the XNA input.
        /// </summary>
    {

        // --- Declarations ---

        private KeyboardState previousKeyboardState;
        private KeyboardState currentKeyboardState;

        private MouseState previousMouseState;
        private MouseState currentMouseState;

        public enum MouseInput
        {
            leftButton, rightButton, middleButton
        }

        public InputManager(Game game) : base(game) { }

        public override void Update(GameTime gameTime)
        {
            // update states
            previousKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();

            previousMouseState = currentMouseState;
            currentMouseState = Mouse.GetState();


            base.Update(gameTime);
        }


        // --- KEYBOARD INPUT ---

        public bool isKeyStartDown(Keys key)
        {
            if (previousKeyboardState.IsKeyDown(key)) { return false; }
            if (currentKeyboardState.IsKeyDown(key)) { return true; }
            return false;
        }

        public bool isKeyDown(Keys key)
        {
            return currentKeyboardState.IsKeyDown(key);
        }

        public bool isKeyHeld(Keys key)
        {
            if (previousKeyboardState.IsKeyUp(key)) { return false; }
            if (currentKeyboardState.IsKeyDown(key)) { return true; }
            return false;
        }

        public bool isKeyReleased(Keys key)
        {
            if (previousKeyboardState.IsKeyUp(key)) { return false; }
            if (currentKeyboardState.IsKeyUp(key)) { return true; }
            return false;
        }

        // --- MOUSE INPUT ---

        public MouseState getMouseState()
        {
            return currentMouseState;
        }

        public float getScrollWheelChange()
        {
            return currentMouseState.ScrollWheelValue - previousMouseState.ScrollWheelValue;
        }

        public bool isMouseButtonStartDown(MouseInput mInput)
        {
            switch (mInput)
            {
                case MouseInput.leftButton:
                    if (previousMouseState.LeftButton == ButtonState.Pressed) { return false; }
                    if (currentMouseState.LeftButton == ButtonState.Pressed) { return true; }
                    return false;
                case MouseInput.rightButton:
                    if (previousMouseState.RightButton == ButtonState.Pressed) { return false; }
                    if (currentMouseState.RightButton == ButtonState.Pressed) { return true; }
                    return false;
                case MouseInput.middleButton:
                    if (previousMouseState.MiddleButton == ButtonState.Pressed) { return false; }
                    if (currentMouseState.MiddleButton == ButtonState.Pressed) { return true; }
                    return false;
            }
            return false;
        }

        public bool isMouseButtonDown(MouseInput mInput)
        {
            switch (mInput)
            {
                case MouseInput.leftButton:
                    return currentMouseState.LeftButton == ButtonState.Pressed;
                case MouseInput.rightButton:
                    return currentMouseState.RightButton == ButtonState.Pressed;
                case MouseInput.middleButton:
                    return currentMouseState.MiddleButton == ButtonState.Pressed;
            }
            return false;
        }

        public bool isMouseButtonHeld(MouseInput mInput)
        {
            switch (mInput)
            {
                case MouseInput.leftButton:
                    if (previousMouseState.LeftButton == ButtonState.Released) { return false; }
                    if (currentMouseState.LeftButton == ButtonState.Pressed) { return true; }
                    return false;
                case MouseInput.rightButton:
                    if (previousMouseState.RightButton == ButtonState.Released) { return false; }
                    if (currentMouseState.RightButton == ButtonState.Pressed) { return true; }
                    return false;
                case MouseInput.middleButton:
                    if (previousMouseState.MiddleButton == ButtonState.Released) { return false; }
                    if (currentMouseState.MiddleButton == ButtonState.Pressed) { return true; }
                    return false;
            }
            return false;
        }

        public bool isMouseButtonReleased(MouseInput mInput)
        {
            switch (mInput)
            {
                case MouseInput.leftButton:
                    if (previousMouseState.LeftButton == ButtonState.Released) { return false; }
                    if (currentMouseState.LeftButton == ButtonState.Released) { return true; }
                    return false;
                case MouseInput.rightButton:
                    if (previousMouseState.RightButton == ButtonState.Released) { return false; }
                    if (currentMouseState.RightButton == ButtonState.Released) { return true; }
                    return false;
                case MouseInput.middleButton:
                    if (previousMouseState.MiddleButton == ButtonState.Released) { return false; }
                    if (currentMouseState.MiddleButton == ButtonState.Released) { return true; }
                    return false;
            }
            return false;
        }
    }
}

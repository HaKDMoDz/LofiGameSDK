Draw Testing!
            if (!pos.HasValue)
            {
                pos = Vector2.Zero;
            }
            // Check null parameters
            if (camera == null)
            {
                camera = new Camera(GameManager.Instance, 0);
                camera.Focus = Vector2.Zero;
            }
            rotation += trans.Rotation;
            if (addScale == null)
            {
                addScale = new Vector2(1, 1);
            }
            if (!color.HasValue)
            {
                color = Color;
            }

            // Source Rectangle based on current animation
            Rectangle srcAnimRect = SourceRect;
            if (CurrentSeq != null)
                srcAnimRect = GetFrameRect();

            // Position based on camera
            Vector2 camPos = camera.PositionToScreen(new Vector2(position.X + pos.Value.X, position.Y + pos.Value.Y));

            // Scale
            Vector2 worldSpaceScale = new Vector2(Size.X / SourceRect.Width, Size.Y / SourceRect.Height);
            Vector2 addedScale = new Vector2(worldSpaceScale.X * addScale.Value.X, worldSpaceScale.Y * addScale.Value.Y);
            Vector2 screenSpaceScale = camera.VectorToScreen(addedScale);

            // Wrap Mode
            if (WrapMode != FrameAnimator.EWrapMode.None)
            {
                SamplerState sState = new SamplerState();
                if (WrapMode == FrameAnimator.EWrapMode.Horizontal)
                {
                    sState.AddressU = TextureAddressMode.Wrap;
                    sState.AddressV = TextureAddressMode.Clamp;
                }
                else if (WrapMode == FrameAnimator.EWrapMode.Vertical)
                {
                    sState.AddressU = TextureAddressMode.Clamp;
                    sState.AddressV = TextureAddressMode.Wrap;
                }
                else if (WrapMode == EWrapMode.Both)
                {
                    sState.AddressU = TextureAddressMode.Wrap;
                    sState.AddressV = TextureAddressMode.Wrap;
                }
                GameManager.Instance.GraphicsMgr.GraphicsDevice.SamplerStates[0] = sState;
            }

            // Draw
            GameManager.Instance.GraphicsMgr.Draw(Texture, srcAnimRect, color.Value, Origin, camPos, screenSpaceScale, rotation, SpriteEffects.None);

            // Recover Wrap Mode
            SamplerState rcSState = new SamplerState();
            rcSState.AddressU = TextureAddressMode.Clamp;
            rcSState.AddressV = TextureAddressMode.Clamp;
            GameManager.Instance.GraphicsMgr.GraphicsDevice.SamplerStates[0] = rcSState;
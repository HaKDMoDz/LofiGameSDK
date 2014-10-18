#region File Description
//-----------------------------------------------------------------------------
// ContentProcessor1.cs
//
// Microsoft XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
#endregion

using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline.Processors;
using System.IO;
using System.ComponentModel;


namespace XBlueM
{
    /// <summary>
    /// This class will be instantiated by the XNA Content Pipeline to
    /// apply custom processing to content data, converting an object of
    /// type TInput to TOutput. The input and output types may be the same
    /// if the processor wishes to alter data without changing its type.
    ///
    /// This should be part of a Content Pipeline Extension Library project.
    ///
    /// TODO: change the ContentProcessor attribute to specify the correct
    /// display name for this processor.
    /// </summary>
    [ContentProcessor(DisplayName = "FontProcessor")]
    public class ContentProcessor1 : FontDescriptionProcessor
    {
        [DefaultValue("utf8.txt")]
        [DisplayName("Message File")]
        [Description("The characters in this file will be automatically added to the font.")]
        public string MessageFile
        {
            get { return messageFile; }
            set { messageFile = value; }
        }
        private string messageFile = "../Content/utf8.txt";

        public override SpriteFontContent Process(FontDescription input, ContentProcessorContext context)
        {

            string fullPath = Path.GetFullPath(MessageFile);

            context.AddDependency(fullPath);

            string letters = File.ReadAllText(fullPath, System.Text.Encoding.UTF8);

            foreach (char c in letters)
            {
                input.Characters.Add(c);
            }
            // 测试用添加

            return base.Process(input, context);
        }
    }
}

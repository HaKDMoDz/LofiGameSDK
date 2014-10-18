using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lofinil.GameSDK.Engine;

namespace Lofinil.GameSDK.Editor.Interception
{
    public interface IStageModule
    {
        void SelectItem(SelectMode mode, GameComponent comp);

        void ReadStage(String path);

        void CloneSelectedItem();

        void MoveSelectionToBottom();

        void MoveSelectionToTop();

        void MoveSelectionToLower();

        void MoveSelectionToUpper();

    }
}

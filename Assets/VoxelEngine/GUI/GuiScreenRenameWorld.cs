﻿using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine.UI;
using VoxelEngine.Level;

namespace VoxelEngine.GUI {

    public class GuiScreenRenameWorld : GuiScreen {

        public InputField field;
        public Button button;
        public Text textErrorMsg;
        private WorldData worldData;
        private List<WorldData> cachedWorlds;

        public void OnDisable() {
            this.field.text = string.Empty;
        }

        public void init(WorldData data, List<WorldData> cached) {
            this.worldData = data;
            this.cachedWorlds = cached;
            this.field.text = this.worldData.worldName;
        }

        public void renameWorldCallback() {
            string newName = this.field.text;
            Directory.Move("saves/" + this.worldData.worldName, "saves/" + newName);
            this.worldData.worldName = newName;
            this.openGuiScreen(this.escapeFallback);
        }

        public void characterChangeCallback() {
            this.field.text = Regex.Replace(this.field.text, GuiScreenCreateWorld.regexWorldName, "");
            bool validName = true;
            foreach(WorldData d in this.cachedWorlds) {
                if(d.worldName == this.field.text) {
                    validName = false;
                    break;
                }
            }
            bool flag = validName || this.field.text == this.worldData.worldName;
            this.button.interactable = flag;
            this.textErrorMsg.text = flag ? string.Empty : "You may not have duplicate world names, pick a different one";
        }
    }
}
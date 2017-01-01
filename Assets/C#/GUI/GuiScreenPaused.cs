﻿using UnityEngine;

public class GuiScreenPaused : GuiScreen {

    public override GuiScreen onEscape(VoxelEngine voxelEngine) {
        this.setActive(false);
        voxelEngine.isPaused = false;
        return null;
    }

    public void saveCallback(bool exitWorld) {
        World world = VoxelEngine.singleton.worldObj;
        world.saveEntireWorld();
        if(exitWorld) {
            VoxelEngine ve = VoxelEngine.singleton;
            ve.player.cleanupObject();
            GameObject.Destroy(world.gameObject);
            ve.openGuiScreen(this.escapeFallback); //Saves us needing a new field since we dont use base.escapeFallback
            ve.worldObj = null;
            ve.player = null;
            ve.isPaused = false;
            ve.showDebugText = false;
            ve.isDeveloperMode = false;
        }
    }
}

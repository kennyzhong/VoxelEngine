﻿using UnityEngine;
using VoxelEngine.Blocks;
using VoxelEngine.Util;

namespace VoxelEngine.Render.BlockRender {

    public class BlockRendererPrimitiveCube : BlockRendererPrimitive {

        public BlockRendererPrimitiveCube() {
            this.lookupAdjacentLight = true;
        }

        public override void renderBlock(Block b, int meta, MeshBuilder meshData, int x, int y, int z, bool[] renderFace, Block[] surroundingBlocks) {
            // North
            if (renderFace[0]) {
                meshData.addQuad(
                    new Vector3(x + 0.5f, y - 0.5f, z + 0.5f),
                    new Vector3(x + 0.5f, y + 0.5f, z + 0.5f),
                    new Vector3(x - 0.5f, y + 0.5f, z + 0.5f),
                    new Vector3(x - 0.5f, y - 0.5f, z + 0.5f),
                    b.getUVs(meta, Direction.NORTH, this.preAllocatedUvArray),
                    LightHelper.NORTH);
            }
            // East
            if (renderFace[1]) {
                meshData.addQuad(
                    new Vector3(x + 0.5f, y - 0.5f, z - 0.5f),
                    new Vector3(x + 0.5f, y + 0.5f, z - 0.5f),
                    new Vector3(x + 0.5f, y + 0.5f, z + 0.5f),
                    new Vector3(x + 0.5f, y - 0.5f, z + 0.5f),
                    b.getUVs(meta, Direction.EAST, this.preAllocatedUvArray),
                    LightHelper.EAST);
            }
            // South
            if (renderFace[2]) {
                meshData.addQuad(
                    new Vector3(x - 0.5f, y - 0.5f, z - 0.5f),
                    new Vector3(x - 0.5f, y + 0.5f, z - 0.5f),
                    new Vector3(x + 0.5f, y + 0.5f, z - 0.5f),
                    new Vector3(x + 0.5f, y - 0.5f, z - 0.5f),
                    b.getUVs(meta, Direction.SOUTH, this.preAllocatedUvArray),
                    LightHelper.SOUTH);
            }
            // West
            if (renderFace[3]) {
                meshData.addQuad(
                    new Vector3(x - 0.5f, y - 0.5f, z + 0.5f),
                    new Vector3(x - 0.5f, y + 0.5f, z + 0.5f),
                    new Vector3(x - 0.5f, y + 0.5f, z - 0.5f),
                    new Vector3(x - 0.5f, y - 0.5f, z - 0.5f),
                    b.getUVs(meta, Direction.WEST, this.preAllocatedUvArray),
                    LightHelper.WEST);
            }
            // Up
            if (renderFace[4]) {
                meshData.addQuad(
                    new Vector3(x - 0.5f, y + 0.5f, z + 0.5f),
                    new Vector3(x + 0.5f, y + 0.5f, z + 0.5f),
                    new Vector3(x + 0.5f, y + 0.5f, z - 0.5f),
                    new Vector3(x - 0.5f, y + 0.5f, z - 0.5f),
                    b.getUVs(meta, Direction.UP, this.preAllocatedUvArray),
                    LightHelper.UP);
            }
            // Down
            if (renderFace[5]) {
                meshData.addQuad(
                    new Vector3(x - 0.5f, y - 0.5f, z - 0.5f),
                    new Vector3(x + 0.5f, y - 0.5f, z - 0.5f),
                    new Vector3(x + 0.5f, y - 0.5f, z + 0.5f),
                    new Vector3(x - 0.5f, y - 0.5f, z + 0.5f),
                    b.getUVs(meta, Direction.DOWN, this.preAllocatedUvArray),
                    LightHelper.DOWN);
            }
        }
    }
}

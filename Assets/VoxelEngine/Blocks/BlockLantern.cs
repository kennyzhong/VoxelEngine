﻿using VoxelEngine.Containers;
using VoxelEngine.Items;
using VoxelEngine.Level;
using VoxelEngine.Util;

namespace VoxelEngine.Blocks {

    public class BlockLantern : Block {

        public BlockLantern(int id) : base(id) { }

        public override ItemStack[] getDrops(World world, BlockPos pos, int meta, ItemTool brokenWith) {
            return new ItemStack[] { new ItemStack(Block.lanternOff) };
        }

        /*
        public override void onNeighborChange(World world, BlockPos pos, int meta, Direction neighborDir) {
            //TODO
            if (neighborDir == Direction.DOWN && !world.getBlock(pos.move(neighborDir)).isSolid) {
                world.breakBlock(pos, null);
            }
        }
        */

        public override bool acceptsWire(Direction directionOfWire, int meta) {
            return true;
        }
    }
}

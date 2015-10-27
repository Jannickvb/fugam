﻿using System;
using System.Drawing;

namespace FugamUtil.Tile
{
    public class TileMap
    {
        public int[,] Tiles { get; }

        public TileMap()
        {
            Tiles = new int[16,16];
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Fugam.Levels.Tile;
using Fugam.Model.Drawable;


namespace Fugam.Levels
{
    public class Level
    {
        public TileMap TileMap { get; }
        public List<Trigger> Triggers { get; }
        private bool[] _triggersActivate;

        public Level(TileMap tm)
        {
            TileMap = tm;
            Triggers = tm.LoadTiles();
            _triggersActivate = new bool[Triggers.Count];
        }

        public void CheckTriggers(YourPlayer player, Player[] otherPlayers)
        {
            for (int i = 0; i < _triggersActivate.Length; i++)
            {
                _triggersActivate[i] = false;
            }

            for (int i = 0; i < _triggersActivate.Length; i++)
            {
                _triggersActivate[i] = Triggers.ElementAt(i).PlayerOnTile(player);
                if (_triggersActivate[i])
                {
                    break;
                }
            }
            for (int i = 0; i < _triggersActivate.Length; i++)
            {
                foreach(Player p in otherPlayers)
                {
                    if (!_triggersActivate[i])
                    {
                        _triggersActivate[i] = Triggers.ElementAt(i).PlayerOnTile(p);
                        if (_triggersActivate[i])
                        {
                            break;
                        }
                    }
                }
            }

            for (int i = 0; i < _triggersActivate.Length; i++)
            {
                if (_triggersActivate[i])
                {
                    Triggers.ElementAt(i).Activate();
                }
                else
                {
                    Triggers.ElementAt(i).DeActivate();
                }
            }
        }

        public void Draw(Graphics g)
        {
            for(int i = 0; i < TileMap.getTileMap().GetLength(0); i++)
            {
                for(int j = 0; j< TileMap.getTileMap().GetLength(1); j++)
                {
                    if(TileMap.getTileMap()[i, j] != null)
                    TileMap.getTileMap()[i, j].DrawTile(g);
                }
            }

            for (int i = 0; i < TileMap.getTileMap().GetLength(0); i++)
            {
                g.DrawLine(Pens.Blue, 0, i * Tile.Tile.Size, 800, i * Tile.Tile.Size);
                
            }
            for (int j = 0; j < TileMap.getTileMap().GetLength(1); j++)
            {
                g.DrawLine(Pens.Blue, j * Tile.Tile.Size, 0, j * Tile.Tile.Size, 600);
            }
        }
    }
}

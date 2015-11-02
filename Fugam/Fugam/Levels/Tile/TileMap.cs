using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Fugam.Levels.Tile
{
    public class TileMap
    {
        private string[,] tilemap;
        private Tile[,] tiles;
        public int height { get; }
        public int width { get; }
        public bool IsCollisonMap { get; }
        public List<Trigger> Triggers { get; } 
        public List<Obstacle> Obstacles { get; set; } 

        public TileMap(string[,] tilemap,bool collisonMap)
        {
            this.tilemap = tilemap;
            height = tilemap.GetLength(0);
            width = tilemap.GetLength(1);
            tiles = new Tile[width,height];
            IsCollisonMap = collisonMap;
            Triggers = new List<Trigger>();
            Obstacles = new List<Obstacle>();
            LoadTiles();
        }

        private void LoadTiles()
        {
            for (int i = 0; i < height; i++)
            {
                for (int k = 0; k < width; k++)
                {
                    if (IsCollisonMap)
                    {
                        if (int.Parse(tilemap[k, i]) != 0)
                        {
                            tiles[k, i] = new Tile(true, i * Tile.Size, k * Tile.Size, tilemap[k, i]);
                        }
                        else
                        {
                            tiles[k, i] = new Tile(false, i * Tile.Size, k * Tile.Size, tilemap[k, i]);
                        }
                    }
                    else
                    {
                        string[] splitId = tilemap[k, i].Split('/');

                        //foreach (string t in splitId)
                        //{
                        //    Console.WriteLine(t);
                        //}

                        if (splitId.Length > 1)
                        {
                            if (splitId[0] == "42")//obstacle
                            {
                                Obstacle ob = new Obstacle(i * Tile.Size, k * Tile.Size, splitId[1]);
                                Obstacles.Add(ob);
                                tiles[k, i] = ob;

                                foreach (Trigger t in Triggers.Where(t => t.Obstacle == null).Where(t => t.TriggerID == ob.ObstracleID))
                                {
                                    t.Obstacle = ob;
                                    break;
                                }
                            }
                            if (splitId[0] == "157")//trigger
                            {
                                Trigger t = new Trigger(i * Tile.Size, k * Tile.Size, splitId[1]);
                                Triggers.Add(t);
                                tiles[k, i] = t;

                                foreach (Obstacle ob in Obstacles.Where(ob => ob.ObstracleID == t.TriggerID))
                                {
                                    t.Obstacle = ob;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            tiles[k, i] = new Tile(false, i * Tile.Size, k * Tile.Size, tilemap[k, i]);
                        }
                    }
                }
            }
            //foreach (Obstacle ob in Obstacles)
            //{
            //    Console.WriteLine(ob.ToString());
            //}
            //foreach (Trigger t in Triggers)
            //{
            //    Console.WriteLine(t.ToString()+"\t"+t.Obstacle.ToString()); 
            //    t.Activate();
            //}
        }

        public Tile[,] getTileMap()
        {
            return tiles;
        }

    }
}

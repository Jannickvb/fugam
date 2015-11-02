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
        public int y { get; }
        public int x { get; }
        public bool IsCollisonMap { get; }

        public TileMap(string[,] tilemap,bool collisonMap)
        {
            this.tilemap = tilemap;
            y = tilemap.GetLength(0);
            x = tilemap.GetLength(1);
            tiles = new Tile[x,y];
            IsCollisonMap = collisonMap;
        }

        public List<Trigger> LoadTiles()
        {
            List<Trigger> triggers = new List<Trigger>();
            List<Obstacle> obstacles = new List<Obstacle>();

            for (int i = 0; i < y; i++)
            {
                for (int k = 0; k < x; k++)
                {
                    if (IsCollisonMap)
                    {
                        //if (tilemap[k,i] != 0)
                        //{
                        //    tiles[k, i] = new Tile(true, i * Tile.Size, k * Tile.Size, tilemap[k,i]);
                        //}
                        //else
                        //{
                        //    tiles[k, i] = new Tile(false, i * Tile.Size, k * Tile.Size, tilemap[k,i]);
                        //}
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
                                obstacles.Add(ob);
                                tiles[k, i] = ob;

                                foreach (Trigger t in triggers.Where(t => t.Obstacle == null).Where(t => t.TriggerID == ob.ObstracleID))
                                {
                                    t.Obstacle = ob;
                                    break;
                                }
                            }
                            if (splitId[0] == "157")//trigger
                            {
                                Trigger t = new Trigger(i * Tile.Size, k * Tile.Size, splitId[1]);
                                triggers.Add(t);
                                tiles[k, i] = t;

                                foreach (Obstacle ob in obstacles.Where(ob => ob.ObstracleID == t.TriggerID))
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
            //foreach (Obstacle ob in obstacles)
            //{
            //    Console.WriteLine(ob.ToString());
            //}
            //foreach (Trigger t in triggers)
            //{
            //    Console.WriteLine(t.ToString()+"\t"+t.Obstacle.ToString()); 
            //    t.Activate();
            //}
            return triggers;
        }

        public Tile[,] getTileMap()
        {
            return tiles;
        }

    }
}

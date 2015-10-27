using System.Drawing;
using Fugam.Levels.Tile;


namespace Fugam.Levels
{
    public class Level
    {
        public TileMap TileMap { get; }

        public Level(TileMap tm)
        {
            TileMap = tm;
        }

        public void Draw(Graphics g)
        {
            for(int i = 0; i < TileMap.getTileMap().GetLength(0); i++)
            {
                for(int j = 0; j< TileMap.getTileMap().GetLength(1); j++)
                {
                    TileMap.getTileMap()[i, j].DrawTile(g);
                }
            }
        }
    }
}

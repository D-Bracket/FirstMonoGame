using FirstMonoGame.Base._2D.Sprites;

namespace FirstMonoGame.Base._2D.Map
{
    internal abstract class TopDownMap : MapBase
    {
        #region "----------------------------- Private Fields ------------------------------"
        
        #endregion



        #region "------------------------------ Constructor --------------------------------"
        public TopDownMap(int xSize, int ySize, int numberOfColumns, int numberOfRows) : base(xSize, ySize, numberOfColumns, numberOfRows)
        {
            Rows = new MapRow[numberOfRows];
            for (int i = 0; i < Rows.Length; i++)
            {
                Rows[i] = new MapRow(numberOfColumns);
            }
            var t1 = Rows[1].Columns[2].Tiles[1].YPosition;
            var t2 = Rows[1].Columns[2].Tile.YPosition;

            Tiles = new MapTile[numberOfRows,numberOfColumns];
            for (int i = 0;i < numberOfRows; i++)
            {
                for (int j = 0;j < numberOfColumns; j++)
                {
                    Tiles[i, j] = new MapTile() { XPosition = i, YPosition = j };
                }
            }
            var t3 = Tiles[1,2].YPosition;

            //Test =  new MapTile[numberOfColumns][];
            //var t4 = Test[1][2].YPosition;
        }
        #endregion
        public MapTile[][] Test;


        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"

        #endregion

        #region "----------------------------- Private Methods -----------------------------"

        #endregion

        #region "------------------------------ Event Handling -----------------------------"

        #endregion
        #endregion


        #region "--------------------------- Public Propterties ----------------------------"
        #region "------------------------------- Properties --------------------------------"
        public MapRow[] Rows { get; set; }



        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion
        #endregion
    }

    internal class MapRow
    {
        public MapRow(int numberOfColumns)
        {
            Columns = new MapColumn[numberOfColumns];
            for (int i = 0;i < Columns.Length; i++)
            {
                Columns[i] = new MapColumn(numberOfColumns);
            }
        }
        public int Index { get; set; }
        public MapColumn[] Columns { get; set; }
    }

    internal class MapColumn
    {
        public MapColumn(int numberOfRows)
        {
            Tiles = new MapTile[numberOfRows];
            for (int i = 0; i < Tiles.Length; i++)
            {
                Tiles[i] = new MapTile();
            }
        }
        public int Index { get; set; }
        public MapTile[] Tiles { get; set; }
        public MapTile Tile { get; set; } = new();
    }

    internal class MapTile
    {
        public TileMapSprite TerrainTexture { get; set; }
        public int XPosition { get; set; }
        public int YPosition { get; set; }
    }
}
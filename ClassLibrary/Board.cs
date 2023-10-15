/**
 *  Gloria Quezada
 *  CST-250
 *  Milestone Project
 *  Created : 18 September 2023
 *  Last Updated: 1 October 2023
 **/


namespace ClassLibrary
{
    public class Board
    {
        // ----- ATTRIBUTES -----
        public int Size { get; set; }
        public Cell[,] Grid { get; set; }
        public int Difficulty { get; set; }
        public int SafeCells { get; set; }
        public int LiveCells { get; set; }


        // ----- CONSTRUCTORS -----

        /// <summary>
        /// Initialize board
        /// </summary>
        /// <param name="size"></param>
        public Board(int size, int difficulty)
        {
            // Set length/height size of board
            Size = size;
            Difficulty = difficulty;

            // Create a square Grid board
            Grid = new Cell[Size, Size];

            // Initialize Board
            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    Grid[row, col] = new Cell(row, col);
                }
            }

            // Set live cells
            SetUpLiveNeighbors();
        }

        // ----- METHODS -----

        /// <summary>
        /// Randomly assign live bombs on board
        /// </summary>
        public void SetUpLiveNeighbors()
        {
            // Calculate number of live bombs based on dificulty percentage
            LiveCells = (Size * Size * Difficulty) / 100;

            // Note user of total live cells on board
            Console.WriteLine("Number of Live Cells: " + LiveCells);
            // Calculate and update the total number of cells not live ("safe cells")
            SafeCells = (Size * Size) - LiveCells;

            int currLiveCells = 0;

            // random generator
            Random rand = new Random();

            // Randomly assign live bombs
            while (currLiveCells < LiveCells)
            {
                // select random cell
                int randRow = rand.Next(0, Size);
                int randCol = rand.Next(0, Size);

                // only assign true if cell is not Live
                if (Grid[randRow, randCol].IsLive != true)
                {
                    Grid[randRow, randCol].IsLive = true;
                    currLiveCells++;
                }
            }
        }

        /// <summary>
        /// Utility function for CalculateLuveNieghbors()
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public bool IsValid(int row, int col)
        {
            // Returns true if Grid index can be accessed, valid Cell
            return (row >= 0) && (row < Size) && (col >= 0) && (col < Size);
        }

        /// <summary>
        /// Calculate live neighbors (0-8), Live cells are set to 9.
        /// </summary>
        public void CalculateLiveNeighbors()
        {

            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    int liveNeighbors = 0;

                    // Check Current Cell
                    if (Grid[row, col].IsLive == true)
                    {
                        Grid[row, col].LiveNeighbors = 9;
                        continue;
                    }

                    // Check Top-Left Cell
                    if (IsValid(row - 1, col - 1))
                    {
                        if (Grid[row - 1, col - 1].IsLive == true)
                        {
                            liveNeighbors++;
                        }
                    }

                    // Check Top Cell
                    if (IsValid(row - 1, col))
                    {
                        if (Grid[row - 1, col].IsLive == true)
                        {
                            liveNeighbors++;
                        }
                    }

                    // Check Top-Right Cell
                    if (IsValid(row - 1, col + 1))
                    {
                        if (Grid[row - 1, col + 1].IsLive == true)
                        {
                            liveNeighbors++;
                        }
                    }

                    // Check Left Cell
                    if (IsValid(row, col - 1))
                    {
                        if (Grid[row, col - 1].IsLive == true)
                        {
                            liveNeighbors++;
                        }
                    }

                    // Check Right Cell
                    if (IsValid(row, col + 1))
                    {
                        if (Grid[row, col + 1].IsLive == true)
                        {
                            liveNeighbors++;
                        }
                    }

                    // Check Bottom-Left Cell
                    if (IsValid(row + 1, col - 1))
                    {
                        if (Grid[row + 1, col - 1].IsLive == true)
                        {
                            liveNeighbors++;
                        }
                    }

                    // Check Bottom Cell
                    if (IsValid(row + 1, col))
                    {
                        if (Grid[row + 1, col].IsLive == true)
                        {
                            liveNeighbors++;
                        }
                    }

                    // Check Bottom-Right Cell
                    if (IsValid(row + 1, col + 1))
                    {
                        if (Grid[row + 1, col + 1].IsLive == true)
                        {
                            liveNeighbors++;
                        }
                    }

                    Grid[row, col].LiveNeighbors = liveNeighbors;

                } // exit for(col)
            } // exit for(row) 

        } // exit CalculateLiveNeigbors()

        /// <summary>
        /// Recursive function to display all neighbor cells with no live neighbors when 
        ///     a cell with no live neighbors is selected.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void FloodFill(int x, int y)
        {
            // Base Case #1 - Check that cell is on the board
            if (!IsValid(x, y))
            {
                return;
            }
            // Base Case #2 - Check that cell has not been visited before (recursive base case)
            if (Grid[x, y].IsVisited)
            {
                return;
            }
            // Base Case #3 - End recursion with cells with live neighbors
            if (Grid[x, y].LiveNeighbors < 9 && Grid[x, y].LiveNeighbors > 0)
            {
                Grid[x, y].IsVisited = true;
                return;
            }
            // Base Case #4 - Cell selected is live cell
            if (Grid[x, y].IsLive)
            {
                Grid[x, y].IsVisited = true;
                return;
            }

            // Change current cell to visited
            Grid[x, y].IsVisited = true;

            // Recursive Calls
            // Top-left
            FloodFill(x-1, y-1);
            // Top
            FloodFill(x-1, y);
            // Top-Right
            FloodFill(x-1, y + 1);
            // Left
            FloodFill(x, y-1);
            // Right
            FloodFill(x, y+1);
            // Bottom-Left 
            FloodFill(x + 1, y - 1);
            // Bottom
            FloodFill(x + 1, y);      
            // Bottom-Rihgt
            FloodFill(x+1, y+1);
        }

        /// <summary>
        /// Check if all safe cells have been visited.
        /// </summary>
        /// <returns></returns>
        public bool AllCellsVisited()
        {
            int visitedCells = 0;

            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    if (Grid[row, col].IsVisited)
                    {
                        visitedCells++;
                    }
                }
            }

            if (visitedCells == SafeCells)
            {
                return true;
            }

            return false;
        }
    }
}

namespace TicTacToe
{
    public class Location
    {
        public int row { get;}
        public int col { get; }
        public Location (int row, int col)
        {
            if (row < 0 || row > 2 || col < 0 || col > 2)
            {
                throw new System.Exception("invalid number");
            } 
                this.row = row;
                this.col = col;            
            
        }
    }
}
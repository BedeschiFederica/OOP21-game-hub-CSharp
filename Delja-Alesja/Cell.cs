using System;

namespace Delja_Alesja
{
    class Cell
    {
        private const int V = 0;
        private readonly int type;
        private readonly int position;
        private bool discovered;
        private bool flagged;

        public Cell(int type, int position, bool discovered, bool flagged) {
            this.type = type;
            this.position = position;
            this.discovered = discovered;
            this.flagged = flagged;
        }
        /*
         * Manca solo l'handler, il listener e i metodi usati dall'handler per i due modi di premere il bottone
         */

        /* 
         * - 0 if the cell is empty
         * - 1 if there is a mine
         * - 2 of there is a number
         */
        public int Type => type;
        public int Position => position;

        public bool IsDiscovered => discovered;

        public void SetDiscovered(bool discover) => this.discovered = discover;
        public bool Flagged => flagged;
        public void SetFlagged(bool flag) => this.flagged = flag;


        //questa parte va nel test insieme a right click e click
        static void Main(string[] args)
        {
            Cell cell = new Cell(3,1,false,false);
            Console.WriteLine("Prova di Cell!");
            Console.WriteLine("Tipo cella: " + cell.Type);
            if (cell.type == 0)
            {
                Console.WriteLine("Cella Vuota");
            }
            else if (cell.type == 1)
            {
                Console.WriteLine("Cella Con Mina");
            }
            else if (cell.type == 2)
            {
                Console.WriteLine("Cella Con Numero");
            }else
            { 
                Console.WriteLine("Hai inserito un numero non esatto"); 
            }
            Console.WriteLine("Posizione cella: " + cell.Position);
            Console.WriteLine("Cella scoperta: " + cell.IsDiscovered);
            Console.WriteLine("Cella con flag: " + cell.Flagged);
        }
    }
}

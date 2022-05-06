using System;

namespace Delja_Alesja
{
    class Cell
    {
        private readonly int type;
        private readonly int position;
        private bool discovered;
        private bool flagged;
        private readonly Handler handler;

        public Cell(int type, int position, bool discovered, bool flagged, Handler handler) {
            this.type = type;
            this.position = position;
            this.discovered = discovered;
            this.flagged = flagged;
            this.handler = handler;
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
    }
}

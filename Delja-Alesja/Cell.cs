using System;

namespace Delja_Alesja
{
    class Cell
    {
        private readonly int type;
        private readonly int position;
        private bool discovered;
        private readonly bool flagged;

        public bool Flagged => flagged;

        public Cell(int type, int position, bool discovered, bool flagged) {
            this.type = type;
            this.position = position;
            this.discovered = discovered;
            this.flagged = flagged;
        }

        public new int GetType()
        {
            return type;
        }
        public int GetPosition()
        {
            return position;
        }

        public bool IsDiscovered()
        {
            return discovered;
        }

        public void SetDiscovered(bool discover)
        {
            this.discovered = discover;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("prova Cell!");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Delja_Alesja
{
    class Test
    {
        static void TestCell()
        {
            Cell cell = new Cell(3, 1, false, false);
            Console.WriteLine("Prova di Cell!");
            Console.WriteLine("Tipo cella: " + cell.Type);
            if (cell.Type == 0)
            {
                Console.WriteLine("Cella Vuota");
            }
            else if (cell.Type == 1)
            {
                Console.WriteLine("Cella Con Mina");
            }
            else if (cell.Type == 2)
            {
                Console.WriteLine("Cella Con Numero");
            }
            else
            {
                Console.WriteLine("Hai inserito un numero non esatto");
            }
            Console.WriteLine("Posizione cella: " + cell.Position);
            Console.WriteLine("Cella scoperta: " + cell.IsDiscovered);
            Console.WriteLine("Cella con flag: " + cell.Flagged);
        }
        static void TestViewField()
        {
            ViewField view = new ViewField(6,4);
            Console.WriteLine("Test ViewField: ");
        }
        static void Main()
        {
            TestCell();
            TestViewField();
        }
    }
}

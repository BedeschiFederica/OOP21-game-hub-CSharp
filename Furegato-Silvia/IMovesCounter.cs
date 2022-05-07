using System;
using System.Collections.Generic;
using System.Text;

namespace Furegato_Silvia
{
    /**
    * Interface of a moves calculator.
    */
    interface IMovesCounter
    {
        /**
        * @return The counted moves.
        */
        int Count();
    }
}

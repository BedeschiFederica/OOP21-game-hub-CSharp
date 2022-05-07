using System;

namespace Furegato_Silvia
{
    /**
     * Class that simulates a pair of values.
     *
     * @param <X> X value.
     * @param <Y> Y value.
     */
    class Pair<X, Y>
    {
    private X First { get; }
    private Y Second { get; }

        public Pair(X x, Y y)
        {
            First = x;
            Second = y;
        }

        /**
        * {@inheritDoc}
        */
        public override int GetHashCode()
        {
            int prime = 31;
            int result = 1;
            result = prime * result + ((First == null) ? 0 : First.GetHashCode());
            result = prime * result + ((Second == null) ? 0 : Second.GetHashCode());
            return result;
        }

        /**
        * {@inheritDoc}
        */
        public override bool Equals(Object obj)
        {
            if (this == obj)
            {
                return true;
            }
            if (obj == null)
            {
                return false;
            }
            if (getClass() != obj.getClass())
            {
                return false;
            }
            Pair other = (Pair)obj;
            if (First == null)
            {
                if (other.x != null)
                {
                    return false;
                }
            }
            else if (!First.Equals(other.First))
            {
                return false;
            }
            if (Second == null)
            {
                if (other.y != null)
                {
                    return false;
                }
            }
            else if (!Second.Equals(other.Second))
            {
                return false;
            }
            return true;
        }

        /**
        * {@inheritDoc}
        */
        public override string ToString()
        {
            return "Pair [x=" + First + ", y=" + Second + "]";
        }
    }
}

﻿using System;

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
    private X Xpos { get; }
    private Y Ypos { get; }

        public Pair(X x, Y y)
        {
            super();
            Xpos = x;
            Ypos = y;
        }

        /**
            * {@inheritDoc}
            */
        @Override
        public int hashCode()
        {
            final int prime = 31;
            int result = 1;
            result = prime * result + ((x == null) ? 0 : x.hashCode());
            result = prime * result + ((y == null) ? 0 : y.hashCode());
            return result;
        }

        /**
            * {@inheritDoc}
            */
        @SuppressWarnings("rawtypes")
        @Override
        public boolean equals(final Object obj)
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
            final Pair other = (Pair)obj;
            if (x == null)
            {
                if (other.x != null)
                {
                    return false;
                }
            }
            else if (!x.equals(other.x))
            {
                return false;
            }
            if (y == null)
            {
                if (other.y != null)
                {
                    return false;
                }
            }
            else if (!y.equals(other.y))
            {
                return false;
            }
            return true;
        }

        /**
        * {@inheritDoc}
        */
        @Override
        public String toString()
        {
            return "Pair [x=" + x + ", y=" + y + "]";
        }
    }
}

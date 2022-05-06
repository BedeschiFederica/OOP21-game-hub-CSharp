﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Furegato_Silvia
{
    /**
    * Custom colors.
    */
    enum Colors
    {
        /**
        * Red color.
        */
        RED(0, "Red", new Color(255, 0, 0)),
        /**
         * Orange color.
         */
        ORANGE(1, "Orange", new Color(255, 135, 0)),
        /**
         * Yellow color.
         */
        YELLOW(2, "Yellow", new Color(255, 211, 0)),
        /**
         * Lime color.
         */
        LIME(3, "Lime", new Color(222, 255, 10)),
        /**
         * Green color.
         */
        GREEN(4, "Green", new Color(161, 255, 10)),
        /**
         * Light blue color.
         */
        LIGHT_BLUE(5, "Light Blue", new Color(10, 239, 255)),
        /**
         * Blue color.
         */
        BLUE(6, "Blue", new Color(20, 125, 245)),
        /**
         * Indigo color.
         */
        INDIGO(7, "Indigo", new Color(88, 10, 255)),
        /**
         * Purple color.
         */
        PURPLE(8, "Purple", new Color(190, 10, 255)),
        /**
         * Magenta color.
         */
        MAGENTA(9, "Magenta", new Color(255, 0, 84));

        private static final int MAX_COLOR_NUMBER = 10;
    private static final int MIN_COLOR_NUMBER = 0;
    private static final Random RAND_COLOR = new Random();
    private final int colorValue;
    private final String name;
        private final Color actualColor;

        Colors(final int number, final String name, final Color color)
    {
        this.colorValue = number;
        this.name = name;
        this.actualColor = color;
    }

    /**
     * Get a list of random colors of length n.
     * 
     * @param n The number of colors.
     * @return A list of random colors.
     */
    public static List<Colors> getRandomColors(final int n)
    {

        if (n > MAX_COLOR_NUMBER || n < MIN_COLOR_NUMBER)
        {
            throw new IllegalArgumentException("Input number was too large or too little. Try with a number between " + MIN_COLOR_NUMBER + " and " + MAX_COLOR_NUMBER);
        }
        else
        {
            final List<Colors> result = new LinkedList<>(Arrays.asList(Colors.values()));
            for (int i = 0; i < (MAX_COLOR_NUMBER - n); i++)
            {
                result.remove(RAND_COLOR.nextInt(MAX_COLOR_NUMBER - i));
            }
            return result;
        }

    }

    /**
     * Translate a color from a java.awt.Color type of color to a Colors color.
     * 
     * @param colorToTranslate The color you want to translate.
     * @return Translated color.
     */
    public static Colors translateColor(final Color colorToTranslate)
    {
        final List<Colors> colorsList = new LinkedList<>(Arrays.asList(Colors.values()));
        final List<Colors> requestedColor = colorsList.stream()
                                            .filter(c->c.getActualColor().equals(colorToTranslate))
                                            .collect(Collectors.toList());
        if (requestedColor.isEmpty())
        {
            return null;
        }
        return requestedColor.get(0);
    }

    /**
     * @return The number assigned to the color.
     */
    public int getColorValue()
    {
        return this.colorValue;
    }

    /**
     * @return The color's name.
     */
    public String getName()
    {
        return this.name;
    }

    /**
     * @return The java.awt.Color associated to the color.
     */
    public Color getActualColor()
    {
        return this.actualColor;
    }

    @Override
        public String toString()
    {
        return this.name + ": " + this.colorValue + ", " + this.actualColor;
    }

}
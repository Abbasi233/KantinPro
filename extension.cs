﻿namespace KantinX
{
    public static class Extension
    {
        public static string Format(this decimal value)
        {
            return value.ToString("0.00");
        }
    }
}

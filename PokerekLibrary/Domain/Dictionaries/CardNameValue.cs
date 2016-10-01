﻿using System.Collections.Generic;

namespace PokerekLibrary.Domain.Dictionaries
{
    public static class CardNameValue
    {
        public static Dictionary<int, string> Dictionary()
        {
            return new Dictionary<int, string>
            {
                {2,"2"},
                {3,"3"},
                {4,"4"},
                {5,"5"},
                {6,"6"},
                {7,"7"},
                {8,"8"},
                {9,"9"},
                {10,"10"},
                {11,"J"},
                {12,"D"},
                {13,"K"},
                {14,"A"}
            };
        }
    }
}

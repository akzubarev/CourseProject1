using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lib
{
    [Serializable]
    public class Production
    {
        public Production() : this(0, 0, 0, 0, 0) { }
        public Production(int w, int i, int f, int s, int h)
        {
            Wood = w;
            Iron = i;
            Food = f;
            Science = s;
            Humans = h;
        }

        public int Wood;
        public int Iron;
        public int Food;
        public int Science;
        public int Humans;

        public override string ToString()
        {
            string result = "";

            if (Wood != 0) result += "Wood: " + Wood + "  ";
            if (Iron != 0) result += "Iron: " + Iron + "  ";
            if (Food != 0) result += "Food: " + Food + "  ";
            if (Science != 0) result += "Science: " + Science;

            if (result == "") return "Nothing";
            return result;
        }

        public static Production operator +(Production left, Production right)
        {
            return new Production(left.Wood + right.Wood, left.Iron + right.Iron,
                left.Food + right.Food, left.Science + right.Science, left.Humans + right.Humans);
        }

        public static Production operator -(Production left, Production right)
        {
            return new Production(left.Wood - right.Wood, left.Iron - right.Iron,
                left.Food - right.Food, left.Science - right.Science, left.Humans + right.Humans);
        }

        public static Production operator *(Production left, Production right)
        {
            return new Production(left.Wood * right.Wood, left.Iron * right.Iron,
                left.Food * right.Food, left.Science * right.Science, left.Humans * right.Humans);
        }

        public static Production operator *(Production left, int right)
        {
            return new Production(left.Wood * right, left.Iron * right,
                left.Food * right, left.Science * right, left.Humans * right);
        }

        public static Production operator /(Production left, int right)
        {
            return new Production(left.Wood / right, left.Iron / right,
                left.Food / right, left.Science / right, left.Humans / right);
        }

        public static bool operator >(Production left, Production right)
        {
            if (left.Wood >= right.Wood && left.Iron >= right.Iron)
                return true;
            else return false;
        }

        public static bool operator <(Production left, Production right)
        {
            return right > left;
        }

    }
}
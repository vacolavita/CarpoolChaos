using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class splashManager
{
    public class splash {
        public int style;
        public string text;

        public splash(int style, string text)
        {
            this.style = style;
            this.text = text;
        }
    }
    public static Queue<splash> splashes = new Queue<splash>();
    public static void makeSplash(int style, string text) {
        splashes.Enqueue(new splash(style, text));
    }


}

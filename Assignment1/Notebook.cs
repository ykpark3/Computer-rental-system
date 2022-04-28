using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment1
{
    class Notebook : Computer
    {
        public Notebook(int computerId) : base(computerId)
        {
            Type = "Notebook";

            UsedFor = new string[] { "Internet", "Scientific" };
            price = 10000;
        }
        public int NotebookId { get; set; }  // notebook 아이디

    }
}

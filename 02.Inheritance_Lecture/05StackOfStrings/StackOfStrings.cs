using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            return this.IsEmpty();
        }

        public void AddRange(Stack<string> strings)
        {
            foreach (var str in strings)
            {
                this.Push(str);
            }
        }
    }
}

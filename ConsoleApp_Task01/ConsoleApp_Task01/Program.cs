using Wintellect.PowerCollections;

Wintellect.PowerCollections.Stack<char> stack = new();

stack.Push('f');
stack.Push('c');

Console.WriteLine("Результат " + stack.Pop() + " " + stack.Capacity + " " + stack.Count);
using System;
using System.Collections;

namespace CompositeShapes
{
    abstract class Shape
    {
        protected string name;

        public Shape(string name)
        {
            this.name = name;
        }

        public abstract void Add(Shape s);
        public abstract void Remove(Shape s);
        public abstract void Display(int depth);
    }

    class CompositeShape : Shape
    {
        private ArrayList children = new ArrayList();

        public CompositeShape(string name) : base(name) { }

        public override void Add(Shape shape)
        {
            children.Add(shape);
        }

        public override void Remove(Shape shape)
        {
            children.Remove(shape);
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + name);

            foreach (Shape shape in children)
            {
                shape.Display(depth + 2);
            }
        }
    }

    class SimpleShape : Shape
    {
        public SimpleShape(string name) : base(name) { }

        public override void Add(Shape s)
        {
            Console.WriteLine("Cannot add to a simple shape");
        }

        public override void Remove(Shape s)
        {
            Console.WriteLine("Cannot remove from a simple shape");
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + name);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Shape root = new CompositeShape("Canvas");

            root.Add(new SimpleShape("Circle"));
            root.Add(new SimpleShape("Square"));

            Shape group = new CompositeShape("Group 1");
            group.Add(new SimpleShape("Triangle"));
            group.Add(new SimpleShape("Rectangle"));

            root.Add(group);

            root.Add(new SimpleShape("Ellipse"));

            root.Display(1);

            Console.Read();
        }
    }
}
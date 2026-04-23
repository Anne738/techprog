using System;
using System.Collections.Generic;

namespace TextEditorCommand
{
    abstract class Command
    {
        public abstract void Execute();
        public abstract void UnExecute();
    }

    class TextEditor
    {
        public string Text { get; private set; } = "";
        public string Clipboard { get; set; } = "";

        public void Insert(string value)
        {
            Text += value;
            Console.WriteLine("Text: " + Text);
        }

        public void Delete(int length)
        {
            if (length <= Text.Length)
                Text = Text.Substring(0, Text.Length - length);

            Console.WriteLine("Text: " + Text);
        }

        public void Copy(int length)
        {
            if (length <= Text.Length)
                Clipboard = Text.Substring(Text.Length - length);

            Console.WriteLine("Copied: " + Clipboard);
        }
    }

    class InsertCommand : Command
    {
        private TextEditor editor;
        private string text;

        public InsertCommand(TextEditor editor, string text)
        {
            this.editor = editor;
            this.text = text;
        }

        public override void Execute()
        {
            editor.Insert(text);
        }

        public override void UnExecute()
        {
            editor.Delete(text.Length);
        }
    }

    class DeleteCommand : Command
    {
        private TextEditor editor;
        private int length;
        private string deletedText;

        public DeleteCommand(TextEditor editor, int length)
        {
            this.editor = editor;
            this.length = length;
        }

        public override void Execute()
        {
            if (length <= editor.Text.Length)
            {
                deletedText = editor.Text.Substring(editor.Text.Length - length);
                editor.Delete(length);
            }
        }

        public override void UnExecute()
        {
            editor.Insert(deletedText);
        }
    }

    class CopyCommand : Command
    {
        private TextEditor editor;
        private int length;
        private string prevClipboard;

        public CopyCommand(TextEditor editor, int length)
        {
            this.editor = editor;
            this.length = length;
        }

        public override void Execute()
        {
            prevClipboard = editor.Clipboard;
            editor.Copy(length);
        }

        public override void UnExecute()
        {
            editor.Clipboard = prevClipboard;
            Console.WriteLine("\nClipboard restored: " + editor.Clipboard);
        }
    }

    class PasteCommand : Command
    {
        private TextEditor editor;
        private string pastedText;

        public PasteCommand(TextEditor editor)
        {
            this.editor = editor;
        }

        public override void Execute()
        {
            pastedText = editor.Clipboard;
            editor.Insert(pastedText);
        }

        public override void UnExecute()
        {
            editor.Delete(pastedText.Length);
        }
    }

    class User
    {
        private List<Command> commands = new List<Command>();
        private int current = 0;

        public void ExecuteCommand(Command command)
        {
            command.Execute();
            commands.Add(command);
            current++;
        }

        public void Undo(int levels)
        {
            Console.WriteLine("\n--- Undo ---");

            for (int i = 0; i < levels; i++)
            {
                if (current > 0)
                    commands[--current].UnExecute();
            }
        }

        public void Redo(int levels)
        {
            Console.WriteLine("\n--- Redo ---");

            for (int i = 0; i < levels; i++)
            {
                if (current < commands.Count)
                    commands[current++].Execute();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            TextEditor editor = new TextEditor();
            User user = new User();

            user.ExecuteCommand(new InsertCommand(editor, "Anna"));
            user.ExecuteCommand(new InsertCommand(editor, " from MIT"));

            user.ExecuteCommand(new CopyCommand(editor, 3));   
            user.ExecuteCommand(new PasteCommand(editor));     

            user.ExecuteCommand(new DeleteCommand(editor, 6));

            user.Undo(3); 
            user.Redo(2); 

            Console.ReadKey();
        }
    }
}
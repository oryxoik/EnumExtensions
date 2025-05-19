using System;
using System.Linq;
using System.Text;

namespace EnumExtensions.Generator
{
    public class CodeWriter
    {
        /// <summary>
        /// An array of strings representing indentation levels, where each element contains a number of tab characters
        /// corresponding to its index. For example, the element at index 0 is an empty string (no indentation),
        /// the element at index 1 contains one tab character, and so on up to 31 tab characters.
        /// </summary>
        private static readonly string[] _indents = Enumerable.Range(0, 32).Select(i => string.Join("", Enumerable.Repeat("\t", i))).ToArray();

        public readonly StringBuilder StringBuilder;

        private int _currentIndentIndex;

        public CodeWriter()
        {
            StringBuilder = new StringBuilder();
        }

        public CodeWriter(int capacity)
        {
            StringBuilder = new StringBuilder(capacity);
        }

        public int IndentDepth => _currentIndentIndex;
        public string CurrentIndent => _indents[_currentIndentIndex];

        public CodeWriter Indent()
        {
            _currentIndentIndex++;
            return this;
        }

        public CodeWriter Dedent()
        {
            if (_currentIndentIndex > 0) _currentIndentIndex--;
            return this;
        }

        public IDisposable BeginScope(string begin = "{", string end = "}")
        {
            WriteLine(begin);
            Indent();
            return new Scope(this, end);
        }

        public IDisposable BeginScopeIf(bool condition, string begin = "{", string end = "}")
        {
            return condition ? BeginScope(begin, end) : new DummyDisposable();
        }

        public CodeWriter Write(string text)
        {
            StringBuilder.Append(text);
            return this;
        }

        public CodeWriter WriteBeginLine() => Write(CurrentIndent);
        public CodeWriter WriteBeginLine(string text) => WriteBeginLine().Write(text);

        public CodeWriter WriteEndLine()
        {
            StringBuilder.AppendLine();
            return this;
        }

        public CodeWriter WriteEndLine(string text)
        {
            StringBuilder.AppendLine(text);
            return this;
        }

        public CodeWriter WriteLine() => WriteEndLine();
        public CodeWriter WriteLine(string text) => WriteBeginLine().WriteEndLine(text);
        public CodeWriter WriteLineIf(bool condition, string text) => condition ? WriteLine(text) : this;
        public CodeWriter WriteLineIf(bool condition, string trueText, string falseText) => condition ? WriteLine(trueText) : WriteLine(falseText);

        public override string ToString() => StringBuilder.ToString();

        private sealed class Scope : IDisposable
        {
            private readonly CodeWriter _builder;
            private readonly string _end;
            private bool _disposed;

            public Scope(CodeWriter sb, string end)
            {
                _builder = sb;
                _end = end;
            }

            public void Dispose()
            {
                if (_disposed)
                    return;

                _builder.Dedent();
                _builder.WriteLine(_end);
                _disposed = true;
            }
        }

        private sealed class DummyDisposable : IDisposable { public void Dispose() { } }
    }
}
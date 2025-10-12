using Antlr4.Runtime;

namespace Formula
{
    public class FormulaCalculator
    {
        FormulaGrammarParser.CompileUnitContext? Tree { get; set; } = null;

        public void Parse(string expression)
        {
            var lexer = new FormulaGrammarLexer(new AntlrInputStream(expression));
            lexer.RemoveErrorListeners();
            lexer.AddErrorListener(new ThrowExceptionErrorListener());

            var tokens = new CommonTokenStream(lexer);
            var parser = new FormulaGrammarParser(tokens);

            Tree = parser.compileUnit();
        }

        public double Calculate()
        {
            if (Tree == null)
            {
                throw new InvalidOperationException("Execute Parse() at the first");
            }

            var visitor = new FormulaVisitor();
            return visitor.Visit(Tree);
        }
    }
}


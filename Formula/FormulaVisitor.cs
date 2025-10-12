using System.Diagnostics;

namespace Formula
{
    internal class FormulaVisitor : FormulaGrammarBaseVisitor<double>
    {
        internal IFormulaHost? Host { get; init; } = null;

        public override double VisitCompileUnit(FormulaGrammarParser.CompileUnitContext context)
        {
            return Visit(context.expression());
        }

        public override double VisitNumberExpr(FormulaGrammarParser.NumberExprContext context)
        {
            var result = double.Parse(context.GetText());
            Debug.WriteLine(result);

            return result;
        }

        public override double VisitIdentifierExpr(FormulaGrammarParser.IdentifierExprContext context)
        {
            var identifierName = context.GetText();

            if (Host != null)
            {
                return Host.GetIdentifierValue(identifierName);
            }
            else
            {
                return 0.0;
            }
        }

        public override double VisitParenthesizedExpr(FormulaGrammarParser.ParenthesizedExprContext context)
        {
            return Visit(context.expression());
        }

        public override double VisitIncExpr(FormulaGrammarParser.IncExprContext context)
        {
            var right = WalkLeft(context);
            return ++right;
        }

        public override double VisitDecExpr(FormulaGrammarParser.DecExprContext context)
        {
            var right = WalkLeft(context);
            return --right;
        }

        public override double VisitMaxExpr(FormulaGrammarParser.MaxExprContext context)
        {
            var left = WalkLeft(context);
            var right = WalkRight(context);
            return Math.Max(left, right);
        }

        public override double VisitMinExpr(FormulaGrammarParser.MinExprContext context)
        {
            var left = WalkLeft(context);
            var right = WalkRight(context);
            return Math.Min(left, right);
        }

        public override double VisitExponentialExpr(FormulaGrammarParser.ExponentialExprContext context)
        {
            var left = WalkLeft(context);
            var right = WalkRight(context);

            return System.Math.Pow(left, right);
        }

        public override double VisitAdditiveExpr(FormulaGrammarParser.AdditiveExprContext context)
        {
            var left = WalkLeft(context);
            var right = WalkRight(context);

            if (context.operatorToken.Type == FormulaGrammarLexer.ADD)
            {
                return left + right;
            }
            else //FormulaGrammarLexer.SUBTRACT
            {
                return left - right;
            }
        }

        public override double VisitMultiplicativeExpr(FormulaGrammarParser.MultiplicativeExprContext context)
        {
            var left = WalkLeft(context);
            var right = WalkRight(context);

            if (context.operatorToken.Type == FormulaGrammarLexer.MULTIPLY)
            {
                return left * right;
            }
            else //FormulaGrammarLexer.DIVIDE
            {
                return left / right;
            }
        }

        double WalkLeft(FormulaGrammarParser.ExpressionContext context)
        {
            return Visit(context.GetRuleContext<FormulaGrammarParser.ExpressionContext>(0));
        }

        double WalkRight(FormulaGrammarParser.ExpressionContext context)
        {
            return Visit(context.GetRuleContext<FormulaGrammarParser.ExpressionContext>(1));
        }
    }
}


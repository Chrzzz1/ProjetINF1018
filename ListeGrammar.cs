namespace ConsoleApp6;
using System;
using Irony.Parsing;

using Irony.Parsing;
using System;
using Irony.Parsing;
using Irony.Ast;

using System;
using Irony.Parsing;
using Irony.Ast;

using System;
using Irony.Parsing;

using System;
using Irony.Parsing;


    // Définition d'une grammaire simple
    public class ListeGrammar : Grammar
    {
        public ListeGrammar()
        {
            // Définition des terminaux
            var number = new NumberLiteral("Number");
            var identifier = new IdentifierTerminal("Identifier");
            var lParen = ToTerm("(");
            var rParen = ToTerm(")");
        
            // Non-terminaux
            var expr = new NonTerminal("Expr");
            var exprList = new NonTerminal("ExprList");

            // Règles
            expr.Rule = number | identifier | lParen + exprList + rParen;
            exprList.Rule = MakeStarRule(exprList, expr);

            // Définir la racine
            this.Root = expr;

            // Configurations supplémentaires
            MarkPunctuation("(", ")");
            RegisterBracePair("(", ")");
        }
    }

    
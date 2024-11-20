using Irony.Parsing;
using System;
using System.Collections.Generic;

namespace ConsoleApp6
{
    public class TokenParser
    {
        private readonly IList<Token> listTokens;
        private int position = 0;

        public TokenParser(IList<Token> listTokens)
        {
            this.listTokens = listTokens;
        }

        private ASTNode ParseExpression()
        {
            if (position >= listTokens.Count)
                throw new Exception("Unexpected end of input.");

            var token = listTokens[position];

            // Si le token est une parenthèse ouvrante, nous avons une liste
            if (token.Terminal.Name == "(")
            {
                position++; // Consommer la parenthèse ouvrante
                return ParseList();
            }
            else
            {
                throw new Exception($"Unexpected token: {token.Text}");
            }
        }

        // Analyse une liste (expression entre parenthèses)
        private ASTNode ParseList()
        {
            var token = listTokens[position];

            if (token.Terminal.Name == ")")
                throw new Exception("Unexpected closing parenthesis, missing operator or operands");

            // Le premier élément de la liste doit être un opérateur
            if (token.Terminal.Name != "Identifier")
                throw new Exception("Expected operator in list");

            string operatorName = token.Text;
            position++; // Consommer l'opérateur

            // Créer un nœud pour l'opérateur
            ASTNode operatorNode = operatorName switch
            {
                "+" => new AdditionNode(),
                "-" => new SubtractionNode(),
                "*" => new MultiplicationNode(),
                "/" => new DivisionNode(),
                _ => throw new Exception($"Unsupported operator: {operatorName}")
            };

            var leftOperand = ParseExpression(); // Analyser le premier opérande
            var rightOperand = ParseExpression(); // Analyser le deuxième opérande

            // Associer les opérandes au nœud de l'opérateur
            if (operatorNode is AdditionNode additionNode)
            {
                additionNode.Left = leftOperand;
                additionNode.Right = rightOperand;
            }

            // Gérer d'autres opérateurs ici (par exemple SubtractionNode, etc.)
            // Nous pouvons ajouter de la logique pour d'autres types d'opérateurs si nécessaire.

            // Attendre une parenthèse fermante
            token = listTokens[position];
            if (token.Terminal.Name != ")")
                throw new Exception("Expected closing parenthesis ')'");
            position++; // Consommer la parenthèse fermante

            return operatorNode;
        }
    }
    }
}
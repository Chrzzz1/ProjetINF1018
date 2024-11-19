using ConsoleApp6;
using Irony.Parsing;
using System;
using Irony.Parsing;

using System;
using Irony.Parsing;

using System;
using Irony.Parsing;

using System;
using Irony.Parsing;

public class Program
{
    public static void Main()
    {
        // Code source à analyser
        var source = "( define x 42 )";

        // Création de la grammaire
        var grammar = new ListeGrammar();

        // Création du parseur
        var parser = new Parser(grammar);

        // Analyse du code source
        var parseTree = parser.Parse(source);
        var tokenParser = new TokenParser(parseTree.Tokens);
        var astRoot = TokenParser.Parse();

// Parcourir et afficher l'AST
        ProcessAst(astRoot);


        // Vérification des erreurs d'analyse
        if (parseTree.HasErrors())
        {
            Console.WriteLine("Erreurs d'analyse :");
            foreach (var error in parseTree.ParserMessages)
            {
                Console.WriteLine(error.Message);
            }
        }
        else
        {
            // Affichage de la liste des tokens
            DisplayTokens(parseTree);
        }
        TokenParser
    }
    public static void ProcessAst(AstNode node, string indent = "")
    {
        switch (node)
        {
            case IdentNode identNode:
                Console.WriteLine($"{indent}Ident : {identNode.Name}");
                break;

            case EntierNode entierNode:
                Console.WriteLine($"{indent}Entier : {entierNode.Value}");
                break;

            case ListeNode listeNode:
                Console.WriteLine($"{indent}Liste :");
                foreach (var element in listeNode.Elements)
                {
                    ProcessAst(element, indent + "  ");
                }
                break;

            default:
                Console.WriteLine($"{indent}Nœud inconnu");
                break;
        }
    }

    public static void DisplayTokens(ParseTree parseTree)
    {
        var tokens = parseTree.Tokens;

        Console.WriteLine("Liste des tokens :");
        foreach (var token in tokens)
        {
            Console.WriteLine($"Token : '{token.Text}'");
            Console.WriteLine($"  Type      : {token.Terminal.Name}");
            Console.WriteLine($"  Position  : Ligne {token.Location.Line}, Colonne {token.Location.Column}");
            Console.WriteLine($"  Index     : {token.Location.Position}");
            Console.WriteLine();
        }
    }
}



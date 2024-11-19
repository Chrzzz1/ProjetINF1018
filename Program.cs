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



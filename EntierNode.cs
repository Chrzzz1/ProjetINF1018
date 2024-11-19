using Irony.Ast;
using Irony.Parsing;

namespace ConsoleApp6;
using Irony.Parsing;
using System.Collections.Generic;
using System.Linq;
public class EntierNode : IAstNodeInit
{
    public int Value { get; private set; }

    // Implémentation de la méthode Init
    public void Init(AstContext context, ParseTreeNode parseNode)
    {
        // Initialisation du nœud AST à partir du parseNode
        var text = string.Concat(GetAllTokensText(parseNode));
        Value = int.Parse(text);
    }

    private IEnumerable<string> GetAllTokensText(ParseTreeNode node)
    {
        if (node == null)
            yield break;

        if (node.Token != null)
        {
            yield return node.Token.Text;
        }
        else if (node.ChildNodes != null)
        {
            foreach (var child in node.ChildNodes)
            {
                if (child != null)
                {
                    foreach (var text in GetAllTokensText(child))
                    {
                        yield return text;
                    }
                }
            }
        }
    }
}
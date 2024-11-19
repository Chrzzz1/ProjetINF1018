using Irony.Ast;
using Irony.Parsing;

namespace ConsoleApp6;
using Irony.Parsing;
using System.Collections.Generic;
using System.Linq;
using Irony.Parsing;
using System.Collections.Generic;

public class IdentNode : IAstNodeInit
{
    public string Name { get; private set; }

    // Implémentation de la méthode Init
    public void Init(AstContext context, ParseTreeNode parseNode)
    {
       
        // Initialisation du nœud AST à partir du parseNode
        Name = string.Concat(GetAllTokensText(parseNode));
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


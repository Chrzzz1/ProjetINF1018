using Irony.Ast;
using Irony.Parsing;

namespace ConsoleApp6;
using Irony.Parsing;
using System.Collections.Generic;
using System.Linq;

public class ChaineNode : IAstNodeInit
{
    public string Text { get; private set; }

    public void Init(AstContext context, ParseTreeNode treeNode)
    {
        var text = string.Concat(GetAllTokensText(treeNode));
        Text = text.Trim('"');
    }

    private IEnumerable<string> GetAllTokensText(ParseTreeNode node)
    {
        if (node.Token != null)
        {
            yield return node.Token.Text;
        }
        else
        {
            foreach (var child in node.ChildNodes)
            {
                foreach (var text in GetAllTokensText(child))
                {
                    yield return text;
                }
            }
        }
    }
}

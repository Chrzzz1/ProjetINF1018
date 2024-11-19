using Irony.Ast;
using Irony.Parsing;

namespace ConsoleApp6;
using Irony.Parsing;
using System.Collections.Generic;
using Irony.Parsing;
using System.Collections.Generic;

public class ListeNode : IAstNodeInit
{
    public List<object> Elements { get; private set; }

    // Implémentation de la méthode Init
    public void Init(AstContext context, ParseTreeNode parseNode)
    {
        Elements = new List<object>();

        if (parseNode?.ChildNodes == null)
            return;

        // Vérification que le nœud a le nombre d'enfants attendu
        if (parseNode.ChildNodes.Count >= 2)
        {
            // Le deuxième enfant est la liste des expressions
            var sexprListNode = parseNode.ChildNodes[1];

            if (sexprListNode?.ChildNodes != null)
            {
                foreach (var child in sexprListNode.ChildNodes)
                {
                    if (child?.AstNode != null)
                    {
                        Elements.Add(child.AstNode);
                    }
                }
            }
        }
    }
}



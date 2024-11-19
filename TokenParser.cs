using Irony.Parsing;

namespace ConsoleApp6;

public class TokenParser
{
    private readonly IList<Token> listTokens;
    private int position = 0;

    public TokenParser(IList<Token> listTokens)
    {
        this.listTokens = listTokens;
    }

    private ASTNode parse()
    {
        return parseExpression();
    }

    private ASTNode parseExpression()
    {
        if (position >= listTokens.Count)
            throw new Exception("parenthese fermante");

        var token = listTokens[position];

        switch (token.Terminal.Name)
        {
            case "Number":
                position++;
                return new EntierNode() { Value = int.Parse(token.Text) };
            case "Identifier":
                position++;
                return new IdentNode() { Name = token.Text };
            case "(":
                var listNode = new ListeNode() { Elements = new List<ASTNode>() };
                while (position >= listTokens.Count && token.Terminal.Name != ")")
                {
                    var element = parse();
                    listNode.Elements.Add(element);

                }

                if (position >= listTokens.Count || token.Terminal.Name != ")")
                    throw new Exception("parenthese fermante"); 
                position++;
                return listNode;
            default:
                throw new Exception("token pas reconnue");


        }

    }


}
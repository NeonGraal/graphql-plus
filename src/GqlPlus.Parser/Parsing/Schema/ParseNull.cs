using GqlPlus.Ast;
using GqlPlus.Parsing.Schema.Simple;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema;

internal class ParseNulls : Parser<NullAst>.IA
{
  public IResultArray<NullAst> Parse(ITokenizer tokens, string label)

    => 0.EmptyArray<NullAst>();
}

internal enum NullOption { }

internal class ParseNullOption : IEnumParser<NullOption>, IOptionParser<NullOption>
{
  public IResult<NullOption> Parse(ITokenizer tokens, string label)

    => 0.Empty<NullOption>();
}

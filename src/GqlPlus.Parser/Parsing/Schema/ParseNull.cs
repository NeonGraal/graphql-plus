using GqlPlus.Parsing.Schema.Simple;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema;

internal class ParseNulls : Parser<NullAst>.IA
{
  public IResultArray<NullAst> Parse(ITokenizer tokens, string label)

    => 0.EmptyArray<NullAst>();

  internal static ParseNulls Factory(IParserRepository _) => new();
}

internal enum NullOption { }

internal class ParseNullOption : IEnumParser<NullOption>, IOptionParser<NullOption>
{
  public IResult<NullOption> Parse(ITokenizer tokens, string label)

    => default(NullOption).Empty();

  internal static ParseNullOption Factory(IParserRepository _) => new();
}

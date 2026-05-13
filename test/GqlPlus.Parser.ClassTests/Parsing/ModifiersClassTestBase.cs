namespace GqlPlus.Parsing;

public class ModifiersClassTestBase
  : ParserClassTestBase
{
  private readonly IParserArray<IAstModifier> _modifiers;

  protected IParserRepository Parsers { get; }

  public ModifiersClassTestBase()
    : this(A.Of<ITokenizer>())
  { }

  public ModifiersClassTestBase(ITokenizer tokenizer)
    : base(tokenizer)
  {
    Parsers = A.Of<IParserRepository>();

    _modifiers = A.Of<IParserArray<IAstModifier>, IParserCollections>();
    _modifiers.Parse(default!, default!)
      .ReturnsForAnyArgs(0.EmptyArray<IAstModifier>());

    Parsers.ArrayFor<IAstModifier>().ReturnsForAnyArgs(() => _modifiers);

    Parsers.ArrayFor<IParserCollections, IAstModifier>().ReturnsForAnyArgs(() => (IParserCollections)_modifiers);
  }

  internal IAstModifier[] ParseAModifier()
  {
    IAstModifier result = AtFor<IAstModifier>();
    ParseModifiersOk(result);
    return [result];
  }

  internal void ParseModifiersOk(params IAstModifier[] modifiers)
    => ParseOkA(_modifiers, modifiers);
  internal void ParseModifiersEmpty()
    => ParseEmptyA(_modifiers);
  internal void ParseModifiersError()
    => ParseErrorA(_modifiers);
}

namespace GqlPlus.Parsing;

public class ModifiersClassTestBase
  : ParserClassTestBase
{
  private readonly Parser<IAstModifier>.IA _modifiers;

  protected IParserRepository Parsers { get; }

  public ModifiersClassTestBase()
    : this(A.Of<ITokenizer>())
  { }

  public ModifiersClassTestBase(ITokenizer tokenizer)
    : base(tokenizer)
  {
    Parsers = A.Of<IParserRepository>();

    _modifiers = A.Of<Parser<IAstModifier>.IA, IParserCollections>();
    _modifiers.Parse(default!, default!)
      .ReturnsForAnyArgs(0.EmptyArray<IAstModifier>());

    Parser<IAstModifier>.LA modifiersLazy = new(() => _modifiers);
    Parsers.ArrayFor<IAstModifier>().Returns(modifiersLazy);

    ParserArray<IParserCollections, IAstModifier>.LA collectionsLazy = new(() => (IParserCollections)_modifiers);
    Parsers.ArrayFor<IParserCollections, IAstModifier>().Returns(collectionsLazy);
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

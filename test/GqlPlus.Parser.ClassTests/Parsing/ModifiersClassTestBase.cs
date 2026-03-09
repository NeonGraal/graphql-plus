namespace GqlPlus.Parsing;

public class ModifiersClassTestBase
  : ParserClassTestBase
{
  private readonly Parser<IGqlpModifier>.IA _modifiers;

  protected IParserRepository Parsers { get; }

  public ModifiersClassTestBase()
    : this(A.Of<ITokenizer>())
  { }

  public ModifiersClassTestBase(ITokenizer tokenizer)
    : base(tokenizer)
  {
    Parsers = A.Of<IParserRepository>();

    _modifiers = A.Of<Parser<IGqlpModifier>.IA, IParserCollections>();
    _modifiers.Parse(default!, default!)
      .ReturnsForAnyArgs(0.EmptyArray<IGqlpModifier>());

    Parser<IGqlpModifier>.LA modifiersLazy = new(() => _modifiers);
    Parsers.ArrayFor<IGqlpModifier>().Returns(modifiersLazy);

    ParserArray<IParserCollections, IGqlpModifier>.LA collectionsLazy = new(() => (IParserCollections)_modifiers);
    Parsers.ArrayFor<IParserCollections, IGqlpModifier>().Returns(collectionsLazy);
  }

  internal IGqlpModifier[] ParseAModifier()
  {
    IGqlpModifier result = AtFor<IGqlpModifier>();
    ParseModifiersOk(result);
    return [result];
  }

  internal void ParseModifiersOk(params IGqlpModifier[] modifiers)
    => ParseOkA(_modifiers, modifiers);
  internal void ParseModifiersEmpty()
    => ParseEmptyA(_modifiers);
  internal void ParseModifiersError()
    => ParseErrorA(_modifiers);
}

﻿namespace GqlPlus.Parsing;

public class ModifiersClassTestBase
  : ParserClassTestBase
{
  private readonly Parser<IGqlpModifier>.IA _modifiers;

  internal ParserArray<IParserCollections, IGqlpModifier>.DA Collections { get; }
  internal Parser<IGqlpModifier>.DA Modifiers { get; }

  public ModifiersClassTestBase()
    : this(A.Of<ITokenizer>())
  { }

  public ModifiersClassTestBase(ITokenizer tokenizer)
    : base(tokenizer)
  {
    _modifiers = A.Of<Parser<IGqlpModifier>.IA, IParserCollections>();
    _modifiers.Parse(default!, default!)
      .ReturnsForAnyArgs(0.EmptyArray<IGqlpModifier>());

    Modifiers = A.Of<Parser<IGqlpModifier>.DA>();
    Modifiers().Returns(_modifiers);

    Collections = A.Of<ParserArray<IParserCollections, IGqlpModifier>.DA>();
    Collections().Returns(_modifiers);
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

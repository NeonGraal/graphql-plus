﻿using System.Diagnostics.CodeAnalysis;
using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Parsing.Schema;

public class DeclarationClassTestBase
  : ParserClassTestBase
{
  private readonly Parser<NullAst>.IA _nullParam;
  private readonly Parser<string>.IA _aliases;
  private readonly Parser<NullOption>.I _option;

  internal INameParser NameParser { get; set; }
  internal ISimpleName SimpleName { get; }

  internal Parser<NullAst>.DA ParamNull { get; }
  internal Parser<string>.DA Aliases { get; }
  internal Parser<IOptionParser<NullOption>, NullOption>.D OptionNull { get; }

  public DeclarationClassTestBase()
  {
    SimpleName = For<ISimpleName>();
    NameParser = SimpleName;

    ParamNull = ParserAFor(out _nullParam);
    OptionNull = OptionParserFor(out _option);
    Aliases = ParserAFor(out _aliases);

    TakeReturns('{', true);
  }

  internal void NameFails()
    => NameParser.ParseName(default!, out string? _, out TokenAt _).ReturnsForAnyArgs(OutFailAt());

  internal void NameReturns(string? name)
    => NameParser.ParseName(default!, out string? _, out TokenAt _).ReturnsForAnyArgs(OutStringAt(name));

  public void Check_ShouldReturnError_WhenNoName<T>([NotNull] Parser<T>.I parser)
    where T : class, IGqlpError
  {
    // Arrange
    NameFails();
    SetupError<T>();

    // Act
    IResult<T> result = parser.Parse(Tokenizer, "testLabel");

    // Assert
    result.ShouldBeAssignableTo<IResultError>();
  }
}

using System.Diagnostics.CodeAnalysis;

namespace GqlPlus.Parsing.Schema;

public class DeclarationClassTestBase
  : AliasesClassTestBase
{
  private readonly Parser<NullAst>.IA _nullParam;
  private readonly IOptionParser<NullOption> _option;

  internal INameParser NameParser { get; set; }
  internal ISimpleName SimpleName { get; }

  public DeclarationClassTestBase()
  {
    SimpleName = A.Of<ISimpleName>();
    NameParser = SimpleName;

    _nullParam = A.Of<Parser<NullAst>.IA>();
    _nullParam.Parse(default!, default!)
      .ReturnsForAnyArgs(0.EmptyArray<NullAst>());
    Parser<NullAst>.LA nullParamLazy = new(() => _nullParam);
    Parsers.ArrayFor<NullAst>().Returns(nullParamLazy);

    _option = A.Of<IOptionParser<NullOption>>();
    _option.Parse(default!, default!)
      .ReturnsForAnyArgs(default(NullOption).Empty());
    Parser<IOptionParser<NullOption>, NullOption>.L optionLazy = new(() => _option);
    Parsers.ParserFor<IOptionParser<NullOption>, NullOption>().Returns(optionLazy);

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

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
    Parsers.GetName<ISimpleName>().ReturnsForAnyArgs(() => SimpleName);

    _nullParam = A.Of<Parser<NullAst>.IA>();
    _nullParam.Parse(default!, default!)
      .ReturnsForAnyArgs(0.EmptyArray<NullAst>());
    Parsers.ArrayFor<NullAst>().ReturnsForAnyArgs(() => _nullParam);

    _option = A.Of<IOptionParser<NullOption>>();
    _option.Parse(default!, default!)
      .ReturnsForAnyArgs(default(NullOption).Empty());
    Parsers.ParserFor<IOptionParser<NullOption>, NullOption>().ReturnsForAnyArgs(() => _option);

    TakeReturns('{', true);
  }

  internal void NameFails()
    => NameParser.ParseName(default!, out string? _, out TokenAt _).ReturnsForAnyArgs(OutFailAt());

  internal void NameReturns(string? name)
    => NameParser.ParseName(default!, out string? _, out TokenAt _).ReturnsForAnyArgs(OutStringAt(name));

  public void Check_ShouldReturnError_WhenNoName<T>([NotNull] Parser<T>.I parser)
    where T : class, IAstError
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

using System.Diagnostics.CodeAnalysis;

namespace GqlPlus.Parsing.Schema;

public class DeclarationClassTestBase
  : AliasesClassTestBase
{
  private readonly Parser<NullAst>.IA _nullParam;
  private readonly Parser<NullOption>.I _option;

  internal INameParser NameParser { get; set; }
  internal ISimpleName SimpleName { get; }

  internal Parser<NullAst>.DA ParamNull { get; }
  internal Parser<IOptionParser<NullOption>, NullOption>.D OptionNull { get; }

  public DeclarationClassTestBase()
  {
    SimpleName = A.Of<ISimpleName>();
    NameParser = SimpleName;

    ParamNull = ParserAFor(out _nullParam);
    OptionNull = OptionParserFor(out _option);

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

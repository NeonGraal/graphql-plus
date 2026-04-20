using GqlPlus.Ast.Operation;

namespace GqlPlus.Parsing.Operation;

public class OperationContextTests
  : ParserClassTestBase
{
  private readonly ITokenizer _tokenizer;
  private readonly OperationContext _context;

  public OperationContextTests()
  {
    _tokenizer = A.Of<ITokenizer>();

    _context = new OperationContext(_tokenizer);
  }

  [Theory, RepeatData]
  public void AddVariable_Recorded(string variable)
  {
    // Arrange
    IAstArg arg = AtFor<IAstArg>();
    arg.Equals(Arg.Any<IAstArg>()).Returns(c => c[0] == arg);
    arg.Variable.Returns(variable);

    // Act
    _context.AddVariable(arg);

    // Assert
    _context.Variables.ShouldContain(arg);
  }

  [Theory, RepeatData]
  public void AddSpread_Recorded(string name)
  {
    // Arrange
    IAstSpread spread = AtFor<IAstSpread>();
    spread.Identifier.Returns(name);

    // Act
    _context.AddSpread(spread);

    // Assert
    _context.Spreads.ShouldContain(spread);
  }
}

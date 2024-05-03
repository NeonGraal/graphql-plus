using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema;
using GqlPlus.Token;
using GqlPlus.Verification;
using Xunit.DependencyInjection;

namespace GqlPlus;

public class BuiltInTests(
  IVerify<IGqlpSchema> verifier
)
{
  [Fact]
  public Task VerifyBasicTypes()
    => Verify(BuiltIn.Basic.AsString());

  [Fact]
  public Task VerifyInternalTypes()
    => Verify(BuiltIn.Internal.AsString());

  [SkippableTheory]
  [MethodData("AllBasic", typeof(BuiltIn))]
  public void ValidBasicTypes(AstType type)
    => Verify_Valid(type);

  [SkippableTheory]
  [MethodData("AllInternal", typeof(BuiltIn))]
  public void ValidInternalTypes(AstType type)
    => Verify_Valid(type);

  private void Verify_Valid(AstType type)
  {
    Skip.If(type is null);

    TokenMessages result = [];
    SchemaAst schema = new(AstNulls.At) {
      Declarations = [type]
    };

    verifier.Verify(schema, result);

    result.Should().BeNullOrEmpty(type?.Label);
  }
}

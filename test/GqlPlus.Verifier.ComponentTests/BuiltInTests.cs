using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;
using GqlPlus.Verifier.Verification;
using Xunit.DependencyInjection;

namespace GqlPlus.Verifier;

public class BuiltInTests(
  IVerify<SchemaAst> verifier
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

    var result = new TokenMessages();
    var schema = new SchemaAst(AstNulls.At) {
      Declarations = [type]
    };

    verifier.Verify(schema, result);

    result.Should().BeNullOrEmpty(type?.Label);
  }
}

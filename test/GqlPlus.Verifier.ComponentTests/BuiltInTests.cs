using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema;
using GqlPlus.Token;
using GqlPlus.Verifying;

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
  [ClassData(typeof(BuiltInBasicData))]
  public void ValidBasicTypes(string type)
    => Verify_Valid(BuiltInData.BasicMap[type]);

  [SkippableTheory]
  [ClassData(typeof(BuiltInInternalData))]

  public void ValidInternalTypes(string type)
    => Verify_Valid(BuiltInData.InternalMap[type]);

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

namespace GqlPlus.Verifier;

[UsesVerify]
public class BuiltInTests
{
  [Fact]
  public Task VerifyBasicTypes()
    => Verify(BuiltIn.Basic.AsString());

  [Fact]
  public Task VerifyInternalTypes()
    => Verify(BuiltIn.Internal.AsString());
}

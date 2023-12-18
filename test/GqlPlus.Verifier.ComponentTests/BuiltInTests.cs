namespace GqlPlus.Verifier;

[UsesVerify]
public class BuiltInTests
{
  [Fact]
  public async Task VerifyBasicTypes()
  {
    await Verify(BuiltIn.Basic.AsString());
  }

  [Fact]
  public async Task VerifyInternalTypes()
  {
    await Verify(BuiltIn.Internal.AsString());
  }
}

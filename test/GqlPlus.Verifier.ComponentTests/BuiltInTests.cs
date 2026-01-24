using GqlPlus.Abstractions;
using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;
using GqlPlus.Verifying;

namespace GqlPlus;

public class BuiltInTests(
  IVerify<IGqlpSchema> verifier
)
{
  private readonly VerifySettings _settings = new VerifySettings().CheckAutoVerify();

  [Fact]
  public Task VerifyBasicTypes_WhenCalled_ReturnsExpectedSnapshot()
    => Verify(BuiltIn.Basic.AsString(), _settings);

  [Fact]
  public Task VerifyInternalTypes_WhenCalled_ReturnsExpectedSnapshot()
    => Verify(BuiltIn.Internal.AsString(), _settings);

  [Theory]
  [ClassData(typeof(BuiltInBasicData))]
  public void ValidBasicTypes_GivenType_VerifiesSuccessfully(string type)
    => Verify_Valid(BuiltInData.BasicMap[type]);

  [Theory]
  [ClassData(typeof(BuiltInInternalData))]
  public void ValidInternalTypes_GivenType_VerifiesSuccessfully(string type)
    => this
      .SkipIf(type == "Void")
      .Verify_Valid(BuiltInData.InternalMap[type]);

  private void Verify_Valid(IGqlpType type)
  {
    Assert.SkipWhen(type is null, "type is null");

    Messages result = [];
    TestSchema schema = new(type);

    verifier.Verify(schema, result);

    result.ShouldBeEmpty(type?.Label);
  }

  private sealed class TestSchema(
    IGqlpType type
  ) : IGqlpSchema
  {
    public IEnumerable<IGqlpDeclaration> Declarations { get; } = [type];
    public ParseResultKind Result { get; } = ParseResultKind.Success;
    public IMessages Errors { get; } = new Messages();
    public ITokenAt At { get; } = new TokenAt(TokenKind.Start, 0, 0, string.Empty);
    public string Abbr { get; } = "testSchema";

    public bool Equals(IGqlpAbbreviated? other) => false;
    public bool Equals(IGqlpSchema? other) => false;
    public IEnumerable<string?> GetFields() => throw new NotImplementedException();
    public IMessages MakeError(string message) => throw new NotImplementedException();
  }
}

namespace GqlPlus.Sample;

[Trait("Generate", "Plain")]
public class PlainSchemaTests(ComponentFixture<SchemaCodecTestServices> fixture)
  : TestSchemaVerify(fixture.GetService<ISchemaVerifyChecks>()), IClassFixture<ComponentFixture<SchemaCodecTestServices>>
{
  public override string ResultGroup => "Plain";
  protected override Task CheckResultErrors(string[] dirs, string test, IMessages errors)
    => CheckErrors(dirs, test, errors);
  protected override Task VerifyResult(string target, VerifySettings settings)
    => Verify(target, settings);
  public override string EncodeResult(Structured result, string section)
    => result.ToPlain(true).Joined(Environment.NewLine);
}

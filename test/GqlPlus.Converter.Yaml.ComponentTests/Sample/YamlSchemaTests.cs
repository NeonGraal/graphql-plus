using GqlPlus.Convert;

namespace GqlPlus.Sample;

[Trait("Generate", "Yaml")]
public class YamlSchemaTests(ComponentFixture<Startup> fixture)
  : TestSchemaVerify(fixture.GetService<ISchemaVerifyChecks>()), IClassFixture<ComponentFixture<Startup>>
{
  public override string ResultGroup => "Yaml";
  public override string EncodeResult(Structured result, string section)
    => result.ToYaml(string.IsNullOrWhiteSpace(section));
  protected override Task VerifyResult(string target, VerifySettings settings)
    => Verify(target, settings);
}

namespace GqlPlus;

public class CodecDiTests(ComponentFixture<SchemaCodecTestServices> fixture)
  : DiChecks(fixture.ServiceCollection), IClassFixture<ComponentFixture<SchemaCodecTestServices>>
{
  protected override string Label => "Codec";
}

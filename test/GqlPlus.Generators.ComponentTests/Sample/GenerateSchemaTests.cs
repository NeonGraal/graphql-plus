namespace GqlPlus.Sample;

public class GenerateSchemaStaticTests(ComponentFixture<Startup> fixture)
  : GenerateSchemaTestBase(fixture.GetService<ISchemaGeneratorChecks>()), IClassFixture<ComponentFixture<Startup>>
{
  public override GqlpBaseType BaseType => GqlpBaseType.Other;
  public override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Static;
}

public class GenerateSchemaIntfTests(ComponentFixture<Startup> fixture)
  : GenerateSchemaTestBase(fixture.GetService<ISchemaGeneratorChecks>()), IClassFixture<ComponentFixture<Startup>>
{
  public override GqlpBaseType BaseType => GqlpBaseType.Interface;
  public override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Interface;
}

public class GenerateSchemaModelTests(ComponentFixture<Startup> fixture)
  : GenerateSchemaTestBase(fixture.GetService<ISchemaGeneratorChecks>()), IClassFixture<ComponentFixture<Startup>>
{
  public override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Model;
}

public class GenerateSchemaDecTests(ComponentFixture<Startup> fixture)
  : GenerateSchemaTestBase(fixture.GetService<ISchemaGeneratorChecks>()), IClassFixture<ComponentFixture<Startup>>
{
  public override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Decoder;
}

public class GenerateSchemaEncTests(ComponentFixture<Startup> fixture)
  : GenerateSchemaTestBase(fixture.GetService<ISchemaGeneratorChecks>()), IClassFixture<ComponentFixture<Startup>>
{
  public override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Encoder;
}

public class GenerateSchemaTestTests(ComponentFixture<Startup> fixture)
  : GenerateSchemaTestBase(fixture.GetService<ISchemaGeneratorChecks>()), IClassFixture<ComponentFixture<Startup>>
{
  public override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Test;
}

namespace GqlPlus.Sample;

public class GenerateSchemaStaticTests(ComponentFixture<GeneratorTestServices> fixture)
  : GenerateSchemaTestBase(fixture.GetService<ISchemaGeneratorChecks>()), IClassFixture<ComponentFixture<GeneratorTestServices>>
{
  public override GqlpBaseType BaseType => GqlpBaseType.Other;
  public override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Static;
}

public class GenerateSchemaIntfTests(ComponentFixture<GeneratorTestServices> fixture)
  : GenerateSchemaTestBase(fixture.GetService<ISchemaGeneratorChecks>()), IClassFixture<ComponentFixture<GeneratorTestServices>>
{
  public override GqlpBaseType BaseType => GqlpBaseType.Interface;
  public override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Interface;
}

public class GenerateSchemaModelTests(ComponentFixture<GeneratorTestServices> fixture)
  : GenerateSchemaTestBase(fixture.GetService<ISchemaGeneratorChecks>()), IClassFixture<ComponentFixture<GeneratorTestServices>>
{
  public override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Model;
}

public class GenerateSchemaDecTests(ComponentFixture<GeneratorTestServices> fixture)
  : GenerateSchemaTestBase(fixture.GetService<ISchemaGeneratorChecks>()), IClassFixture<ComponentFixture<GeneratorTestServices>>
{
  public override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Decoder;
}

public class GenerateSchemaEncTests(ComponentFixture<GeneratorTestServices> fixture)
  : GenerateSchemaTestBase(fixture.GetService<ISchemaGeneratorChecks>()), IClassFixture<ComponentFixture<GeneratorTestServices>>
{
  public override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Encoder;
}

public class GenerateSchemaTestTests(ComponentFixture<GeneratorTestServices> fixture)
  : GenerateSchemaTestBase(fixture.GetService<ISchemaGeneratorChecks>()), IClassFixture<ComponentFixture<GeneratorTestServices>>
{
  public override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Test;
}

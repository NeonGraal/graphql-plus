namespace GqlPlus.Sample;

public class GenerateSchemaStaticTests(
  ISchemaGeneratorChecks checks
) : GenerateSchemaTestBase(checks)
{
  public override GqlpBaseType BaseType => GqlpBaseType.Other;
  public override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Static;
}

public class GenerateSchemaIntfTests(
  ISchemaGeneratorChecks checks
) : GenerateSchemaTestBase(checks)
{
  public override GqlpBaseType BaseType => GqlpBaseType.Interface;
  public override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Interface;
}

public class GenerateSchemaModelTests(
  ISchemaGeneratorChecks checks
) : GenerateSchemaTestBase(checks)
{
  public override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Model;
}

public class GenerateSchemaDecTests(
  ISchemaGeneratorChecks checks
) : GenerateSchemaTestBase(checks)
{
  public override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Decoder;
}

public class GenerateSchemaEncTests(
  ISchemaGeneratorChecks checks
) : GenerateSchemaTestBase(checks)
{
  public override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Encoder;
}

public class GenerateSchemaTestTests(
  ISchemaGeneratorChecks checks
) : GenerateSchemaTestBase(checks)
{
  public override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Test;
}

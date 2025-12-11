using Microsoft.Extensions.Logging;

namespace GqlPlus.Sample;

public class GenerateSchemaStatTests(
  ISchemaGeneratorChecks checks
) : GenerateSchemaTestBase(checks)
{
  public override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Static;
}

public class GenerateSchemaIntfTests(
  ISchemaGeneratorChecks checks
) : GenerateSchemaTestBase(checks)
{
  public override GqlpBaseType BaseType => GqlpBaseType.Interface;
  public override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Interface;
}

public class GenerateSchemaEnumTests(
  ISchemaGeneratorChecks checks
) : GenerateSchemaTestBase(checks)
{
  public override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Enum;
}

public class GenerateSchemaImplTests(
  ISchemaGeneratorChecks checks
) : GenerateSchemaTestBase(checks)
{
  public override GqlpBaseType BaseType => GqlpBaseType.Class;
  public override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Implementation;
}

public class GenerateSchemaTestTests(
  ISchemaGeneratorChecks checks
) : GenerateSchemaTestBase(checks)
{
  public override GqlpBaseType BaseType => GqlpBaseType.Class;
  public override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Test;
}

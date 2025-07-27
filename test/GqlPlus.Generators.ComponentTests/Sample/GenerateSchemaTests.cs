using Microsoft.Extensions.Logging;

namespace GqlPlus.Sample;

public class GenerateSchemaStatTests(
  ILoggerFactory logger,
  ISchemaGeneratorChecks checks
) : GenerateSchemaTestBase(logger, checks)
{
  public override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Static;
}

public class GenerateSchemaIntfTests(
  ILoggerFactory logger,
  ISchemaGeneratorChecks checks
) : GenerateSchemaTestBase(logger, checks)
{
  public override GqlpBaseType BaseType => GqlpBaseType.Interface;
  public override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Interface;
}

public class GenerateSchemaEnumTests(
  ILoggerFactory logger,
  ISchemaGeneratorChecks checks
) : GenerateSchemaTestBase(logger, checks)
{
  public override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Enum;
}

public class GenerateSchemaImplTests(
  ILoggerFactory logger,
  ISchemaGeneratorChecks checks
) : GenerateSchemaTestBase(logger, checks)
{
  public override GqlpBaseType BaseType => GqlpBaseType.Class;
  public override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Implementation;
}

public class GenerateSchemaTestTests(
  ILoggerFactory logger,
  ISchemaGeneratorChecks checks
) : GenerateSchemaTestBase(logger, checks)
{
  public override GqlpBaseType BaseType => GqlpBaseType.Class;
  public override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Test;
}

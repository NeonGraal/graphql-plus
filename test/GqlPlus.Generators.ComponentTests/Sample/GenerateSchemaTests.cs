namespace GqlPlus.Sample;

public class GenerateSchemaStaticTests(
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

public class GenerateSchemaModelTests(
  ISchemaGeneratorChecks checks
) : GenerateSchemaTestBase(checks)
{
  public override GqlpBaseType BaseType => GqlpBaseType.Class;
  public override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Model;
}

public class GenerateSchemaTestTests(
  ISchemaGeneratorChecks checks
) : GenerateSchemaTestBase(checks)
{
  public override GqlpBaseType BaseType => GqlpBaseType.Class;
  public override GqlpGeneratorType GeneratorType => GqlpGeneratorType.Test;
}

//HintName: Model_field-dual+Dual.gen.cs
// Generated from field-dual+Dual.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_field_dual_Dual;

public interface IFieldDualDual
{
  FldFieldDualDual field { get; }
}
public class DualFieldDualDual
  : IFieldDualDual
{
  public FldFieldDualDual field { get; set; }
}

public interface IFldFieldDualDual
{
  Number field { get; }
  String AsString { get; }
}
public class DualFldFieldDualDual
  : IFldFieldDualDual
{
  public Number field { get; set; }
  public String AsString { get; set; }
}

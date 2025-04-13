//HintName: Model_field-dual+dual.gen.cs
// Generated from field-dual+dual.graphql+

/*
*/

namespace GqlTest.Model_field_dual_dual;

public interface IDualFieldDual
{
  FldDualFieldDual field { get; }
}
public class DualDualFieldDual
  : IDualFieldDual
{
  public FldDualFieldDual field { get; set; }
}

public interface IFldDualFieldDual
{
  Number field { get; }
  String AsString { get; }
}
public class DualFldDualFieldDual
  : IFldDualFieldDual
{
  public Number field { get; set; }
  public String AsString { get; set; }
}

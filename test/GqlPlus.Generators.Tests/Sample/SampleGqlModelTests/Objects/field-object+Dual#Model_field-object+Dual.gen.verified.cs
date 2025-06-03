//HintName: Model_field-object+Dual.gen.cs
// Generated from field-object+Dual.graphql+

/*
*/

namespace GqlTest.Model_field_object_Dual;

public interface IDualFieldObj
{
  FldDualFieldObj field { get; }
}
public class DualDualFieldObj
  : IDualFieldObj
{
  public FldDualFieldObj field { get; set; }
}

public interface IFldDualFieldObj
{
  Number field { get; }
  String AsString { get; }
}
public class DualFldDualFieldObj
  : IFldDualFieldObj
{
  public Number field { get; set; }
  public String AsString { get; set; }
}

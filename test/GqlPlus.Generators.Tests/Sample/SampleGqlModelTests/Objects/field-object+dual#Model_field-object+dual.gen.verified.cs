//HintName: Model_field-object+dual.gen.cs
// Generated from field-object+dual.graphql+

/*
*/

namespace GqlTest.Model_field_object_dual;

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

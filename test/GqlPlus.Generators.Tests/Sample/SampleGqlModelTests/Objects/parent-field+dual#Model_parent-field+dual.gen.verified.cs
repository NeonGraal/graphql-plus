//HintName: Model_parent-field+dual.gen.cs
// Generated from parent-field+dual.graphql+

/*
*/

namespace GqlTest.Model_parent_field_dual;

public interface IDualPrntField
{
  Number field { get; }
}
public class DualDualPrntField
{
  public Number field { get; set; }
}

public interface IRefDualPrntField
{
  Number parent { get; }
  String AsString { get; }
}
public class DualRefDualPrntField
{
  public Number parent { get; set; }
  public String AsString { get; set; }
}

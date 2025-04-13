//HintName: Model_parent-field+dual.gen.cs
// Generated from parent-field+dual.graphql+

/*
*/

namespace GqlTest.Model_parent_field_dual;

public interface IDualPrntField
  : IRefDualPrntField
{
  Number field { get; }
}
public class DualDualPrntField
  : DualRefDualPrntField
  , IDualPrntField
{
  public Number field { get; set; }
}

public interface IRefDualPrntField
{
  Number parent { get; }
  String AsString { get; }
}
public class DualRefDualPrntField
  : IRefDualPrntField
{
  public Number parent { get; set; }
  public String AsString { get; set; }
}

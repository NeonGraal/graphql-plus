//HintName: Model_parent-alt+dual.gen.cs
// Generated from parent-alt+dual.graphql+

/*
*/

namespace GqlTest.Model_parent_alt_dual;

public interface IDualPrntAlt
  : IRefDualPrntAlt
{
  Number AsNumber { get; }
}
public class DualDualPrntAlt
  : DualRefDualPrntAlt
  , IDualPrntAlt
{
  public Number AsNumber { get; set; }
}

public interface IRefDualPrntAlt
{
  Number parent { get; }
  String AsString { get; }
}
public class DualRefDualPrntAlt
  : IRefDualPrntAlt
{
  public Number parent { get; set; }
  public String AsString { get; set; }
}

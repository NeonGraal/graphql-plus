//HintName: Model_parent+Dual.gen.cs
// Generated from parent+Dual.graphql+

/*
*/

namespace GqlTest.Model_parent_Dual;

public interface IDualPrnt
  : IRefDualPrnt
{
}
public class DualDualPrnt
  : DualRefDualPrnt
  , IDualPrnt
{
}

public interface IRefDualPrnt
{
  Number parent { get; }
  String AsString { get; }
}
public class DualRefDualPrnt
  : IRefDualPrnt
{
  public Number parent { get; set; }
  public String AsString { get; set; }
}

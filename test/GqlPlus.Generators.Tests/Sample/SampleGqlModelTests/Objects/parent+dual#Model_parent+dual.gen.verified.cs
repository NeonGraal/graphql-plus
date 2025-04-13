//HintName: Model_parent+dual.gen.cs
// Generated from parent+dual.graphql+

/*
*/

namespace GqlTest.Model_parent_dual;

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

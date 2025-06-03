//HintName: Model_parent-descr+Dual.gen.cs
// Generated from parent-descr+Dual.graphql+

/*
*/

namespace GqlTest.Model_parent_descr_Dual;

public interface IDualPrntDescr
  : IRefDualPrntDescr
{
}
public class DualDualPrntDescr
  : DualRefDualPrntDescr
  , IDualPrntDescr
{
}

public interface IRefDualPrntDescr
{
  Number parent { get; }
  String AsString { get; }
}
public class DualRefDualPrntDescr
  : IRefDualPrntDescr
{
  public Number parent { get; set; }
  public String AsString { get; set; }
}

//HintName: Model_parent-descr+Dual.gen.cs
// Generated from parent-descr+Dual.graphql+

/*
*/

namespace GqlTest.Model_parent_descr_Dual;

public interface IPrntDescrDual
  : IRefPrntDescrDual
{
}
public class DualPrntDescrDual
  : DualRefPrntDescrDual
  , IPrntDescrDual
{
}

public interface IRefPrntDescrDual
{
  Number parent { get; }
  String AsString { get; }
}
public class DualRefPrntDescrDual
  : IRefPrntDescrDual
{
  public Number parent { get; set; }
  public String AsString { get; set; }
}

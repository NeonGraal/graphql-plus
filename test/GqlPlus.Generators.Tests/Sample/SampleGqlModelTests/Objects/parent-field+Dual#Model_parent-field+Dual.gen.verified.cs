//HintName: Model_parent-field+Dual.gen.cs
// Generated from parent-field+Dual.graphql+

/*
*/

namespace GqlTest.Model_parent_field_Dual;

public interface IPrntFieldDual
  : IRefPrntFieldDual
{
  Number field { get; }
}
public class DualPrntFieldDual
  : DualRefPrntFieldDual
  , IPrntFieldDual
{
  public Number field { get; set; }
}

public interface IRefPrntFieldDual
{
  Number parent { get; }
  String AsString { get; }
}
public class DualRefPrntFieldDual
  : IRefPrntFieldDual
{
  public Number parent { get; set; }
  public String AsString { get; set; }
}

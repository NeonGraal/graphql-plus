//HintName: Model_constraint-field-dual+Dual.gen.cs
// Generated from constraint-field-dual+Dual.graphql+

/*
*/

namespace GqlTest.Model_constraint_field_dual_Dual;

public interface ICnstFieldDualDual
  : IRefCnstFieldDualDual
{
}
public class DualCnstFieldDualDual
  : DualRefCnstFieldDualDual
  , ICnstFieldDualDual
{
}

public interface IRefCnstFieldDualDual<Tref>
{
  Tref field { get; }
}
public class DualRefCnstFieldDualDual<Tref>
  : IRefCnstFieldDualDual<Tref>
{
  public Tref field { get; set; }
}

public interface IPrntCnstFieldDualDual
{
  String AsString { get; }
}
public class DualPrntCnstFieldDualDual
  : IPrntCnstFieldDualDual
{
  public String AsString { get; set; }
}

public interface IAltCnstFieldDualDual
  : IPrntCnstFieldDualDual
{
  Number alt { get; }
}
public class DualAltCnstFieldDualDual
  : DualPrntCnstFieldDualDual
  , IAltCnstFieldDualDual
{
  public Number alt { get; set; }
}

//HintName: Model_constraint-alt-dual+Dual.gen.cs
// Generated from constraint-alt-dual+Dual.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_constraint_alt_dual_Dual;

public interface ICnstAltDualDual
{
  RefCnstAltDualDual<AltCnstAltDualDual> AsRefCnstAltDualDual { get; }
}
public class DualCnstAltDualDual
  : ICnstAltDualDual
{
  public RefCnstAltDualDual<AltCnstAltDualDual> AsRefCnstAltDualDual { get; set; }
}

public interface IRefCnstAltDualDual<Tref>
{
  Tref Asref { get; }
}
public class DualRefCnstAltDualDual<Tref>
  : IRefCnstAltDualDual<Tref>
{
  public Tref Asref { get; set; }
}

public interface IPrntCnstAltDualDual
{
  String AsString { get; }
}
public class DualPrntCnstAltDualDual
  : IPrntCnstAltDualDual
{
  public String AsString { get; set; }
}

public interface IAltCnstAltDualDual
  : IPrntCnstAltDualDual
{
  Number alt { get; }
}
public class DualAltCnstAltDualDual
  : DualPrntCnstAltDualDual
  , IAltCnstAltDualDual
{
  public Number alt { get; set; }
}

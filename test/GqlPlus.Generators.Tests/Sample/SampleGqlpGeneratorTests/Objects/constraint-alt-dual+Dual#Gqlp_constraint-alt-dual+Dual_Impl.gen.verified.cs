//HintName: Gqlp_constraint-alt-dual+Dual_Impl.gen.cs
// Generated from constraint-alt-dual+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_constraint_alt_dual_Dual;
public class DualCnstAltDualDual
  : ICnstAltDualDual
{
  public RefCnstAltDualDual<AltCnstAltDualDual> AsRefCnstAltDualDual { get; set; }
}
public class DualRefCnstAltDualDual<Tref>
  : IRefCnstAltDualDual<Tref>
{
  public Tref Asref { get; set; }
}
public class DualPrntCnstAltDualDual
  : IPrntCnstAltDualDual
{
  public String AsString { get; set; }
}
public class DualAltCnstAltDualDual
  : DualPrntCnstAltDualDual
  , IAltCnstAltDualDual
{
  public Number alt { get; set; }
}

//HintName: Gqlp_constraint-alt-obj+Dual_Impl.gen.cs
// Generated from constraint-alt-obj+Dual.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_constraint_alt_obj_Dual;
public class DualCnstAltObjDual
  : ICnstAltObjDual
{
  public RefCnstAltObjDual<AltCnstAltObjDual> AsRefCnstAltObjDual { get; set; }
}
public class DualRefCnstAltObjDual<Tref>
  : IRefCnstAltObjDual<Tref>
{
  public Tref Asref { get; set; }
}
public class DualPrntCnstAltObjDual
  : IPrntCnstAltObjDual
{
  public String AsString { get; set; }
}
public class DualAltCnstAltObjDual
  : DualPrntCnstAltObjDual
  , IAltCnstAltObjDual
{
  public Number alt { get; set; }
}

//HintName: test_constraint-alt-obj+Dual_Impl.gen.cs
// Generated from constraint-alt-obj+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_obj_Dual;

public class DualtestCnstAltObjDual
  : ItestCnstAltObjDual
{
  public RefCnstAltObjDual<AltCnstAltObjDual> AsRefCnstAltObjDual { get; set; }
}

public class DualtestRefCnstAltObjDual<Tref>
  : ItestRefCnstAltObjDual<Tref>
{
  public Tref Asref { get; set; }
}

public class DualtestPrntCnstAltObjDual
  : ItestPrntCnstAltObjDual
{
  public String AsString { get; set; }
}

public class DualtestAltCnstAltObjDual
  : DualtestPrntCnstAltObjDual
  , ItestAltCnstAltObjDual
{
  public Number alt { get; set; }
}

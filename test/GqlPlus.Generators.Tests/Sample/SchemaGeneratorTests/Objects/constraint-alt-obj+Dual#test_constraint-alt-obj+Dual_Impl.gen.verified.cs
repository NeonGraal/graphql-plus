//HintName: test_constraint-alt-obj+Dual_Impl.gen.cs
// Generated from constraint-alt-obj+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_obj_Dual;

public class testCnstAltObjDual
  : ItestCnstAltObjDual
{
  public RefCnstAltObjDual<AltCnstAltObjDual> AsRefCnstAltObjDual { get; set; }
}

public class testRefCnstAltObjDual<Tref>
  : ItestRefCnstAltObjDual<Tref>
{
  public Tref Asref { get; set; }
}

public class testPrntCnstAltObjDual
  : ItestPrntCnstAltObjDual
{
  public String AsString { get; set; }
}

public class testAltCnstAltObjDual
  : testPrntCnstAltObjDual
  , ItestAltCnstAltObjDual
{
  public Number alt { get; set; }
}

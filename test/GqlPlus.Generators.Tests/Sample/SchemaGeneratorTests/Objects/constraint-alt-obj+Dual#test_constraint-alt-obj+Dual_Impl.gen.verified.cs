//HintName: test_constraint-alt-obj+Dual_Impl.gen.cs
// Generated from constraint-alt-obj+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_obj_Dual;

public class testCnstAltObjDual
  : ItestCnstAltObjDual
{
  public testRefCnstAltObjDual<testAltCnstAltObjDual> AsRefCnstAltObjDual { get; set; }
  public testCnstAltObjDual CnstAltObjDual { get; set; }
}

public class testRefCnstAltObjDual<Tref>
  : ItestRefCnstAltObjDual<Tref>
{
  public Tref Asref { get; set; }
  public testRefCnstAltObjDual RefCnstAltObjDual { get; set; }
}

public class testPrntCnstAltObjDual
  : ItestPrntCnstAltObjDual
{
  public testString AsString { get; set; }
  public testPrntCnstAltObjDual PrntCnstAltObjDual { get; set; }
}

public class testAltCnstAltObjDual
  : testPrntCnstAltObjDual
  , ItestAltCnstAltObjDual
{
  public testNumber alt { get; set; }
  public testAltCnstAltObjDual AltCnstAltObjDual { get; set; }
}

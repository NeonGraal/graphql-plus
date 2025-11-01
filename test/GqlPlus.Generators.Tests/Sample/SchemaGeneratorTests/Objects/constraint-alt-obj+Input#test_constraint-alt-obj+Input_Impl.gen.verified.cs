//HintName: test_constraint-alt-obj+Input_Impl.gen.cs
// Generated from constraint-alt-obj+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_obj_Input;

public class testCnstAltObjInp
  : ItestCnstAltObjInp
{
  public testRefCnstAltObjInp<testAltCnstAltObjInp> AsRefCnstAltObjInp { get; set; }
  public testCnstAltObjInp CnstAltObjInp { get; set; }
}

public class testRefCnstAltObjInp<Tref>
  : ItestRefCnstAltObjInp<Tref>
{
  public Tref Asref { get; set; }
  public testRefCnstAltObjInp RefCnstAltObjInp { get; set; }
}

public class testPrntCnstAltObjInp
  : ItestPrntCnstAltObjInp
{
  public testString AsString { get; set; }
  public testPrntCnstAltObjInp PrntCnstAltObjInp { get; set; }
}

public class testAltCnstAltObjInp
  : testPrntCnstAltObjInp
  , ItestAltCnstAltObjInp
{
  public testNumber alt { get; set; }
  public testAltCnstAltObjInp AltCnstAltObjInp { get; set; }
}

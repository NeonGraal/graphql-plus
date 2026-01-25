//HintName: test_constraint-alt-obj+Input_Intf.gen.cs
// Generated from constraint-alt-obj+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_obj_Input;

public interface ItestCnstAltObjInp
{
  public testRefCnstAltObjInp<testAltCnstAltObjInp> AsRefCnstAltObjInp { get; set; }
  public testCnstAltObjInp CnstAltObjInp { get; set; }
}

public interface ItestCnstAltObjInpObject
{
}

public interface ItestRefCnstAltObjInp<Tref>
{
  public Tref Asref { get; set; }
  public testRefCnstAltObjInp RefCnstAltObjInp { get; set; }
}

public interface ItestRefCnstAltObjInpObject<Tref>
{
}

public interface ItestPrntCnstAltObjInp
{
  public testString AsString { get; set; }
  public testPrntCnstAltObjInp PrntCnstAltObjInp { get; set; }
}

public interface ItestPrntCnstAltObjInpObject
{
}

public interface ItestAltCnstAltObjInp
  : ItestPrntCnstAltObjInp
{
  public testAltCnstAltObjInp AltCnstAltObjInp { get; set; }
}

public interface ItestAltCnstAltObjInpObject
  : ItestPrntCnstAltObjInpObject
{
  public testNumber alt { get; set; }
}

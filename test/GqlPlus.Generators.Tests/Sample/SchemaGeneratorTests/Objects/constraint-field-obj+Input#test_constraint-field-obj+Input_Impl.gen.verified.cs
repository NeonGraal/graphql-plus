//HintName: test_constraint-field-obj+Input_Impl.gen.cs
// Generated from constraint-field-obj+Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_obj_Input;

public class testCnstFieldObjInp
  : testRefCnstFieldObjInp
  , ItestCnstFieldObjInp
{
  public testCnstFieldObjInp CnstFieldObjInp { get; set; }
}

public class testRefCnstFieldObjInp<Tref>
  : ItestRefCnstFieldObjInp<Tref>
{
  public Tref field { get; set; }
  public testRefCnstFieldObjInp RefCnstFieldObjInp { get; set; }
}

public class testPrntCnstFieldObjInp
  : ItestPrntCnstFieldObjInp
{
  public testString AsString { get; set; }
  public testPrntCnstFieldObjInp PrntCnstFieldObjInp { get; set; }
}

public class testAltCnstFieldObjInp
  : testPrntCnstFieldObjInp
  , ItestAltCnstFieldObjInp
{
  public testNumber alt { get; set; }
  public testAltCnstFieldObjInp AltCnstFieldObjInp { get; set; }
}

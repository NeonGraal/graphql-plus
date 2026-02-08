//HintName: test_constraint-alt-obj+Input_Impl.gen.cs
// Generated from constraint-alt-obj+Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_obj_Input;

public class testCnstAltObjInp
  : ItestCnstAltObjInp
{
  public ItestRefCnstAltObjInp<ItestAltCnstAltObjInp> AsRefCnstAltObjInp { get; set; }
  public ItestCnstAltObjInpObject AsCnstAltObjInp { get; set; }
}

public class testRefCnstAltObjInp<Tref>
  : ItestRefCnstAltObjInp<Tref>
{
  public Tref Asref { get; set; }
  public ItestRefCnstAltObjInpObject AsRefCnstAltObjInp { get; set; }
}

public class testPrntCnstAltObjInp
  : ItestPrntCnstAltObjInp
{
  public ItestString AsString { get; set; }
  public ItestPrntCnstAltObjInpObject AsPrntCnstAltObjInp { get; set; }
}

public class testAltCnstAltObjInp
  : testPrntCnstAltObjInp
  , ItestAltCnstAltObjInp
{
  public ItestNumber Alt { get; set; }
  public ItestAltCnstAltObjInpObject AsAltCnstAltObjInp { get; set; }
}

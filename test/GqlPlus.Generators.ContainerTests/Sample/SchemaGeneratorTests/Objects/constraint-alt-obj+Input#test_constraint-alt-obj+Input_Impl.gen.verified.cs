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

public class testRefCnstAltObjInp<TRef>
  : ItestRefCnstAltObjInp<TRef>
{
  public TRef Asref { get; set; }
  public ItestRefCnstAltObjInpObject<TRef> AsRefCnstAltObjInp { get; set; }
}

public class testPrntCnstAltObjInp
  : ItestPrntCnstAltObjInp
{
  public string AsString { get; set; }
  public ItestPrntCnstAltObjInpObject AsPrntCnstAltObjInp { get; set; }
}

public class testAltCnstAltObjInp
  : testPrntCnstAltObjInp
  , ItestAltCnstAltObjInp
{
  public decimal Alt { get; set; }
  public ItestAltCnstAltObjInpObject AsAltCnstAltObjInp { get; set; }
}

//HintName: test_constraint-field-obj+Input_Impl.gen.cs
// Generated from constraint-field-obj+Input.graphql+ for Impl
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_obj_Input;

public class testCnstFieldObjInp
  : testRefCnstFieldObjInp<ItestAltCnstFieldObjInp>
  , ItestCnstFieldObjInp
{
  public ItestCnstFieldObjInpObject AsCnstFieldObjInp { get; set; }
}

public class testRefCnstFieldObjInp<TRef>
  : ItestRefCnstFieldObjInp<TRef>
{
  public TRef Field { get; set; }
  public ItestRefCnstFieldObjInpObject<TRef> AsRefCnstFieldObjInp { get; set; }
}

public class testPrntCnstFieldObjInp
  : ItestPrntCnstFieldObjInp
{
  public string AsString { get; set; }
  public ItestPrntCnstFieldObjInpObject AsPrntCnstFieldObjInp { get; set; }
}

public class testAltCnstFieldObjInp
  : testPrntCnstFieldObjInp
  , ItestAltCnstFieldObjInp
{
  public decimal Alt { get; set; }
  public ItestAltCnstFieldObjInpObject AsAltCnstFieldObjInp { get; set; }
}

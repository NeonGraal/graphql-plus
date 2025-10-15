//HintName: test_constraint-alt-obj+Input_Impl.gen.cs
// Generated from constraint-alt-obj+Input.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_obj_Input;

public class InputtestCnstAltObjInp
  : ItestCnstAltObjInp
{
  public RefCnstAltObjInp<AltCnstAltObjInp> AsRefCnstAltObjInp { get; set; }
}

public class InputtestRefCnstAltObjInp<Tref>
  : ItestRefCnstAltObjInp<Tref>
{
  public Tref Asref { get; set; }
}

public class InputtestPrntCnstAltObjInp
  : ItestPrntCnstAltObjInp
{
  public String AsString { get; set; }
}

public class InputtestAltCnstAltObjInp
  : InputtestPrntCnstAltObjInp
  , ItestAltCnstAltObjInp
{
  public Number alt { get; set; }
}

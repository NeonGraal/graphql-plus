//HintName: test_constraint-alt-obj+Input_Intf.gen.cs
// Generated from constraint-alt-obj+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_obj_Input;

public interface ItestCnstAltObjInp
{
  public ItestRefCnstAltObjInp<ItestAltCnstAltObjInp> AsRefCnstAltObjInp { get; set; }
}

public interface ItestCnstAltObjInpObject
{
}

public interface ItestRefCnstAltObjInp<Tref>
{
  public Tref Asref { get; set; }
}

public interface ItestRefCnstAltObjInpObject<Tref>
{
}

public interface ItestPrntCnstAltObjInp
{
  public ItestString AsString { get; set; }
}

public interface ItestPrntCnstAltObjInpObject
{
}

public interface ItestAltCnstAltObjInp
  : ItestPrntCnstAltObjInp
{
}

public interface ItestAltCnstAltObjInpObject
  : ItestPrntCnstAltObjInpObject
{
  public ItestNumber Alt { get; set; }
}

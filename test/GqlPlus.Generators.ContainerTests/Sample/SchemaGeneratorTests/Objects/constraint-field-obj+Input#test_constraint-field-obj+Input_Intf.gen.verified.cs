//HintName: test_constraint-field-obj+Input_Intf.gen.cs
// Generated from constraint-field-obj+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_obj_Input;

public interface ItestCnstFieldObjInp
  : ItestRefCnstFieldObjInp
{
}

public interface ItestCnstFieldObjInpObject
  : ItestRefCnstFieldObjInpObject
{
}

public interface ItestRefCnstFieldObjInp<Tref>
{
}

public interface ItestRefCnstFieldObjInpObject<Tref>
{
  public Tref Field { get; set; }
}

public interface ItestPrntCnstFieldObjInp
{
  public ItestString AsString { get; set; }
}

public interface ItestPrntCnstFieldObjInpObject
{
}

public interface ItestAltCnstFieldObjInp
  : ItestPrntCnstFieldObjInp
{
}

public interface ItestAltCnstFieldObjInpObject
  : ItestPrntCnstFieldObjInpObject
{
  public ItestNumber Alt { get; set; }
}

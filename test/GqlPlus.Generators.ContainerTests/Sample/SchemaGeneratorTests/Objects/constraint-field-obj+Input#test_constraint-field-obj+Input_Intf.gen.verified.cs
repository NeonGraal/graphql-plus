//HintName: test_constraint-field-obj+Input_Intf.gen.cs
// Generated from constraint-field-obj+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_obj_Input;

public interface ItestCnstFieldObjInp
  : ItestRefCnstFieldObjInp
{
  ItestCnstFieldObjInpObject AsCnstFieldObjInp { get; }
}

public interface ItestCnstFieldObjInpObject
  : ItestRefCnstFieldObjInpObject
{
}

public interface ItestRefCnstFieldObjInp<Tref>
{
  ItestRefCnstFieldObjInpObject AsRefCnstFieldObjInp { get; }
}

public interface ItestRefCnstFieldObjInpObject<Tref>
{
  Tref Field { get; }
}

public interface ItestPrntCnstFieldObjInp
{
  string AsString { get; }
  ItestPrntCnstFieldObjInpObject AsPrntCnstFieldObjInp { get; }
}

public interface ItestPrntCnstFieldObjInpObject
{
}

public interface ItestAltCnstFieldObjInp
  : ItestPrntCnstFieldObjInp
{
  ItestAltCnstFieldObjInpObject AsAltCnstFieldObjInp { get; }
}

public interface ItestAltCnstFieldObjInpObject
  : ItestPrntCnstFieldObjInpObject
{
  decimal Alt { get; }
}

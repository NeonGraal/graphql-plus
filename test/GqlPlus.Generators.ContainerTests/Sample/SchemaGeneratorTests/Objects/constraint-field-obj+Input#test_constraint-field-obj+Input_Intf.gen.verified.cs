//HintName: test_constraint-field-obj+Input_Intf.gen.cs
// Generated from constraint-field-obj+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_obj_Input;

public interface ItestCnstFieldObjInp
  : ItestRefCnstFieldObjInp<ItestAltCnstFieldObjInp>
{
  ItestCnstFieldObjInpObject AsCnstFieldObjInp { get; }
}

public interface ItestCnstFieldObjInpObject
  : ItestRefCnstFieldObjInpObject<ItestAltCnstFieldObjInp>
{
}

public interface ItestRefCnstFieldObjInp<TRef>
{
  ItestRefCnstFieldObjInpObject AsRefCnstFieldObjInp { get; }
}

public interface ItestRefCnstFieldObjInpObject<TRef>
{
  TRef Field { get; }
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

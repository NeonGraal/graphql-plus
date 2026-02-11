//HintName: test_constraint-alt-obj+Input_Intf.gen.cs
// Generated from constraint-alt-obj+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_obj_Input;

public interface ItestCnstAltObjInp
{
  ItestRefCnstAltObjInp<ItestAltCnstAltObjInp> AsRefCnstAltObjInp { get; }
  ItestCnstAltObjInpObject AsCnstAltObjInp { get; }
}

public interface ItestCnstAltObjInpObject
{
}

public interface ItestRefCnstAltObjInp<TRef>
{
  TRef Asref { get; }
  ItestRefCnstAltObjInpObject AsRefCnstAltObjInp { get; }
}

public interface ItestRefCnstAltObjInpObject<TRef>
{
}

public interface ItestPrntCnstAltObjInp
{
  string AsString { get; }
  ItestPrntCnstAltObjInpObject AsPrntCnstAltObjInp { get; }
}

public interface ItestPrntCnstAltObjInpObject
{
}

public interface ItestAltCnstAltObjInp
  : ItestPrntCnstAltObjInp
{
  ItestAltCnstAltObjInpObject AsAltCnstAltObjInp { get; }
}

public interface ItestAltCnstAltObjInpObject
  : ItestPrntCnstAltObjInpObject
{
  decimal Alt { get; }
}

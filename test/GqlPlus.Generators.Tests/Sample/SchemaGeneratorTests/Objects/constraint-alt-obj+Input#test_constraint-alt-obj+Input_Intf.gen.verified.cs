//HintName: test_constraint-alt-obj+Input_Intf.gen.cs
// Generated from constraint-alt-obj+Input.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_obj_Input;

public interface ItestCnstAltObjInp
{
  RefCnstAltObjInp<AltCnstAltObjInp> AsRefCnstAltObjInp { get; }
}

public interface ItestRefCnstAltObjInp<Tref>
{
  Tref Asref { get; }
}

public interface ItestPrntCnstAltObjInp
{
  String AsString { get; }
}

public interface ItestAltCnstAltObjInp
  : ItestPrntCnstAltObjInp
{
  Number alt { get; }
}

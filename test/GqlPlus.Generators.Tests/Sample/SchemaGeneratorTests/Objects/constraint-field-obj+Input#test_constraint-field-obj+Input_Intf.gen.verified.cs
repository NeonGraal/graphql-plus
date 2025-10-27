//HintName: test_constraint-field-obj+Input_Intf.gen.cs
// Generated from constraint-field-obj+Input.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_obj_Input;

public interface ItestCnstFieldObjInp
  : ItestRefCnstFieldObjInp
{
}

public interface ItestRefCnstFieldObjInp<Tref>
{
  Tref field { get; }
}

public interface ItestPrntCnstFieldObjInp
{
  String AsString { get; }
}

public interface ItestAltCnstFieldObjInp
  : ItestPrntCnstFieldObjInp
{
  Number alt { get; }
}

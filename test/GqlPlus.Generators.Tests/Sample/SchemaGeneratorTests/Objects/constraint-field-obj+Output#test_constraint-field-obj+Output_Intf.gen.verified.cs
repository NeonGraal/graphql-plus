//HintName: test_constraint-field-obj+Output_Intf.gen.cs
// Generated from constraint-field-obj+Output.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_obj_Output;

public interface ItestCnstFieldObjOutp
  : ItestRefCnstFieldObjOutp
{
}

public interface ItestRefCnstFieldObjOutp<Tref>
{
  Tref field { get; }
}

public interface ItestPrntCnstFieldObjOutp
{
  String AsString { get; }
}

public interface ItestAltCnstFieldObjOutp
  : ItestPrntCnstFieldObjOutp
{
  Number alt { get; }
}

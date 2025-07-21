//HintName: Gqlp_constraint-field-obj+Output_Intf.gen.cs
// Generated from constraint-field-obj+Output.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_constraint_field_obj_Output;

public interface ICnstFieldObjOutp
  : IRefCnstFieldObjOutp
{
}

public interface IRefCnstFieldObjOutp<Tref>
{
  Tref field { get; }
}

public interface IPrntCnstFieldObjOutp
{
  String AsString { get; }
}

public interface IAltCnstFieldObjOutp
  : IPrntCnstFieldObjOutp
{
  Number alt { get; }
}

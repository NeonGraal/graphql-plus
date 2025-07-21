//HintName: Gqlp_constraint-field-obj+Input_Intf.gen.cs
// Generated from constraint-field-obj+Input.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_constraint_field_obj_Input;

public interface ICnstFieldObjInp
  : IRefCnstFieldObjInp
{
}

public interface IRefCnstFieldObjInp<Tref>
{
  Tref field { get; }
}

public interface IPrntCnstFieldObjInp
{
  String AsString { get; }
}

public interface IAltCnstFieldObjInp
  : IPrntCnstFieldObjInp
{
  Number alt { get; }
}

//HintName: Gqlp_constraint-alt-obj+Input_Intf.gen.cs
// Generated from constraint-alt-obj+Input.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_constraint_alt_obj_Input;

public interface ICnstAltObjInp
{
  RefCnstAltObjInp<AltCnstAltObjInp> AsRefCnstAltObjInp { get; }
}

public interface IRefCnstAltObjInp<Tref>
{
  Tref Asref { get; }
}

public interface IPrntCnstAltObjInp
{
  String AsString { get; }
}

public interface IAltCnstAltObjInp
  : IPrntCnstAltObjInp
{
  Number alt { get; }
}

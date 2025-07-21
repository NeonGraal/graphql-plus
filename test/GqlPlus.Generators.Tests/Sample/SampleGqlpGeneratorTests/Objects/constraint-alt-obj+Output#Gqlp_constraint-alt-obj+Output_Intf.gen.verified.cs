//HintName: Gqlp_constraint-alt-obj+Output_Intf.gen.cs
// Generated from constraint-alt-obj+Output.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_constraint_alt_obj_Output;

public interface ICnstAltObjOutp
{
  RefCnstAltObjOutp<AltCnstAltObjOutp> AsRefCnstAltObjOutp { get; }
}

public interface IRefCnstAltObjOutp<Tref>
{
  Tref Asref { get; }
}

public interface IPrntCnstAltObjOutp
{
  String AsString { get; }
}

public interface IAltCnstAltObjOutp
  : IPrntCnstAltObjOutp
{
  Number alt { get; }
}

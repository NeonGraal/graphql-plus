//HintName: Gqlp_constraint-alt-obj+Dual_Intf.gen.cs
// Generated from constraint-alt-obj+Dual.graphql+ for Intf

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_constraint_alt_obj_Dual;

public interface ICnstAltObjDual
{
  RefCnstAltObjDual<AltCnstAltObjDual> AsRefCnstAltObjDual { get; }
}

public interface IRefCnstAltObjDual<Tref>
{
  Tref Asref { get; }
}

public interface IPrntCnstAltObjDual
{
  String AsString { get; }
}

public interface IAltCnstAltObjDual
  : IPrntCnstAltObjDual
{
  Number alt { get; }
}

//HintName: Gqlp_constraint-field-obj+Dual_Intf.gen.cs
// Generated from constraint-field-obj+Dual.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_constraint_field_obj_Dual;

public interface ICnstFieldObjDual
  : IRefCnstFieldObjDual
{
}

public interface IRefCnstFieldObjDual<Tref>
{
  Tref field { get; }
}

public interface IPrntCnstFieldObjDual
{
  String AsString { get; }
}

public interface IAltCnstFieldObjDual
  : IPrntCnstFieldObjDual
{
  Number alt { get; }
}

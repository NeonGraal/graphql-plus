//HintName: Gqlp_constraint-field-dual+Dual_Intf.gen.cs
// Generated from constraint-field-dual+Dual.graphql+ for Intf

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_constraint_field_dual_Dual;

public interface ICnstFieldDualDual
  : IRefCnstFieldDualDual
{
}

public interface IRefCnstFieldDualDual<Tref>
{
  Tref field { get; }
}

public interface IPrntCnstFieldDualDual
{
  String AsString { get; }
}

public interface IAltCnstFieldDualDual
  : IPrntCnstFieldDualDual
{
  Number alt { get; }
}

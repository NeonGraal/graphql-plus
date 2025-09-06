//HintName: Gqlp_constraint-field-dual+Input_Intf.gen.cs
// Generated from constraint-field-dual+Input.graphql+ for Intf

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_constraint_field_dual_Input;

public interface ICnstFieldDualInp
  : IRefCnstFieldDualInp
{
}

public interface IRefCnstFieldDualInp<Tref>
{
  Tref field { get; }
}

public interface IPrntCnstFieldDualInp
{
  String AsString { get; }
}

public interface IAltCnstFieldDualInp
  : IPrntCnstFieldDualInp
{
  Number alt { get; }
}

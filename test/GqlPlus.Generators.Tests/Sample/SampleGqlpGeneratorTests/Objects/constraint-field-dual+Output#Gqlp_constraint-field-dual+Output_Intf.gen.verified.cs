//HintName: Gqlp_constraint-field-dual+Output_Intf.gen.cs
// Generated from constraint-field-dual+Output.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_constraint_field_dual_Output;

public interface ICnstFieldDualOutp
  : IRefCnstFieldDualOutp
{
}

public interface IRefCnstFieldDualOutp<Tref>
{
  Tref field { get; }
}

public interface IPrntCnstFieldDualOutp
{
  String AsString { get; }
}

public interface IAltCnstFieldDualOutp
  : IPrntCnstFieldDualOutp
{
  Number alt { get; }
}

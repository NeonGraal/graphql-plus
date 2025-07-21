//HintName: Gqlp_constraint-alt-dual+Output_Intf.gen.cs
// Generated from constraint-alt-dual+Output.graphql+ for Intf

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_constraint_alt_dual_Output;

public interface ICnstAltDualOutp
{
  RefCnstAltDualOutp<AltCnstAltDualOutp> AsRefCnstAltDualOutp { get; }
}

public interface IRefCnstAltDualOutp<Tref>
{
  Tref Asref { get; }
}

public interface IPrntCnstAltDualOutp
{
  String AsString { get; }
}

public interface IAltCnstAltDualOutp
  : IPrntCnstAltDualOutp
{
  Number alt { get; }
}

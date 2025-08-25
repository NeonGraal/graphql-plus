//HintName: Gqlp_constraint-alt-dual+Input_Intf.gen.cs
// Generated from constraint-alt-dual+Input.graphql+ for Intf

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_constraint_alt_dual_Input;

public interface ICnstAltDualInp
{
  RefCnstAltDualInp<AltCnstAltDualInp> AsRefCnstAltDualInp { get; }
}

public interface IRefCnstAltDualInp<Tref>
{
  Tref Asref { get; }
}

public interface IPrntCnstAltDualInp
{
  String AsString { get; }
}

public interface IAltCnstAltDualInp
  : IPrntCnstAltDualInp
{
  Number alt { get; }
}

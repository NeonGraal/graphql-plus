//HintName: Gqlp_constraint-alt-dual+Dual_Intf.gen.cs
// Generated from constraint-alt-dual+Dual.graphql+ for Intf

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_constraint_alt_dual_Dual;

public interface ICnstAltDualDual
{
  RefCnstAltDualDual<AltCnstAltDualDual> AsRefCnstAltDualDual { get; }
}

public interface IRefCnstAltDualDual<Tref>
{
  Tref Asref { get; }
}

public interface IPrntCnstAltDualDual
{
  String AsString { get; }
}

public interface IAltCnstAltDualDual
  : IPrntCnstAltDualDual
{
  Number alt { get; }
}

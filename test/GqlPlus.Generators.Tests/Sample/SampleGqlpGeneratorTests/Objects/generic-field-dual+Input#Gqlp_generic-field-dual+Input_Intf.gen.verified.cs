//HintName: Gqlp_generic-field-dual+Input_Intf.gen.cs
// Generated from generic-field-dual+Input.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_generic_field_dual_Input;

public interface IGnrcFieldDualInp
{
  RefGnrcFieldDualInp<AltGnrcFieldDualInp> field { get; }
}

public interface IRefGnrcFieldDualInp<Tref>
{
  Tref Asref { get; }
}

public interface IAltGnrcFieldDualInp
{
  Number alt { get; }
  String AsString { get; }
}

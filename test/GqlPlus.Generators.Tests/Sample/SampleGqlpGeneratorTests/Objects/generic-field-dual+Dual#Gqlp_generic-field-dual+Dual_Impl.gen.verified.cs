//HintName: Gqlp_generic-field-dual+Dual_Impl.gen.cs
// Generated from generic-field-dual+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_generic_field_dual_Dual;
public class DualGnrcFieldDualDual
  : IGnrcFieldDualDual
{
  public RefGnrcFieldDualDual<AltGnrcFieldDualDual> field { get; set; }
}
public class DualRefGnrcFieldDualDual<Tref>
  : IRefGnrcFieldDualDual<Tref>
{
  public Tref Asref { get; set; }
}
public class DualAltGnrcFieldDualDual
  : IAltGnrcFieldDualDual
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}

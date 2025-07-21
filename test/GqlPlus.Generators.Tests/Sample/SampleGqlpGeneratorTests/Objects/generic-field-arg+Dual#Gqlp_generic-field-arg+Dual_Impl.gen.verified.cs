//HintName: Gqlp_generic-field-arg+Dual_Impl.gen.cs
// Generated from generic-field-arg+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_generic_field_arg_Dual;
public class DualGnrcFieldArgDual<Ttype>
  : IGnrcFieldArgDual<Ttype>
{
  public RefGnrcFieldArgDual<Ttype> field { get; set; }
}
public class DualRefGnrcFieldArgDual<Tref>
  : IRefGnrcFieldArgDual<Tref>
{
  public Tref Asref { get; set; }
}

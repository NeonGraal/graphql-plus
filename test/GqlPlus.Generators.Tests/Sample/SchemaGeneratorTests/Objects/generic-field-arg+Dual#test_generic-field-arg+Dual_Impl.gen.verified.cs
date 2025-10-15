//HintName: test_generic-field-arg+Dual_Impl.gen.cs
// Generated from generic-field-arg+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_field_arg_Dual;

public class DualtestGnrcFieldArgDual<Ttype>
  : ItestGnrcFieldArgDual<Ttype>
{
  public RefGnrcFieldArgDual<Ttype> field { get; set; }
}

public class DualtestRefGnrcFieldArgDual<Tref>
  : ItestRefGnrcFieldArgDual<Tref>
{
  public Tref Asref { get; set; }
}

//HintName: test_generic-field-arg+Dual_Intf.gen.cs
// Generated from generic-field-arg+Dual.graphql+ for Intf

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_field_arg_Dual;

public interface ItestGnrcFieldArgDual<Ttype>
{
  public testGnrcFieldArgDual GnrcFieldArgDual { get; set; }
}

public interface ItestGnrcFieldArgDualField<Ttype>
{
  public testRefGnrcFieldArgDual<Ttype> field { get; set; }
}

public interface ItestRefGnrcFieldArgDual<Tref>
{
  public Tref Asref { get; set; }
  public testRefGnrcFieldArgDual RefGnrcFieldArgDual { get; set; }
}

public interface ItestRefGnrcFieldArgDualField<Tref>
{
}

//HintName: test_generic-alt-arg-descr+Dual_Impl.gen.cs
// Generated from generic-alt-arg-descr+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_alt_arg_descr_Dual;

public class testGnrcAltArgDescrDual<Ttype>
  : ItestGnrcAltArgDescrDual<Ttype>
{
  public testRefGnrcAltArgDescrDual<Ttype> AsRefGnrcAltArgDescrDual { get; set; }
  public testGnrcAltArgDescrDual GnrcAltArgDescrDual { get; set; }
}

public class testRefGnrcAltArgDescrDual<Tref>
  : ItestRefGnrcAltArgDescrDual<Tref>
{
  public Tref Asref { get; set; }
  public testRefGnrcAltArgDescrDual RefGnrcAltArgDescrDual { get; set; }
}

//HintName: Gqlp_generic-alt-arg-descr+Dual_Impl.gen.cs
// Generated from generic-alt-arg-descr+Dual.graphql+ for Impl

/*
*/
namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_generic_alt_arg_descr_Dual;
public class DualGnrcAltArgDescrDual<Ttype>
  : IGnrcAltArgDescrDual<Ttype>
{
  public RefGnrcAltArgDescrDual<Ttype> AsRefGnrcAltArgDescrDual { get; set; }
}
public class DualRefGnrcAltArgDescrDual<Tref>
  : IRefGnrcAltArgDescrDual<Tref>
{
  public Tref Asref { get; set; }
}

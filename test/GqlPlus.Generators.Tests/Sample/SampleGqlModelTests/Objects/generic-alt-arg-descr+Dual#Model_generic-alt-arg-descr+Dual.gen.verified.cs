//HintName: Model_generic-alt-arg-descr+Dual.gen.cs
// Generated from generic-alt-arg-descr+Dual.graphql+

/*
*/

namespace GqlTest.Model_generic_alt_arg_descr_Dual;

public interface IGnrcAltArgDescrDual<Ttype>
{
  RefGnrcAltArgDescrDual<Ttype> AsRefGnrcAltArgDescrDual { get; }
}
public class DualGnrcAltArgDescrDual<Ttype>
  : IGnrcAltArgDescrDual<Ttype>
{
  public RefGnrcAltArgDescrDual<Ttype> AsRefGnrcAltArgDescrDual { get; set; }
}

public interface IRefGnrcAltArgDescrDual<Tref>
{
  Tref Asref { get; }
}
public class DualRefGnrcAltArgDescrDual<Tref>
  : IRefGnrcAltArgDescrDual<Tref>
{
  public Tref Asref { get; set; }
}

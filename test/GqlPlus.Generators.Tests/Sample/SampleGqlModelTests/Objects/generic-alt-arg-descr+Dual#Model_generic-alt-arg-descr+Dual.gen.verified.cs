//HintName: Model_generic-alt-arg-descr+Dual.gen.cs
// Generated from generic-alt-arg-descr+Dual.graphql+

/*
*/

namespace GqlTest.Model_generic_alt_arg_descr_Dual;

public interface IDualGnrcAltArgDescr<Ttype>
{
  RefDualGnrcAltArgDescr<Ttype> AsRefDualGnrcAltArgDescr { get; }
}
public class DualDualGnrcAltArgDescr<Ttype>
  : IDualGnrcAltArgDescr<Ttype>
{
  public RefDualGnrcAltArgDescr<Ttype> AsRefDualGnrcAltArgDescr { get; set; }
}

public interface IRefDualGnrcAltArgDescr<Tref>
{
  Tref Asref { get; }
}
public class DualRefDualGnrcAltArgDescr<Tref>
  : IRefDualGnrcAltArgDescr<Tref>
{
  public Tref Asref { get; set; }
}

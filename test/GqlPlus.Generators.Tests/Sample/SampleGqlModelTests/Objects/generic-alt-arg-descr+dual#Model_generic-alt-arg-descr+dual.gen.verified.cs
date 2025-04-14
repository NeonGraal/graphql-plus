//HintName: Model_generic-alt-arg-descr+dual.gen.cs
// Generated from generic-alt-arg-descr+dual.graphql+

/*
*/

namespace GqlTest.Model_generic_alt_arg_descr_dual;

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

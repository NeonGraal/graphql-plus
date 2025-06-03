//HintName: Model_generic-parent-arg+Dual.gen.cs
// Generated from generic-parent-arg+Dual.graphql+

/*
*/

namespace GqlTest.Model_generic_parent_arg_Dual;

public interface IDualGnrcPrntArg<Ttype>
  : IRefDualGnrcPrntArg
{
}
public class DualDualGnrcPrntArg<Ttype>
  : DualRefDualGnrcPrntArg
  , IDualGnrcPrntArg<Ttype>
{
}

public interface IRefDualGnrcPrntArg<Tref>
{
  Tref Asref { get; }
}
public class DualRefDualGnrcPrntArg<Tref>
  : IRefDualGnrcPrntArg<Tref>
{
  public Tref Asref { get; set; }
}

//HintName: Model_generic-parent-arg+dual.gen.cs
// Generated from generic-parent-arg+dual.graphql+

/*
*/

namespace GqlTest.Model_generic_parent_arg_dual;

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

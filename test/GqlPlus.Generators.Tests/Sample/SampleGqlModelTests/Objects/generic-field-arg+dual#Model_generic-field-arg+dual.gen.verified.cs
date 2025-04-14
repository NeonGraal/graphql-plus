//HintName: Model_generic-field-arg+dual.gen.cs
// Generated from generic-field-arg+dual.graphql+

/*
*/

namespace GqlTest.Model_generic_field_arg_dual;

public interface IDualGnrcFieldArg<Ttype>
{
  RefDualGnrcFieldArg<Ttype> field { get; }
}
public class DualDualGnrcFieldArg<Ttype>
  : IDualGnrcFieldArg<Ttype>
{
  public RefDualGnrcFieldArg<Ttype> field { get; set; }
}

public interface IRefDualGnrcFieldArg<Tref>
{
  Tref Asref { get; }
}
public class DualRefDualGnrcFieldArg<Tref>
  : IRefDualGnrcFieldArg<Tref>
{
  public Tref Asref { get; set; }
}

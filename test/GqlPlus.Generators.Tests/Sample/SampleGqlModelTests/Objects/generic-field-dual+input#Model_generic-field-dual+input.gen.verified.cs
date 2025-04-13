//HintName: Model_generic-field-dual+input.gen.cs
// Generated from generic-field-dual+input.graphql+

/*
*/

namespace GqlTest.Model_generic_field_dual_input;

public interface IInpGnrcFieldDual
{
  RefInpGnrcFieldDual field { get; }
}
public class InputInpGnrcFieldDual
  : IInpGnrcFieldDual
{
  public RefInpGnrcFieldDual field { get; set; }
}

public interface IRefInpGnrcFieldDual<Tref>
{
  Tref Asref { get; }
}
public class InputRefInpGnrcFieldDual<Tref>
  : IRefInpGnrcFieldDual<Tref>
{
  public Tref Asref { get; set; }
}

public interface IAltInpGnrcFieldDual
{
  Number alt { get; }
  String AsString { get; }
}
public class DualAltInpGnrcFieldDual
  : IAltInpGnrcFieldDual
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}

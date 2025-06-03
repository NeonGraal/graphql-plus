//HintName: Model_generic-field-dual+Input.gen.cs
// Generated from generic-field-dual+Input.graphql+

/*
*/

namespace GqlTest.Model_generic_field_dual_Input;

public interface IInpGnrcFieldDual
{
  RefInpGnrcFieldDual<AltInpGnrcFieldDual> field { get; }
}
public class InputInpGnrcFieldDual
  : IInpGnrcFieldDual
{
  public RefInpGnrcFieldDual<AltInpGnrcFieldDual> field { get; set; }
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
